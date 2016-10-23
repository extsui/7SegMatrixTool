namespace _7SegMatrixTool
{
    partial class ToolForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonStartConvert = new System.Windows.Forms.Button();
            this.buttonSelectOutputFile = new System.Windows.Forms.Button();
            this.numericUpDownConvertNum = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSelectOutputFolder = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.buttonSelectInputFolder = new System.Windows.Forms.Button();
            this.textBoxInputFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOutputFolder = new System.Windows.Forms.TextBox();
            this.textBoxInputPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOutputPrefix = new System.Windows.Forms.TextBox();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialogSelectInput = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogSelectOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialogSelectOutput = new System.Windows.Forms.SaveFileDialog();
            this.pictureBoxIplInput = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.pictureBoxIplOutput = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConvertNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.buttonStartConvert);
            this.groupBox2.Controls.Add(this.buttonSelectOutputFile);
            this.groupBox2.Controls.Add(this.numericUpDownConvertNum);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.buttonSelectOutputFolder);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxOutputFile);
            this.groupBox2.Controls.Add(this.buttonSelectInputFolder);
            this.groupBox2.Controls.Add(this.textBoxInputFolder);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxOutputFolder);
            this.groupBox2.Controls.Add(this.textBoxInputPrefix);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxOutputPrefix);
            this.groupBox2.Location = new System.Drawing.Point(12, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "連番画像変換 (*.bmp ⇒ *.bmp/*.7sm)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(568, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "7セグメントマトリクス専用形式";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(161, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "上限10,000枚 (No.0000-9999)";
            // 
            // buttonStartConvert
            // 
            this.buttonStartConvert.Location = new System.Drawing.Point(636, 94);
            this.buttonStartConvert.Name = "buttonStartConvert";
            this.buttonStartConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonStartConvert.TabIndex = 9;
            this.buttonStartConvert.Text = "変換開始";
            this.buttonStartConvert.UseVisualStyleBackColor = true;
            this.buttonStartConvert.Click += new System.EventHandler(this.buttonStartConvert_Click);
            // 
            // buttonSelectOutputFile
            // 
            this.buttonSelectOutputFile.Location = new System.Drawing.Point(486, 68);
            this.buttonSelectOutputFile.Name = "buttonSelectOutputFile";
            this.buttonSelectOutputFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectOutputFile.TabIndex = 7;
            this.buttonSelectOutputFile.Text = "選択";
            this.buttonSelectOutputFile.UseVisualStyleBackColor = true;
            this.buttonSelectOutputFile.Click += new System.EventHandler(this.buttonSelectOutputFile_Click);
            // 
            // numericUpDownConvertNum
            // 
            this.numericUpDownConvertNum.Location = new System.Drawing.Point(80, 96);
            this.numericUpDownConvertNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownConvertNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownConvertNum.Name = "numericUpDownConvertNum";
            this.numericUpDownConvertNum.Size = new System.Drawing.Size(74, 19);
            this.numericUpDownConvertNum.TabIndex = 8;
            this.numericUpDownConvertNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "変換枚数";
            // 
            // buttonSelectOutputFolder
            // 
            this.buttonSelectOutputFolder.Location = new System.Drawing.Point(486, 42);
            this.buttonSelectOutputFolder.Name = "buttonSelectOutputFolder";
            this.buttonSelectOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectOutputFolder.TabIndex = 4;
            this.buttonSelectOutputFolder.Text = "選択";
            this.buttonSelectOutputFolder.UseVisualStyleBackColor = true;
            this.buttonSelectOutputFolder.Click += new System.EventHandler(this.buttonSelectOutputFolder_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "出力ファイル";
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Location = new System.Drawing.Point(80, 70);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.Size = new System.Drawing.Size(400, 19);
            this.textBoxOutputFile.TabIndex = 6;
            // 
            // buttonSelectInputFolder
            // 
            this.buttonSelectInputFolder.Location = new System.Drawing.Point(486, 16);
            this.buttonSelectInputFolder.Name = "buttonSelectInputFolder";
            this.buttonSelectInputFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectInputFolder.TabIndex = 1;
            this.buttonSelectInputFolder.Text = "選択";
            this.buttonSelectInputFolder.UseVisualStyleBackColor = true;
            this.buttonSelectInputFolder.Click += new System.EventHandler(this.buttonSelectInputFolder_Click);
            // 
            // textBoxInputFolder
            // 
            this.textBoxInputFolder.Location = new System.Drawing.Point(80, 18);
            this.textBoxInputFolder.Name = "textBoxInputFolder";
            this.textBoxInputFolder.Size = new System.Drawing.Size(400, 19);
            this.textBoxInputFolder.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "出力フォルダ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "入力フォルダ";
            // 
            // textBoxOutputFolder
            // 
            this.textBoxOutputFolder.Location = new System.Drawing.Point(80, 44);
            this.textBoxOutputFolder.Name = "textBoxOutputFolder";
            this.textBoxOutputFolder.Size = new System.Drawing.Size(399, 19);
            this.textBoxOutputFolder.TabIndex = 3;
            // 
            // textBoxInputPrefix
            // 
            this.textBoxInputPrefix.Location = new System.Drawing.Point(636, 18);
            this.textBoxInputPrefix.Name = "textBoxInputPrefix";
            this.textBoxInputPrefix.Size = new System.Drawing.Size(75, 19);
            this.textBoxInputPrefix.TabIndex = 2;
            this.textBoxInputPrefix.Text = "s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "プレフィックス";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(568, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "プレフィックス";
            // 
            // textBoxOutputPrefix
            // 
            this.textBoxOutputPrefix.Location = new System.Drawing.Point(635, 44);
            this.textBoxOutputPrefix.Name = "textBoxOutputPrefix";
            this.textBoxOutputPrefix.Size = new System.Drawing.Size(75, 19);
            this.textBoxOutputPrefix.TabIndex = 5;
            this.textBoxOutputPrefix.Text = "d";
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.LargeChange = 10;
            this.trackBarThreshold.Location = new System.Drawing.Point(340, 46);
            this.trackBarThreshold.Maximum = 100;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarThreshold.Size = new System.Drawing.Size(45, 225);
            this.trackBarThreshold.SmallChange = 10;
            this.trackBarThreshold.TabIndex = 1;
            this.trackBarThreshold.TickFrequency = 10;
            this.trackBarThreshold.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarThreshold.Value = 50;
            this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBoxIplOutput);
            this.groupBox1.Controls.Add(this.pictureBoxIplInput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonSaveFile);
            this.groupBox1.Controls.Add(this.buttonOpenFile);
            this.groupBox1.Controls.Add(this.trackBarThreshold);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "パラメータ調整";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(524, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "出力画像";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(77, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "入力画像 (640x480フルカラービットマップ)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "閾値";
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Location = new System.Drawing.Point(636, 277);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFile.TabIndex = 2;
            this.buttonSaveFile.Text = "保存";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Click += new System.EventHandler(this.buttonSaveFile_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(259, 277);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "開く";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "ビットマップファイル|*.bmp";
            this.openFileDialog.InitialDirectory = "C:\\";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "ビットマップファイル|*.bmp";
            // 
            // saveFileDialogSelectOutput
            // 
            this.saveFileDialogSelectOutput.Filter = "7セグメントマトリクス専用形式|*.7sm";
            // 
            // pictureBoxIplInput
            // 
            this.pictureBoxIplInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIplInput.Location = new System.Drawing.Point(14, 31);
            this.pictureBoxIplInput.Name = "pictureBoxIplInput";
            this.pictureBoxIplInput.Size = new System.Drawing.Size(320, 240);
            this.pictureBoxIplInput.TabIndex = 13;
            this.pictureBoxIplInput.TabStop = false;
            // 
            // pictureBoxIplOutput
            // 
            this.pictureBoxIplOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIplOutput.Location = new System.Drawing.Point(390, 31);
            this.pictureBoxIplOutput.Name = "pictureBoxIplOutput";
            this.pictureBoxIplOutput.Size = new System.Drawing.Size(320, 240);
            this.pictureBoxIplOutput.TabIndex = 14;
            this.pictureBoxIplOutput.TabStop = false;
            // 
            // ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ToolForm";
            this.Text = "7SegMatrixTool";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConvertNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarThreshold;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOutputPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInputPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxInputFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownConvertNum;
        private System.Windows.Forms.Button buttonStartConvert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOutputFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxOutputFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSelectInputFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectOutputFolder;
        private System.Windows.Forms.Button buttonSelectOutputFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelectInput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelectOutput;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSelectOutput;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIplOutput;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIplInput;
    }
}

