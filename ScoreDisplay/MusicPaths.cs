////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace PGSoftwareSolutions.ScoreDisplay {
	public interface IMusicPath {
		void Draw(ref Graphics g, PointF loc);
		void Draw(Graphics g, PointF loc);
		GraphicsPath Path { get; }
	}
	/// <summary>Singleton cache of GraphicPaths for current display size.</summary>
	public class MusicPaths : IDisposable {
		private static MusicPaths _singleton;
		public static MusicPaths StartUp(Size size) {
			if (_singleton != null) ShutDown();
			return (_singleton = new MusicPaths(size));
		}
		public static MusicPaths Get { 
			get {
				if (_singleton == null) throw new ArgumentException("Singleton not initialized.");
				return _singleton;
			}
		}
		public static void ShutDown() { _singleton.Dispose(); _singleton = null; }

		private MusicPaths(Size size) { 
			Size = size; 
			_paths					= new List<MusicPath>();

			_paths.Add(Staff		= new StaffPath(Size));
			_paths.Add(Flat			= new FlatPath());
			_paths.Add(Sharp		= new SharpPath());
			_paths.Add(RestFlag		= new RestFlagPath());
			_paths.Add(NoteFlag		= new NoteFlagPath());
			_paths.Add(CrotchetRest	= new CrotchetRestPath());
			_paths.Add(MinimNote	= new MinimNotePath());
		}
		private List<MusicPath> _paths;
		protected Size Size				{ get; private set; }

		public MusicPath Staff			{ get; protected set; }
		public MusicPath Flat			{ get; protected set; }
		public MusicPath Sharp			{ get; protected set; }
		public MusicPath RestFlag		{ get; protected set; }
		public MusicPath NoteFlag		{ get; protected set; }
		public MusicPath CrotchetRest	{ get; protected set; }
		public MusicPath MinimNote		{ get; protected set; }

		#region IDispose implementation
		private bool _disposed = false;
		public void Dispose() { Dispose(false); }
		protected void Dispose(bool disposing){
			if (!_disposed) {
				if (disposing) {
					foreach (var path in _paths) path.Dispose();

					_paths = null;
				}
			}
		}
		#endregion
	}
	public class StaffPath : MusicPath {
		public StaffPath(Size size){ _size = size;}
		Size _size;
	}

}
