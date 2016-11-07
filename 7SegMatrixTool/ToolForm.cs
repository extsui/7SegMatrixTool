using System;
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
                m7SegMatrix.drawInputPicture(pictureBoxIplInput);
                m7SegMatrix.convert(trackBarThreshold.Value);
                m7SegMatrix.drawOutputPicture(pictureBoxIplOutput);

                // 読み込み後に使用できるコンポーネントを有効化
                trackBarThreshold.Enabled = true;
                buttonSaveFile.Enabled = true;
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
        private void checkBox7SegMatrixOutputFile_CheckedChanged(object sender, EventArgs e)
        {
            textBox7SegMatrixOutputFile.Enabled = buttonSelect7SegMatrixOutputFile.Enabled = checkBox7SegMatrixOutputFile.Checked;
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
                textBox7SegMatrixOutputFile.Text = saveFileDialogSelectOutput.FileName;
            }
        }
 
        /// <summary>
        /// 連番画像の変換を開始する
        /// 
        /// 以下のいずれかの場合、エラーとなる
        /// ・入力フォルダが指定されていない
        /// ・出力フォルダと出力ファイルのどちらもチェックされていない
        /// ・出力フォルダがチェックされているのに出力フォルダが指定されていない
        /// ・出力ファイルがチェックされているのに出力ファイルが指定されていない
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartConvert_Click(object sender, EventArgs e)
        {
            // TODO: 判定処理の追加
            // ...

            if ((textBoxInputFolder.Text != "") &&
                (textBoxOutputFolder.Text != "") &&
                (textBox7SegMatrixOutputFile.Text != ""))
            {
                string inputFileNameHeader = textBoxInputFolder.Text + "\\" + textBoxInputPrefix.Text;
                string outputFileNameHeader = textBoxOutputFolder.Text + "\\" + textBoxOutputPrefix.Text;
                int conversionNumber = (int)numericUpDownConvertNum.Value;

                string help = "入力ファイル: " + inputFileNameHeader + "0000.bmp" + "...\n" +
                              "出力ファイル: " + outputFileNameHeader + "0000.bmp" + "...\n" +
                              "変換枚数: " + conversionNumber + "\n";
                if (MessageBox.Show(help, "確認", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    ProgressForm f = new ProgressForm();

                    f.Owner = this;
                    f.Show();

                    this.Enabled = false;

                    f.Title = "連番画像変換中";
                    f.ProgressCount = conversionNumber;

                    for (int i = 0; i < conversionNumber; i++)
                    {
                        if (f.IsCanceled)
                        {
                            break;
                        }

                        string inputFileName = inputFileNameHeader + i.ToString("D4") + ".bmp";
                        string outputFileName = outputFileNameHeader + i.ToString("D4") + ".bmp";
                        _7SegMatrix matrix = new _7SegMatrix(inputFileName);
                        matrix.convert(trackBarThreshold.Value);
                        matrix.save(outputFileName);

                        f.ProgressValue = i + 1;
                        Application.DoEvents();
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
            else
            {
                MessageBox.Show("入力フォルダ/出力フォルダ/出力ファイルを全て選択してください");
            }
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
        /// 
        /// 以下のいずれかの場合、エラーとなる
        /// ・入力ファイルが指定されていない
        /// ・音声ファイルがチェックされているのに音声ファイルが指定されていない
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            PlayerForm pf = null;
            int fps = (int)numericUpDownFPS.Value;

            if (textBox7smInputFile.Text == "")
            {
                MessageBox.Show("入力ファイルを指定してください");
                return;
            }

            if (checkBoxWaveInputFile.Checked)
            {
                if (textBoxWaveInputFile.Text == "")
                {
                    MessageBox.Show("音声ファイルを指定してください");
                    return;
                }
                pf = new PlayerForm(textBox7smInputFile.Text, fps, textBoxWaveInputFile.Text);
            }
            else
            {
                pf = new PlayerForm(textBox7smInputFile.Text, fps);
            }

            pf.ShowDialog();
        }
    }
}
