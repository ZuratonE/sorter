namespace SorterApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.buttonSelectDictionaryFile = new System.Windows.Forms.Button();
			this.labelDictionaryFileName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonGenerate = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.labelGenTime = new System.Windows.Forms.Label();
			this.textBoxMaxWords = new System.Windows.Forms.TextBox();
			this.textBoxMaxNumber = new System.Windows.Forms.TextBox();
			this.textBoxSizeMb = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonSelectDictionaryFile
			// 
			this.buttonSelectDictionaryFile.Location = new System.Drawing.Point(12, 15);
			this.buttonSelectDictionaryFile.Name = "buttonSelectDictionaryFile";
			this.buttonSelectDictionaryFile.Size = new System.Drawing.Size(185, 23);
			this.buttonSelectDictionaryFile.TabIndex = 2;
			this.buttonSelectDictionaryFile.Text = "Select Dictionary File";
			this.buttonSelectDictionaryFile.UseVisualStyleBackColor = true;
			this.buttonSelectDictionaryFile.Click += new System.EventHandler(this.buttonSelectDictionaryFile_Click);
			// 
			// labelDictionaryFileName
			// 
			this.labelDictionaryFileName.AutoSize = true;
			this.labelDictionaryFileName.Location = new System.Drawing.Point(12, 41);
			this.labelDictionaryFileName.Name = "labelDictionaryFileName";
			this.labelDictionaryFileName.Size = new System.Drawing.Size(35, 13);
			this.labelDictionaryFileName.TabIndex = 3;
			this.labelDictionaryFileName.Text = "label1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Max words in line";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "File size to generate, Mb";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Max number value in line";
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Location = new System.Drawing.Point(12, 152);
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(230, 23);
			this.buttonGenerate.TabIndex = 10;
			this.buttonGenerate.Text = "Generate";
			this.buttonGenerate.UseVisualStyleBackColor = true;
			this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 297);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(539, 25);
			this.progressBar1.TabIndex = 11;
			// 
			// labelGenTime
			// 
			this.labelGenTime.AutoSize = true;
			this.labelGenTime.Location = new System.Drawing.Point(12, 178);
			this.labelGenTime.Name = "labelGenTime";
			this.labelGenTime.Size = new System.Drawing.Size(10, 13);
			this.labelGenTime.TabIndex = 12;
			this.labelGenTime.Text = " ";
			// 
			// textBoxMaxWords
			// 
			this.textBoxMaxWords.Location = new System.Drawing.Point(142, 74);
			this.textBoxMaxWords.MaxLength = 3;
			this.textBoxMaxWords.Name = "textBoxMaxWords";
			this.textBoxMaxWords.Size = new System.Drawing.Size(100, 20);
			this.textBoxMaxWords.TabIndex = 13;
			this.textBoxMaxWords.TextChanged += new System.EventHandler(this.textBoxMaxWords_TextChanged);
			// 
			// textBoxMaxNumber
			// 
			this.textBoxMaxNumber.Location = new System.Drawing.Point(142, 100);
			this.textBoxMaxNumber.MaxLength = 5;
			this.textBoxMaxNumber.Name = "textBoxMaxNumber";
			this.textBoxMaxNumber.Size = new System.Drawing.Size(100, 20);
			this.textBoxMaxNumber.TabIndex = 14;
			this.textBoxMaxNumber.TextChanged += new System.EventHandler(this.textBoxMaxNumber_TextChanged);
			// 
			// textBoxSizeMb
			// 
			this.textBoxSizeMb.Location = new System.Drawing.Point(142, 126);
			this.textBoxSizeMb.MaxLength = 6;
			this.textBoxSizeMb.Name = "textBoxSizeMb";
			this.textBoxSizeMb.Size = new System.Drawing.Size(100, 20);
			this.textBoxSizeMb.TabIndex = 15;
			this.textBoxSizeMb.TextChanged += new System.EventHandler(this.textBoxSizeMb_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 334);
			this.Controls.Add(this.textBoxSizeMb);
			this.Controls.Add(this.textBoxMaxNumber);
			this.Controls.Add(this.textBoxMaxWords);
			this.Controls.Add(this.labelGenTime);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.buttonGenerate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelDictionaryFileName);
			this.Controls.Add(this.buttonSelectDictionaryFile);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectDictionaryFile;
        private System.Windows.Forms.Label labelDictionaryFileName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonGenerate;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelGenTime;
		private System.Windows.Forms.TextBox textBoxMaxNumber;
		private System.Windows.Forms.TextBox textBoxSizeMb;
		protected internal System.Windows.Forms.TextBox textBoxMaxWords;
	}
}

