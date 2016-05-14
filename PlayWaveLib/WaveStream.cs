////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PGSoftwareSolutions.Music {
	public interface IWaveSamples {
		int	Length		{ get; }
		int   SampleRate	{ get; }
		short this[int i] { get; }	// indexer
	}
	public class WaveStream : MemoryStream {
		public WaveStream(Tune<INote> notes, ISynthesizerControls synth, Action<int> pbarDelegate)	: base() {
			var samples = Synthesizer.Load(notes, synth, pbarDelegate);
//			new WaveWriter(this).WriteWave(synth.SampleRate, synth.Length * 2, synth);
			new WaveWriter(this).WriteWave(samples.SampleRate, samples.Length * 2, samples);
			Position = 0;
		}

		public StringCollection DisplayString() {
			const Int32 bytesPerLine = 8;
			const String sPad08 = "        ";
			const String sPad40 = "                                        ";

			Int32 lineCount = (Int32)(Math.Ceiling(((Double)(Length)) / bytesPerLine));
			string[] strings = new string[lineCount];

			Position = 0;
			Parallel.For (0, lineCount, line => {
				StringBuilder a = new StringBuilder(),
								  x = new StringBuilder();
				int i = line * bytesPerLine;
				a.Clear();
				x.Clear();
				for (int j = 0; (j < bytesPerLine) && ((i + j) < Length); j++) {
					byte waveByte = checked((byte)this.ReadByte());
					if ((0x20 <= waveByte) && (waveByte <= 0x7E))
						a.Append((char)waveByte);
					else
						a.Append(".");
					x.Append(" 0x" + (waveByte).ToString("X2"));
				}
				strings[line] = (a + sPad08).Substring(0, 9) + (x + sPad40).Substring(0, 40);
			});

			StringCollection scol; 
			(scol = new StringCollection()).AddRange(strings);
			return scol;
		}

		private class WaveWriter : BinaryWriter {
			public WaveWriter(Stream stream) : base(stream, System.Text.Encoding.ASCII) { }
			public override void Write(String sval) { base.Write(sval.ToCharArray()); }

			public void WriteWave(Int32 sampleRate, Int32 numDataBytes, IWaveSamples waveSamples) {
				WriteHeader(numDataBytes);
				WriteSubchunk1(sampleRate);
				WriteSubchunk2(waveSamples);
			}

			private void WriteHeader(Int32 numDataBytes) {
				Int32 chunkSize = 36 + numDataBytes;

				Write("RIFF");		// RIFF = little-endian; RIFX = big-endian
				Write(chunkSize);	// = 36 + SubChunk2Size
				Write("WAVE");		// Format
			}

			private void WriteSubchunk1(Int32 sampleRate) {
				Int32 byteRate = sampleRate * 1 * 16 / 8;

				Write("fmt ");		// Subchunk1ID
				Write((UInt32)16);	// Subchunk1Size
				Write((UInt16)1);	// AudioFormat: 1 => PCM
				Write((UInt16)1);	// NumChannels: 1 => mono; 2 => stereo; etc.
				Write(sampleRate);	// Hertz
				Write(byteRate);		// = SampleRate * NumChannels * BitsPerSample / 8
				Write((UInt16)2);	// BlockAlign = NumChannels * BitsPerSample / 8
				Write((UInt16)16);	// BitsPerSample = 16;	
			}

			private void WriteSubchunk2(IWaveSamples waveSamples) {
				Write("data");											// ..ID
				Write(waveSamples.Length * 2);					// ..Size = numDataBytes
				for (int i = 0; i < waveSamples.Length; i++)
					Write(waveSamples[i]);							// ..Data
			}
		}
	}
}
