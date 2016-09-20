using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SorterApp {
	class Sorter {
		private SortedList<string, int> dict = new SortedList<string, int>();
		CultureInfo cultureInfo;
		TextInfo textInfo;

		public Sorter() {
			cultureInfo = Thread.CurrentThread.CurrentCulture;
			textInfo = cultureInfo.TextInfo;
		}

		public List<LineRecord> test() {
			List<LineRecord> recList = new List<LineRecord>();

			recList.Add( new LineRecord( "1. Aa", dict, textInfo ) );
			recList.Add( new LineRecord( "2. Aa ab aa", dict, textInfo ) );
			recList.Add( new LineRecord( "3. Aa ab", dict, textInfo ) );
			recList.Add( new LineRecord( "4. Ab aa ab", dict, textInfo ) );
			recList.Add( new LineRecord( "5. Aa", dict, textInfo ) );
			recList.Add( new LineRecord( "6. Ab aa ac", dict, textInfo ) );
			recList.Add( new LineRecord( "7. Ab ad", dict, textInfo ) );
			recList.Add( new LineRecord( "8. Ab ab", dict, textInfo ) );
			recList.Add( new LineRecord( "9. Ab ab aa", dict, textInfo ) );

			recList.Sort();

			for(int i=0;i<recList.Count;i++ ) {
				Console.WriteLine( recList.ElementAt( i ).ToString(dict,textInfo) );
			}

			return recList;

		}

		private List<LineRecord> readElements( StreamReader file, long readsize ) {
			List<LineRecord> recList = new List<LineRecord>();
			long pos = file.BaseStream.Position;
			while ( !file.EndOfStream ) {
				recList.Add( new LineRecord( file.ReadLine(), dict, textInfo ) );
				if ( (file.BaseStream.Position - pos) > readsize ) break;
			}
			return recList;
		}

		private void writeElements( StreamWriter file, List<LineRecord> recList ) {
			foreach ( LineRecord el in recList ) {
				file.WriteLine( el.ToString() );
			}
		}

		private bool CreateSubFile( StreamReader file, string subfilename, long subfilesize ) {
			List<LineRecord> recList = readElements( file, subfilesize );
			recList.Sort();

			var subfile = new StreamWriter( subfilename );
			writeElements( subfile, recList );
			subfile.Close();

			return file.EndOfStream;
		}



	}
}
