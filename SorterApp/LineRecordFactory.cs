using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SorterApp {
	class LineRecordFactory {
		private SortedList<string, int> dict = new SortedList<string, int>();
		CultureInfo cultureInfo;
		TextInfo textInfo;

		public LineRecordFactory() {
			cultureInfo = Thread.CurrentThread.CurrentCulture;
			textInfo = cultureInfo.TextInfo;
		}

		public LineRecord Make( string s ) {
			int pb = s.IndexOf( '.' );
			List<int> words = new List<int>( 0 );

			int number = Convert.ToUInt16( s.Substring( 0, pb ) );
			s = s + " ";
			pb += 2;
			int pe = s.IndexOf( " ", pb );
			while ( pb < pe ) {
				string word = textInfo.ToLower( s.Substring( pb, pe - pb ) );
				if ( !dict.ContainsKey( word ) ) {
					dict.Add( word, dict.Count );
				}
				words.Add( dict.IndexOfKey( word ) );
				pb = pe + 1;
				pe = s.IndexOf( " ", pb );
			}
			return new LineRecord( number, words );
		}

		public string ToString( LineRecord l ) {
			string result = l.numberKey.ToString();
			result += ". " + textInfo.ToTitleCase( dict.ElementAt( l.words[0] ).Key );
			for ( int i = 0; i < l.wordsCount; i++ ) {
				result += " " + dict.ElementAt( l.words[i] ).Key;
			}
			return result;
		}
	}
}
