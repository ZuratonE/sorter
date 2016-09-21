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

		LineRecordFactory lineRecordFactory;

		public Sorter() {
			lineRecordFactory = new LineRecordFactory();
		}

		public List<LineRecord> test() {
			List<LineRecord> recList = new List<LineRecord>();

			recList.Add( lineRecordFactory.Make( "1. Aa") );
			recList.Add( lineRecordFactory.Make( "2. Aa ab aa") );
			recList.Add( lineRecordFactory.Make( "3. Aa ab") );
			recList.Add( lineRecordFactory.Make( "4. Ab aa ab") );
			recList.Add( lineRecordFactory.Make( "5. Aa") );
			recList.Add( lineRecordFactory.Make( "6. Ab aa ac") );
			recList.Add( lineRecordFactory.Make( "7. Ab ad") );
			recList.Add( lineRecordFactory.Make( "8. Ab ab") );
			recList.Add( lineRecordFactory.Make( "9. Ab ab aa") );

			recList.Sort();

			for(int i=0;i<recList.Count;i++ ) {
				Console.WriteLine( lineRecordFactory.ToString( recList.ElementAt( i )) );
			}

			return recList;

		}

		private List<LineRecord> readElements( StreamReader file, long readsize ) {
			List<LineRecord> recList = new List<LineRecord>();
			long pos = file.BaseStream.Position;
			while ( !file.EndOfStream ) {
				recList.Add( lineRecordFactory.Make( file.ReadLine() ) );
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
