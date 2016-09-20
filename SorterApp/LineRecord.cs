using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterApp {
	class LineRecord:IComparable {
		public int numberKey {
			get;
		}
		public List<int> words {
			get;
		}
		public int wordsCount {
			get{
				return words.Count;
			}
		}

		public string ToString( SortedList<string, int> dict, TextInfo textInfo ) {
			string result = numberKey.ToString();
			result += ". " + textInfo.ToTitleCase( dict.ElementAt( words[0] ).Key );
			for ( int i = 0; i < wordsCount; i++ ) {
				result += " " + dict.ElementAt( words[i] ).Key ;
			}
			return result;
		}
		/*
		public LineRecord() {
			numberKey = 0;
			words = new List<int>(0);
		}

		public LineRecord( int number, List<int> words ) {
			this.numberKey = number;
			this.words = words;
		}  */

		public LineRecord( string s, SortedList<string, int> dict, TextInfo textInfo ) {
			int pb = s.IndexOf( '.' );
			words = new List<int>( 0 );

			numberKey = Convert.ToUInt16( s.Substring( 0, pb ) );
			s = s + " ";
			pb +=2;
			int pe = s.IndexOf( " ", pb );
			while ( pb < pe) {
				string word = textInfo.ToLower(s.Substring( pb, pe-pb ));
				if ( !dict.ContainsKey( word ) ) {
					dict.Add( word, dict.Count );
				}
				words.Add(dict.IndexOfKey(word));
				pb = pe+1;
				pe = s.IndexOf( " ", pb );
			}
		}

		public int CompareTo( LineRecord c ) {
			int i = 0;
			int comparisonResult = 0;

			while ( i < this.wordsCount && i < c.wordsCount ) {
				comparisonResult = this.words[i] - c.words[i];
				if ( comparisonResult != 0 ) return comparisonResult;
				i++;
			}

			if ( this.wordsCount != c.wordsCount ) return this.wordsCount - c.wordsCount;

			return this.numberKey - c.numberKey;

		}

		int IComparable.CompareTo( object obj ) {
			return CompareTo( (LineRecord)obj );
		}
	}
}
