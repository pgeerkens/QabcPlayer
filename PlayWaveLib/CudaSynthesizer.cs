using Cudafy;
using System.Threading.Tasks;

namespace PGSoftwareSolutions.Music {
    class CudaSynthesizer : Synthesizer {
		public CudaSynthesizer()							: base() {}
		public new static string Code_Synthesizer	{ get { return ResourcesSynth.Code_Synthesizer; } }

		[Cudafy]
		private static short[] NoteSamples(ISynthesizerControls synth, INote note) {
			const uint amplitudeBase = short.MaxValue / 32;

            var _parallelOptions        = new ParallelOptions {
                MaxDegreeOfParallelism = synth.MaxDegreeeOfParallelism
            };

			int maxSamples		= (int)GMath.Floor(SampleRate * (float)note.LengthSeconds);
			short[] samples	    = new short[maxSamples];

			int	maxFreq		    = (ushort)(SampleRate / 2);	// theoretical limit
			float energy		= amplitudeBase * GMath.Pow(2, note.Energy);
			float dTime			= 1.0F / SampleRate;

			float frequency	    = (float)note.Frequency;
			float duration		= (float)note.Duration;
			float lengthSecs	= (float)note.LengthSeconds;

			Parallel.For(0, maxSamples, _parallelOptions, index => {
				float dSample = 0;
				if (frequency > 0) {
					int maxHarmonic = maxFreq / (int)GMath.Floor(frequency);
					float basePhase = 2 * GMath.PI * frequency * dTime * index;
					float freqHarmonic = frequency;
					for (int harmonic = 1; harmonic < maxHarmonic; harmonic++, freqHarmonic += frequency) {
						dSample += GMath.Sin(harmonic * basePhase) * HarmonicDecay(harmonic)
									* FrequencyResponse(freqHarmonic);
					}
					dSample *= energy * Adsr(duration, lengthSecs, dTime * index);

					if (dSample > short.MaxValue) { dSample = short.MaxValue; }
					if (dSample < short.MinValue) { dSample = short.MinValue; }
				}
				samples[index] = (short)dSample;
			});
			return samples;
		}
		public static int SampleRate { get { return 44100; } } // per second
		public static int MaxDegreeeOfParallelism { get { return -1; } }

		// Attack-Decay-Sustain-Release control:
		//--------------------------------------
		// Linear Attack from 0.0 to riseTime.
		// Exponential Decay & Sustain controlled by timeDecayConst
		//                      from riseTime to noteDuration.
		// Linear Release from noteDuration to noteLength.
		//----------------------------------------------------------
		[Cudafy]
		public static float Adsr(float noteDuration, float noteLength, float noteTime) {
			const float timeDecayConst = 1.5F;
			const float riseTime       = 0.015F;

			return (
				GMath.Exp(-timeDecayConst * noteTime) *
					( (noteTime < riseTime)     ? noteTime / riseTime 
					: (noteTime > noteDuration) ? (noteTime     - noteLength)
														/ (noteDuration - noteLength)
														:  1
					)
			);
		}

		// Harmonic response control:
		//---------------------------
		[Cudafy]
		public static float HarmonicDecay(int harmonic) {
			float freqDecayConst  = 0.025F;
			bool withEvenHarmonics = true;

			return (
				(harmonic % 2 == 1) || withEvenHarmonics)
				? GMath.Exp(-freqDecayConst * (harmonic - 1))
				: 0.0F ;
		}
    
		[Cudafy]
		public static float FrequencyResponse(float frequency) {
			return  
				(frequency < 5000) ? 0.25F + frequency/ 5000 // 0.25 - 1.25
			  : (frequency <10000) ? 1.75F - frequency/10000 // 1.25 - 0.75
								   : 1.25F - frequency/20000 // 0.75 - 0.125
								   ;
		}
	}
}
