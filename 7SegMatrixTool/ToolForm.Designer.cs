using OpenCvSharp;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox7SegMatrixOutputFile = new System.Windows.Forms.CheckBox();
            this.checkBoxOutputFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxInputFolder = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonSelect7SegMatrixOutputFile = new System.Windows.Forms.Button();
            this.numericUpDownConvertNum = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSelectOutputFolder = new System.Windows.Forms.Button();
            this.textBox7SegMatrixOutputFile = new System.Windows.Forms.TextBox();
            this.buttonSelectInputFolder = new System.Windows.Forms.Button();
            this.textBoxInputFolder = new System.Windows.Forms.TextBox();
            this.textBoxOutputFolder = new System.Windows.Forms.TextBox();
            this.textBoxInputPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOutputPrefix = new System.Windows.Forms.TextBox();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonColor = new System.Windows.Forms.RadioButton();
            this.radioButtonWhiteBlack = new System.Windows.Forms.RadioButton();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.pictureBoxIplOutput = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.pictureBoxIplInput = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialogBmp = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialogSelectInput = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogSelectOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialogSelectOutput = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownFPS = new System.Windows.Forms.NumericUpDown();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.checkBoxWaveInputFile = new System.Windows.Forms.CheckBox();
            this.buttonSelectWaveFile = new System.Windows.Forms.Button();
            this.textBoxWaveInputFile = new System.Windows.Forms.TextBox();
            this.checkBox7smInputFile = new System.Windows.Forms.CheckBox();
            this.buttonSelect7smFile = new System.Windows.Forms.Button();
            this.textBox7smInputFile = new System.Windows.Forms.TextBox();
            this.openFileDialog7sm = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogWave = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConvertNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplInput)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox7SegMatrixOutputFile);
            this.groupBox2.Controls.Add(this.checkBoxOutputFolder);
            this.groupBox2.Controls.Add(this.checkBoxInputFolder);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.buttonConvert);
            this.groupBox2.Controls.Add(this.buttonSelect7SegMatrixOutputFile);
            this.groupBox2.Controls.Add(this.numericUpDownConvertNum);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.buttonSelectOutputFolder);
            this.groupBox2.Controls.Add(this.textBox7SegMatrixOutputFile);
            this.groupBox2.Controls.Add(this.buttonSelectInputFolder);
            this.groupBox2.Controls.Add(this.textBoxInputFolder);
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
            // checkBox7SegMatrixOutputFile
            // 
            this.checkBox7SegMatrixOutputFile.AutoSize = true;
            this.checkBox7SegMatrixOutputFile.Location = new System.Drawing.Point(15, 72);
            this.checkBox7SegMatrixOutputFile.Name = "checkBox7SegMatrixOutputFile";
            this.checkBox7SegMatrixOutputFile.Size = new System.Drawing.Size(82, 16);
            this.checkBox7SegMatrixOutputFile.TabIndex = 8;
            this.checkBox7SegMatrixOutputFile.Text = "出力ファイル";
            this.checkBox7SegMatrixOutputFile.UseVisualStyleBackColor = true;
            this.checkBox7SegMatrixOutputFile.CheckedChanged += new System.EventHandler(this.checkBox7SegMatrixOutputFile_CheckedChanged);
            // 
            // checkBoxOutputFolder
            // 
            this.checkBoxOutputFolder.AutoSize = true;
            this.checkBoxOutputFolder.Location = new System.Drawing.Point(15, 46);
            this.checkBoxOutputFolder.Name = "checkBoxOutputFolder";
            this.checkBoxOutputFolder.Size = new System.Drawing.Size(83, 16);
            this.checkBoxOutputFolder.TabIndex = 4;
            this.checkBoxOutputFolder.Text = "出力フォルダ";
            this.checkBoxOutputFolder.UseVisualStyleBackColor = true;
            this.checkBoxOutputFolder.CheckedChanged += new System.EventHandler(this.checkBoxOutputFolder_CheckedChanged);
            // 
            // checkBoxInputFolder
            // 
            this.checkBoxInputFolder.AutoCheck = false;
            this.checkBoxInputFolder.AutoSize = true;
            this.checkBoxInputFolder.Checked = true;
            this.checkBoxInputFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInputFolder.ForeColor = System.Drawing.Color.Red;
            this.checkBoxInputFolder.Location = new System.Drawing.Point(15, 20);
            this.checkBoxInputFolder.Name = "checkBoxInputFolder";
            this.checkBoxInputFolder.Size = new System.Drawing.Size(83, 16);
            this.checkBoxInputFolder.TabIndex = 0;
            this.checkBoxInputFolder.Text = "入力フォルダ";
            this.checkBoxInputFolder.UseVisualStyleBackColor = true;
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
            this.label11.Location = new System.Drawing.Point(182, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "上限10,000枚 (No.0000-9999)";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(636, 94);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 12;
            this.buttonConvert.Text = "変換";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonStartConvert_Click);
            // 
            // buttonSelect7SegMatrixOutputFile
            // 
            this.buttonSelect7SegMatrixOutputFile.Enabled = false;
            this.buttonSelect7SegMatrixOutputFile.Location = new System.Drawing.Point(486, 68);
            this.buttonSelect7SegMatrixOutputFile.Name = "buttonSelect7SegMatrixOutputFile";
            this.buttonSelect7SegMatrixOutputFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect7SegMatrixOutputFile.TabIndex = 10;
            this.buttonSelect7SegMatrixOutputFile.Text = "選択";
            this.buttonSelect7SegMatrixOutputFile.UseVisualStyleBackColor = true;
            this.buttonSelect7SegMatrixOutputFile.Click += new System.EventHandler(this.buttonSelectOutputFile_Click);
            // 
            // numericUpDownConvertNum
            // 
            this.numericUpDownConvertNum.Location = new System.Drawing.Point(101, 96);
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
            this.numericUpDownConvertNum.TabIndex = 11;
            this.numericUpDownConvertNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "変換枚数";
            // 
            // buttonSelectOutputFolder
            // 
            this.buttonSelectOutputFolder.Enabled = false;
            this.buttonSelectOutputFolder.Location = new System.Drawing.Point(486, 42);
            this.buttonSelectOutputFolder.Name = "buttonSelectOutputFolder";
            this.buttonSelectOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectOutputFolder.TabIndex = 6;
            this.buttonSelectOutputFolder.Text = "選択";
            this.buttonSelectOutputFolder.UseVisualStyleBackColor = true;
            this.buttonSelectOutputFolder.Click += new System.EventHandler(this.buttonSelectOutputFolder_Click);
            // 
            // textBox7SegMatrixOutputFile
            // 
            this.textBox7SegMatrixOutputFile.Enabled = false;
            this.textBox7SegMatrixOutputFile.Location = new System.Drawing.Point(101, 70);
            this.textBox7SegMatrixOutputFile.Name = "textBox7SegMatrixOutputFile";
            this.textBox7SegMatrixOutputFile.Size = new System.Drawing.Size(379, 19);
            this.textBox7SegMatrixOutputFile.TabIndex = 9;
            // 
            // buttonSelectInputFolder
            // 
            this.buttonSelectInputFolder.Location = new System.Drawing.Point(486, 16);
            this.buttonSelectInputFolder.Name = "buttonSelectInputFolder";
            this.buttonSelectInputFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectInputFolder.TabIndex = 2;
            this.buttonSelectInputFolder.Text = "選択";
            this.buttonSelectInputFolder.UseVisualStyleBackColor = true;
            this.buttonSelectInputFolder.Click += new System.EventHandler(this.buttonSelectInputFolder_Click);
            // 
            // textBoxInputFolder
            // 
            this.textBoxInputFolder.Location = new System.Drawing.Point(101, 18);
            this.textBoxInputFolder.Name = "textBoxInputFolder";
            this.textBoxInputFolder.Size = new System.Drawing.Size(379, 19);
            this.textBoxInputFolder.TabIndex = 1;
            // 
            // textBoxOutputFolder
            // 
            this.textBoxOutputFolder.Enabled = false;
            this.textBoxOutputFolder.Location = new System.Drawing.Point(101, 44);
            this.textBoxOutputFolder.Name = "textBoxOutputFolder";
            this.textBoxOutputFolder.Size = new System.Drawing.Size(378, 19);
            this.textBoxOutputFolder.TabIndex = 5;
            // 
            // textBoxInputPrefix
            // 
            this.textBoxInputPrefix.Location = new System.Drawing.Point(636, 18);
            this.textBoxInputPrefix.Name = "textBoxInputPrefix";
            this.textBoxInputPrefix.Size = new System.Drawing.Size(75, 19);
            this.textBoxInputPrefix.TabIndex = 3;
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
            this.textBoxOutputPrefix.Enabled = false;
            this.textBoxOutputPrefix.Location = new System.Drawing.Point(635, 44);
            this.textBoxOutputPrefix.Name = "textBoxOutputPrefix";
            this.textBoxOutputPrefix.Size = new System.Drawing.Size(75, 19);
            this.textBoxOutputPrefix.TabIndex = 7;
            this.textBoxOutputPrefix.Text = "d";
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.Enabled = false;
            this.trackBarThreshold.LargeChange = 10;
            this.trackBarThreshold.Location = new System.Drawing.Point(340, 46);
            this.trackBarThreshold.Maximum = 100;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarThreshold.Size = new System.Drawing.Size(45, 211);
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
            this.groupBox1.Controls.Add(this.radioButtonColor);
            this.groupBox1.Controls.Add(this.radioButtonWhiteBlack);
            this.groupBox1.Controls.Add(this.labelThreshold);
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
            // radioButtonColor
            // 
            this.radioButtonColor.AutoSize = true;
            this.radioButtonColor.Location = new System.Drawing.Point(447, 280);
            this.radioButtonColor.Name = "radioButtonColor";
            this.radioButtonColor.Size = new System.Drawing.Size(50, 16);
            this.radioButtonColor.TabIndex = 3;
            this.radioButtonColor.Text = "カラー";
            this.radioButtonColor.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhiteBlack
            // 
            this.radioButtonWhiteBlack.AutoSize = true;
            this.radioButtonWhiteBlack.Checked = true;
            this.radioButtonWhiteBlack.Location = new System.Drawing.Point(394, 280);
            this.radioButtonWhiteBlack.Name = "radioButtonWhiteBlack";
            this.radioButtonWhiteBlack.Size = new System.Drawing.Size(47, 16);
            this.radioButtonWhiteBlack.TabIndex = 2;
            this.radioButtonWhiteBlack.TabStop = true;
            this.radioButtonWhiteBlack.Text = "白黒";
            this.radioButtonWhiteBlack.UseVisualStyleBackColor = true;
            // 
            // labelThreshold
            // 
            this.labelThreshold.Location = new System.Drawing.Point(349, 257);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(23, 12);
            this.labelThreshold.TabIndex = 15;
            this.labelThreshold.Text = "50";
            this.labelThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // pictureBoxIplInput
            // 
            this.pictureBoxIplInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIplInput.Location = new System.Drawing.Point(14, 31);
            this.pictureBoxIplInput.Name = "pictureBoxIplInput";
            this.pictureBoxIplInput.Size = new System.Drawing.Size(320, 240);
            this.pictureBoxIplInput.TabIndex = 13;
            this.pictureBoxIplInput.TabStop = false;
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
            this.buttonSaveFile.Enabled = false;
            this.buttonSaveFile.Location = new System.Drawing.Point(636, 277);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFile.TabIndex = 4;
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
            // openFileDialogBmp
            // 
            this.openFileDialogBmp.Filter = "ビットマップファイル|*.bmp";
            this.openFileDialogBmp.InitialDirectory = "C:\\";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "ビットマップファイル|*.bmp";
            // 
            // saveFileDialogSelectOutput
            // 
            this.saveFileDialogSelectOutput.DefaultExt = "7sm";
            this.saveFileDialogSelectOutput.Filter = "すべてのファイル|*.*";
            this.saveFileDialogSelectOutput.SupportMultiDottedExtensions = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.numericUpDownFPS);
            this.groupBox3.Controls.Add(this.buttonPlay);
            this.groupBox3.Controls.Add(this.checkBoxWaveInputFile);
            this.groupBox3.Controls.Add(this.buttonSelectWaveFile);
            this.groupBox3.Controls.Add(this.textBoxWaveInputFile);
            this.groupBox3.Controls.Add(this.checkBox7smInputFile);
            this.groupBox3.Controls.Add(this.buttonSelect7smFile);
            this.groupBox3.Controls.Add(this.textBox7smInputFile);
            this.groupBox3.Location = new System.Drawing.Point(13, 454);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(723, 74);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "7セグメントマトリクス専用形式テスト再生 (*.7sm/*.wav)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(568, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "FPS (1-60)";
            // 
            // numericUpDownFPS
            // 
            this.numericUpDownFPS.Location = new System.Drawing.Point(636, 18);
            this.numericUpDownFPS.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFPS.Name = "numericUpDownFPS";
            this.numericUpDownFPS.Size = new System.Drawing.Size(74, 19);
            this.numericUpDownFPS.TabIndex = 3;
            this.numericUpDownFPS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(636, 42);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "再生";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // checkBoxWaveInputFile
            // 
            this.checkBoxWaveInputFile.AutoSize = true;
            this.checkBoxWaveInputFile.Location = new System.Drawing.Point(15, 46);
            this.checkBoxWaveInputFile.Name = "checkBoxWaveInputFile";
            this.checkBoxWaveInputFile.Size = new System.Drawing.Size(82, 16);
            this.checkBoxWaveInputFile.TabIndex = 4;
            this.checkBoxWaveInputFile.Text = "音声ファイル";
            this.checkBoxWaveInputFile.UseVisualStyleBackColor = true;
            this.checkBoxWaveInputFile.CheckedChanged += new System.EventHandler(this.checkBoxWaveInputFile_CheckedChanged);
            // 
            // buttonSelectWaveFile
            // 
            this.buttonSelectWaveFile.Enabled = false;
            this.buttonSelectWaveFile.Location = new System.Drawing.Point(486, 42);
            this.buttonSelectWaveFile.Name = "buttonSelectWaveFile";
            this.buttonSelectWaveFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectWaveFile.TabIndex = 6;
            this.buttonSelectWaveFile.Text = "選択";
            this.buttonSelectWaveFile.UseVisualStyleBackColor = true;
            this.buttonSelectWaveFile.Click += new System.EventHandler(this.buttonSelectWaveFile_Click);
            // 
            // textBoxWaveInputFile
            // 
            this.textBoxWaveInputFile.Enabled = false;
            this.textBoxWaveInputFile.Location = new System.Drawing.Point(101, 44);
            this.textBoxWaveInputFile.Name = "textBoxWaveInputFile";
            this.textBoxWaveInputFile.Size = new System.Drawing.Size(379, 19);
            this.textBoxWaveInputFile.TabIndex = 5;
            // 
            // checkBox7smInputFile
            // 
            this.checkBox7smInputFile.AutoCheck = false;
            this.checkBox7smInputFile.AutoSize = true;
            this.checkBox7smInputFile.Checked = true;
            this.checkBox7smInputFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7smInputFile.ForeColor = System.Drawing.Color.Red;
            this.checkBox7smInputFile.Location = new System.Drawing.Point(15, 20);
            this.checkBox7smInputFile.Name = "checkBox7smInputFile";
            this.checkBox7smInputFile.Size = new System.Drawing.Size(82, 16);
            this.checkBox7smInputFile.TabIndex = 0;
            this.checkBox7smInputFile.Text = "入力ファイル";
            this.checkBox7smInputFile.UseVisualStyleBackColor = true;
            // 
            // buttonSelect7smFile
            // 
            this.buttonSelect7smFile.Location = new System.Drawing.Point(486, 16);
            this.buttonSelect7smFile.Name = "buttonSelect7smFile";
            this.buttonSelect7smFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect7smFile.TabIndex = 2;
            this.buttonSelect7smFile.Text = "選択";
            this.buttonSelect7smFile.UseVisualStyleBackColor = true;
            this.buttonSelect7smFile.Click += new System.EventHandler(this.buttonSelect7smFile_Click);
            // 
            // textBox7smInputFile
            // 
            this.textBox7smInputFile.Location = new System.Drawing.Point(101, 18);
            this.textBox7smInputFile.Name = "textBox7smInputFile";
            this.textBox7smInputFile.Size = new System.Drawing.Size(379, 19);
            this.textBox7smInputFile.TabIndex = 1;
            // 
            // openFileDialog7sm
            // 
            this.openFileDialog7sm.Filter = "7セグメントマトリクス専用形式ファイル|*.7sm";
            // 
            // openFileDialogWave
            // 
            this.openFileDialogWave.Filter = "Waveファイル|*.wav";
            // 
            // ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ToolForm";
            this.Text = "7SegMatrixTool";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConvertNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplInput)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPS)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxInputFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownConvertNum;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.TextBox textBoxOutputFolder;
        private System.Windows.Forms.TextBox textBox7SegMatrixOutputFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSelectInputFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectOutputFolder;
        private System.Windows.Forms.Button buttonSelect7SegMatrixOutputFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialogBmp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelectInput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelectOutput;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSelectOutput;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIplOutput;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIplInput;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.CheckBox checkBox7SegMatrixOutputFile;
        private System.Windows.Forms.CheckBox checkBoxOutputFolder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxWaveInputFile;
        private System.Windows.Forms.Button buttonSelectWaveFile;
        private System.Windows.Forms.TextBox textBoxWaveInputFile;
        private System.Windows.Forms.Button buttonSelect7smFile;
        private System.Windows.Forms.TextBox textBox7smInputFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownFPS;
        private System.Windows.Forms.RadioButton radioButtonColor;
        private System.Windows.Forms.RadioButton radioButtonWhiteBlack;
        private System.Windows.Forms.CheckBox checkBoxInputFolder;
        private System.Windows.Forms.CheckBox checkBox7smInputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog7sm;
        private System.Windows.Forms.OpenFileDialog openFileDialogWave;
    }
}

