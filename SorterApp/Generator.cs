using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterApp {
	class Generator {
		private List<string> lines;
		private const int linesMaxCount = 100;
		private const int repeatStringProbabilityPercent = 3;

		private const int oneMegabyte = 1048576;
		private List<string> words;
		private Random rnd;
		private int maxNumber;
		private int maxWords;


		public Generator( string dictFileName, int maxNumber, int maxWords ) {
			lines = new List<string>();
			rnd = new Random();

			words = new List<string>();

			try {
				words.AddRange( System.IO.File.ReadAllLines( dictFileName ) );
			}
			catch ( Exception ex ) {
				Console.WriteLine( "Cannot read dictionary: " + ex.ToString() );
				throw ex;
			}

			this.maxNumber = maxNumber;
			this.maxWords = maxWords;
			NewLine();

		}

		private string NewLine() {
			string lineString = ". " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase( words[rnd.Next( 0, words.Count() )].ToLower() );

			int wn = rnd.Next( 1, maxWords );
			for ( int i = 1; i < wn; i++ ) {
                lineString += " " + words[rnd.Next(0, words.Count())].ToLower();
			}

			if ( lines.Count < linesMaxCount )
				lines.Add( lineString );

			return lineString;
		}

		private string OldLine() {
			return lines.ElementAt( rnd.Next( lines.Count ) );
		}

		private string GetKey() {
			return rnd.Next( maxNumber + 1 ).ToString();
		}

		public TimeSpan Generate( string fileName, int sizeMb, System.Windows.Forms.ProgressBar bar ) {

			System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

			stopwatch.Start();

			System.IO.StreamWriter file = new System.IO.StreamWriter( fileName );

			sizeMb *= oneMegabyte;
			while ( file.BaseStream.Length < sizeMb ) {

				string str = "";
				if ( rnd.Next( 100 ) < repeatStringProbabilityPercent ) {  
					str = OldLine();
				}
				else {
					str = NewLine();
				}

				file.WriteLine( GetKey() + str );
				file.Flush();
				bar.Value = (int)(file.BaseStream.Length / 1048576);
			}

			file.WriteLine( GetKey() + OldLine() ); // guarantee that at least one string will repeat

			file.Close();

			stopwatch.Stop();
			return stopwatch.Elapsed;
		}
	}
}
