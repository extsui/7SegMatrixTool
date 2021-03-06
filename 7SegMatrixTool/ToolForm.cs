﻿using System;
using System.IO;
using System.Windows.Forms;

namespace _7SegMatrixTool
{
    public partial class ToolForm : Form
    {
        private _7SegMatrix m7SegMatrix = null;

        public ToolForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// サンプル画像の変換を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolForm_Load(object sender, EventArgs e)
        {
            m7SegMatrix = new _7SegMatrix(Properties.Resources.SAMPLE);
            drawConvertPicture(m7SegMatrix);
        }

        /********************************************************************************
         *  パラメータ調整
         ********************************************************************************/

        /// <summary>
        /// パラメータ調整用のビットマップ画像を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogBmp.ShowDialog() == DialogResult.OK)
            {
                m7SegMatrix = new _7SegMatrix(openFileDialogBmp.FileName);
                drawConvertPicture(m7SegMatrix);
            }
        }

        /// <summary>
        /// 画像変換時の閾値を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            labelThreshold.Text = trackBarThreshold.Value.ToString("D");
            m7SegMatrix.convert(trackBarThreshold.Value);
            m7SegMatrix.drawOutputPicture(pictureBoxIplOutput);
        }

        /// <summary>
        /// 押下時に白黒変換を行う(デフォルトで指定)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonWhiteBlack_Click(object sender, EventArgs e)
        {
            trackBarThreshold.Enabled = true;
            m7SegMatrix.convert(trackBarThreshold.Value);
            m7SegMatrix.drawOutputPicture(pictureBoxIplOutput);
        }

        /// <summary>
        /// 押下時にカラー変換を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonColor_Click(object sender, EventArgs e)
        {
            // TBD: 閾値はカラー変換時に使用しない予定
            trackBarThreshold.Enabled = false;

            MessageBox.Show("Not Implemented.");
        }

        /// <summary>
        /// パラメータ調整用に生成したビットマップ画像を保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                m7SegMatrix.save(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// 入力画像⇒出力画像変換を表示する
        /// </summary>
        /// <param name="matrix">7セグマトリクスのインスタンス</param>
        private void drawConvertPicture(_7SegMatrix matrix)
        {
            matrix.drawInputPicture(pictureBoxIplInput);
            matrix.convert(trackBarThreshold.Value);
            matrix.drawOutputPicture(pictureBoxIplOutput);
        }

        /********************************************************************************
         *  連番画像変換
         ********************************************************************************/

        /// <summary>
        /// 連番画像の置いてある入力フォルダを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectInputFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSelectInput.ShowDialog() == DialogResult.OK)
            {
                textBoxInputFolder.Text = folderBrowserDialogSelectInput.SelectedPath;
            }
        }

        /// <summary>
        /// 出力フォルダを指定するか否か
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxOutputFolder_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOutputFolder.Enabled = buttonSelectOutputFolder.Enabled = textBoxOutputPrefix.Enabled = checkBoxOutputFolder.Checked;
        }
        
        /// <summary>
        /// 連番画像変換後の出力フォルダを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectOutputFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSelectOutput.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputFolder.Text = folderBrowserDialogSelectOutput.SelectedPath;
            }
        }

        /// <summary>
        /// 出力ファイルを指定するか否か
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox7smOutputFile_CheckedChanged(object sender, EventArgs e)
        {
            textBox7smOutputFile.Enabled = buttonSelect7smOutputFile.Enabled = checkBox7smOutputFile.Checked;
        }
        
        /// <summary>
        /// 連番画像変換後の出力ファイル(専用フォーマット)を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialogSelectOutput.ShowDialog() == DialogResult.OK)
            {
                textBox7smOutputFile.Text = saveFileDialogSelectOutput.FileName;
            }
        }
 
        /// <summary>
        /// 連番画像の変換を開始する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartConvert_Click(object sender, EventArgs e)
        {
            if (!checkValidInputForConvert())
            {
                return;
            }

            string inputFileNameHeader = textBoxInputFolder.Text + "\\" + textBoxInputPrefix.Text;
            string outputFileNameHeader = textBoxOutputFolder.Text + "\\" + textBoxOutputPrefix.Text;
            string output7smFileName = textBox7smOutputFile.Text;
            int convertCount = (int)numericUpDownConvertCount.Value;

            string confirmMessage = createConfirmMessage(inputFileNameHeader, outputFileNameHeader, output7smFileName, convertCount);
            if (MessageBox.Show(confirmMessage, "確認", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                ProgressForm f = new ProgressForm();

                f.Owner = this;
                f.Show();

                this.Enabled = false;

                f.Title = "連番画像変換中";
                f.ProgressCount = convertCount;

                FileStream fs = null;
                BinaryWriter bw = null;
                
                if (checkBox7smOutputFile.Checked)
                {
                    fs = new FileStream(output7smFileName, FileMode.Create);
                    bw = new BinaryWriter(fs);
                }

                for (int i = 0; i < convertCount; i++)
                {
                    if (f.IsCanceled)
                    {
                        break;
                    }

                    string inputFileName = inputFileNameHeader + i.ToString("D4") + ".bmp";
                    string outputFileName = outputFileNameHeader + i.ToString("D4") + ".bmp";
                    _7SegMatrix matrix = new _7SegMatrix(inputFileName);
                    matrix.convert(trackBarThreshold.Value);

                    if (checkBoxOutputFolder.Checked)
                    {
                        matrix.save(outputFileName);
                    }

                    if (checkBox7smOutputFile.Checked)
                    {
                        byte[] _7SegPattern = matrix.get7SegPattern();
                        bw.Write(_7SegPattern);
                    }
                    
                    f.ProgressValue = i + 1;
                    Application.DoEvents();
                }

                if (checkBox7smOutputFile.Checked)
                {
                    bw.Close();
                    fs.Close();
                }

                if (f.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("完了しました");
                }
                else
                {
                    MessageBox.Show("中断しました");
                }

                this.Activate();
                f.Close();

                this.Enabled = true;
            }
        }

        /// <summary>
        /// 連番画像変換時の確認メッセージの作成
        /// </summary>
        /// <param name="inputFileNameHeader"></param>
        /// <param name="outputFileNameHeader"></param>
        /// <param name="output7smFileName"></param>
        /// <param name="convertCount"></param>
        /// <returns></returns>
        private string createConfirmMessage(string inputFileNameHeader, string outputFileNameHeader, string output7smFileName, int convertCount)
        {
            string confirmMessage = "入力ファイル: " + inputFileNameHeader + "0000.bmp" + "...\n";
            if (checkBoxOutputFolder.Checked)
            {
                confirmMessage += "出力ファイル: " + outputFileNameHeader + "0000.bmp" + "...\n";
            }
            if (checkBox7smOutputFile.Checked)
            {
                confirmMessage += "出力ファイル(7sm): " + output7smFileName + "\n";
            }
            confirmMessage += "変換枚数: " + convertCount + "\n";
            return confirmMessage;
        }

        /// <summary>
        /// 連番画像変換用の入力チェック
        /// 
        /// 以下のいずれかの場合、エラーとなる
        /// ・入力フォルダが指定されていない
        /// ・出力フォルダと出力ファイルのどちらもチェックされていない
        /// ・出力フォルダがチェックされているのに出力フォルダが指定されていない
        /// ・出力ファイルがチェックされているのに出力ファイルが指定されていない
        /// </summary>
        /// <returns>OK:true/NG:false</returns>
        private bool checkValidInputForConvert()
        {
            if (textBoxInputFolder.Text == "")
            {
                MessageBox.Show("入力フォルダを指定してください");
                return false;
            }
            if ((checkBoxOutputFolder.Checked == false) &&
                (!checkBox7smOutputFile.Checked))
            {
                MessageBox.Show("出力フォルダ/出力ファイルのいずれかを指定してください");
                return false;
            }
            if ((checkBoxOutputFolder.Checked) &&
                (textBoxOutputFolder.Text == ""))
            {
                MessageBox.Show("出力フォルダを指定してください");
                return false;
            }
            if ((checkBox7smOutputFile.Checked) &&
                (textBox7smOutputFile.Text == ""))
            {
                MessageBox.Show("出力ファイルを指定してください");
                return false;
            }
            return true;
        }

        /********************************************************************************
         *  7セグメントマトリクス専用形式テスト再生
         ********************************************************************************/

        /// <summary>
        /// 再生ファイルを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelect7smFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog7sm.ShowDialog() == DialogResult.OK)
            {
                textBox7smInputFile.Text = openFileDialog7sm.FileName;
            }
        }

        /// <summary>
        /// 音声ファイルを使用するか否か
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxWaveInputFile_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWaveInputFile.Enabled = buttonSelectWaveFile.Enabled = checkBoxWaveInputFile.Checked;
        }

        /// <summary>
        /// 音声ファイルを選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectWaveFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogWave.ShowDialog() == DialogResult.OK)
            {
                textBoxWaveInputFile.Text = openFileDialogWave.FileName;
            }
        }

        /// <summary>
        /// 再生を開始する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!checkValidInputForPlay())
            {
                return;
            }

            PlayerForm pf = null;
            int fps = (int)numericUpDownFPS.Value;

            if (checkBoxWaveInputFile.Checked)
            {
                pf = new PlayerForm(textBox7smInputFile.Text, fps, textBoxWaveInputFile.Text);
            }
            else
            {
                pf = new PlayerForm(textBox7smInputFile.Text, fps);
            }

            pf.ShowDialog();
            pf.Dispose();
        }

        /// <summary>
        /// 再生用の入力チェック
        /// 
        /// 以下のいずれかの場合、エラーとなる
        /// ・入力ファイルが指定されていない
        /// ・音声ファイルがチェックされているのに音声ファイルが指定されていない
        /// </summary>
        /// <returns>OK:true/NG:false</returns>
        private bool checkValidInputForPlay()
        {
            if (textBox7smInputFile.Text == "")
            {
                MessageBox.Show("入力ファイルを指定してください");
                return false;
            }
            if ((checkBoxWaveInputFile.Checked) &&
                (textBoxWaveInputFile.Text == ""))
            {
                MessageBox.Show("音声ファイルを指定してください");
                return false;
            }
            return true;
        }
    }
}
