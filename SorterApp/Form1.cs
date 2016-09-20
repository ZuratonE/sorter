using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorterApp {
	public partial class Form1:Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e ) {
			labelDictionaryFileName.Text = Properties.Settings.Default.dictionaryFileName;
			textBoxMaxWords.Text = Properties.Settings.Default.maxWordsInLine.ToString();
			textBoxMaxNumber.Text = Properties.Settings.Default.maxNumberInLine.ToString();
			textBoxSizeMb.Text = Properties.Settings.Default.fileSizeMb.ToString();

		}

		private void buttonSelectDictionaryFile_Click( object sender, EventArgs e ) {
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.Title = "Select dictionary file (one word per line, max 10 Mb)";
			openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.Multiselect = false;

			if ( openFileDialog1.ShowDialog() == DialogResult.OK ) {

                var f = File.Open(openFileDialog1.FileName, FileMode.Open);
				if(f.Length < 10*1024*1024) {
					labelDictionaryFileName.Text = Properties.Settings.Default.dictionaryFileName = openFileDialog1.FileName;
				}
				else {
					MessageBox.Show( "Dictionary too big!" );
				}
                f.Close();
			}
		}

		private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.Save();
		}

		private void buttonGenerate_Click( object sender, EventArgs e ) {
			progressBar1.Value = 0;
			progressBar1.Minimum = 0;
			progressBar1.Maximum = Properties.Settings.Default.fileSizeMb;

			var saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Title = "Select output file";
			saveFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 1;

			if ( saveFileDialog1.ShowDialog() == DialogResult.OK ) {
				var g = new Generator( 
										Properties.Settings.Default.dictionaryFileName, 
										Properties.Settings.Default.maxNumberInLine, 
										Properties.Settings.Default.maxWordsInLine 
				);

				var s = g.Generate(
								saveFileDialog1.FileName,
								Properties.Settings.Default.fileSizeMb,
								progressBar1
							);

				labelGenTime.Text = g.getGenerationTime().ToString();
               
			}

		}

		private void maskedTextBoxMaxWordsInLine_MaskInputRejected( object sender, MaskInputRejectedEventArgs e ) {

		}

		private void textBoxMaxWords_TextChanged( object sender, EventArgs e ) {
			try {
				Properties.Settings.Default.maxWordsInLine = Convert.ToInt32( textBoxMaxWords.Text );
			}catch {
				//MessageBox.Show( "Enter 'Max words in line'" );
			}
		}

		private void textBoxMaxNumber_TextChanged( object sender, EventArgs e ) {
			try {
				Properties.Settings.Default.maxNumberInLine = Convert.ToInt32( textBoxMaxNumber.Text );
			}
			catch {
				//MessageBox.Show( "Enter 'Max number value in line'" );
			}
		}

		private void textBoxSizeMb_TextChanged( object sender, EventArgs e ) {
			try {
				Properties.Settings.Default.fileSizeMb = Convert.ToInt32( textBoxSizeMb.Text );
			}
			catch {
				//MessageBox.Show( "Enter 'Max file size Mb'" );
			}
		}

		private void button1_Click( object sender, EventArgs e ) {
			var s= new Sorter();
			var l = s.test();
			
		}
	}
}
