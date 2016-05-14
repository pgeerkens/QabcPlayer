#region The MIT License - Copyright (C) 2012-2016 Pieter Geerkens
/////////////////////////////////////////////////////////////////////////////////////////
//                PG Software Solutions Inc. - Hex-Grid Utilities
/////////////////////////////////////////////////////////////////////////////////////////
// The MIT License:
// ----------------
// 
// Copyright (c) 2012-2016 Pieter Geerkens (email: pgeerkens@hotmail.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, 
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
// permit persons to whom the Software is furnished to do so, subject to the following 
// conditions:
//     The above copyright notice and this permission notice shall be 
//     included in all copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//     OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//     NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
//     HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
//     WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
//     FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
//     OTHER DEALINGS IN THE SOFTWARE.
/////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;

using Microsoft.CSharp;

namespace PGSoftwareSolutions.Music {
	public interface ISynthesizerControls {
		/// <summary> Expression tree <i>Expression&lt;Func&lt;double, double, double, 
		/// double&gt;&gt;</i> for the user-defined definition of the ADSR (Attack-Decay-
		/// Sustain-Retreat) calculation for notes.
		/// </summary>
		/// <param name="NoteDuration">double: Actual length in seconds of the note</param>
		/// <param name="NoteLength">double: Nominal length in seconds of the note</param>
		/// <param name="NoteTime">double: Time ins seconds since the note started to rise</param>
		/// <return>double: Fraction of 1.0D to be applied to the note's amplitude</return>
		Expression<Func<double, double, double, double>>	Adsr();
		/// <summary> Expression tree <i>Expression&lt;Func&lt;uint, double&gt;&gt;</i> for 
		/// the user-defined definition of the harmonic decay calculation for notes.
		/// </summary>
		/// <param name="harmonic">uint: number of the current harmonic (base note = 1)</param>
		/// <return>double: Fraction of 1.0D to be applied to the note's amplitude</return>
		Expression<Func<int, double>>								HarmonicDecay();
		Expression<Func<double,double>>							FrequencyResponse();
		int SampleRate						{ get; }
		int MaxDegreeeOfParallelism	{ get; }
	}

	public class SynthesizerParseErrorsException : Exception {
		public SynthesizerParseErrorsException(string errorList) : base(errorList) { }
	}

	public class Synthesizer {
		/// <summary>
		/// Prepares (and saves) the calculated expression trees for the default internal
		/// ADSR and Harmonic-Decay functions.
		/// </summary>
		public static ISynthesizerControls ParseSynthesizer() {
			return ParseSynthesizer(Code_Synthesizer);
		}
		/// <summary>
		/// Prepares (and saves) the calculated expression trees for the user-defined
		/// ADSR and Harmonic-Decay functions.
		/// </summary>
		public static ISynthesizerControls ParseSynthesizer(string cSharpCode) {
			CompilerResults		results;
			using(CSharpCodeProvider provider	= new CSharpCodeProvider()) {
				CompilerParameters parameters	= new CompilerParameters();
				parameters.GenerateInMemory		= true;
				parameters.ReferencedAssemblies.Add(@"System.dll");
				parameters.ReferencedAssemblies.Add(@"System.Core.dll");
				parameters.ReferencedAssemblies.Add(@"PlayWaveLib.dll");

				String[] source = new String[1];
				source[0]       = cSharpCode;
				results         = provider.CompileAssemblyFromSource(parameters, source);
			}

			if (results.Errors.HasErrors) {
				StringBuilder sb = new StringBuilder();
				sb.Append("Line|Column|Message" + Environment.NewLine);
				foreach (CompilerError error in results.Errors)
					sb.Append(String.Format("{0,4:D}|{1,5:D}|{2}",
						error.Line, error.Column, error.ErrorText)
						+ Environment.NewLine + Environment.NewLine);
				throw new SynthesizerParseErrorsException(sb.ToString());
			} else {
				Type cls = results.CompiledAssembly.GetType("DynSynthesizer.DynSynthesizer");
				if (cls == null) {
					throw new SynthesizerParseErrorsException("Unrecognized Type 'DynSynthesizer'.");
				} else {
					ConstructorInfo info = cls.GetConstructor(System.Type.EmptyTypes);
					return (ISynthesizerControls)(info.Invoke((object[])null));
				}
			}
		}
		public static string Code_Synthesizer	{ get { return ResourcesSynth.Code_Synthesizer; } }

		public static IWaveSamples Load(Tune<INote> notes, ISynthesizerControls synthCtls, Action<int> pbarDelegate) {
			var samples = new List<short>();
			for(int i = 0; i < notes.Count; i++) {
				samples.AddRange(NoteSamples(synthCtls,notes[i]));
				pbarDelegate(i);
			}
			return new WaveSamples(synthCtls.SampleRate, samples);
		}
		private static short[] NoteSamples(ISynthesizerControls synth, INote note) {
			const uint	amplitudeBase	= short.MaxValue / 32;
			int sampleRate				= synth.SampleRate;
			var adsr						= synth.Adsr().Compile();
			var harmonicDecay			= synth.HarmonicDecay().Compile();
			var frequencyResponse	= synth.FrequencyResponse().Compile();
			var _parallelOptions		= new ParallelOptions();
			_parallelOptions.MaxDegreeOfParallelism = synth.MaxDegreeeOfParallelism;

			int maxSamples		= (int)Math.Floor(sampleRate * note.LengthSeconds);
			short[] samples	= new short[maxSamples];

			int	maxFreq		= (ushort)(sampleRate / 2);	// theoretical limit
			double energy		= amplitudeBase * Math.Pow(2, note.Energy);
			double dTime		= 1.0 / sampleRate;

			double frequency	= note.Frequency;
			double duration	= note.Duration;
			double lengthSecs	= note.LengthSeconds;

			Parallel.For(0, maxSamples, _parallelOptions, index => {
				double dSample = 0;
				if (frequency > 0) {
					int maxHarmonic = maxFreq / (int)Math.Floor(frequency);
					double basePhase = 2 * Math.PI * frequency * dTime * index;
					double freqHarmonic = frequency;
					for (int harmonic = 1; harmonic < maxHarmonic; harmonic++, freqHarmonic += frequency) {
						dSample += Math.Sin(harmonic * basePhase) * harmonicDecay(harmonic)
									* frequencyResponse(freqHarmonic);
					}
					dSample *= energy * adsr(duration, lengthSecs, dTime * index);

					if (dSample > short.MaxValue) { dSample = short.MaxValue; }
					if (dSample < short.MinValue) { dSample = short.MinValue; }
				}
				samples[index] = (short)dSample;
			});
			return samples;
		}
	}

	public class WaveSamples : IWaveSamples {
		public WaveSamples(int sampleRate, List<short> samples) { 
			SampleRate = sampleRate;
			_samples = samples;
		}
		/// <summary>Indexer: returns item at index i.</summary>
		public short this[int i] {			// array _samples will perform bounds checking
							get { return _samples[i]; }
			protected	set { _samples[i] = value; }
		} internal List<short> _samples;
		public int Length { get { return _samples.Count; } }
		public int SampleRate { get; private set; }
	}
}
