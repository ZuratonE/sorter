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
			get {
				return words.Count;
			}
		}

		public LineRecord( int number, List<int> words ) {
			this.numberKey = number;
			this.words = words;
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
