using System;
using System.Windows.Forms;
using System.Threading;

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
        /// パラメータ調整用のビットマップ画像を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m7SegMatrix = new _7SegMatrix(openFileDialog.FileName);
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
        /// 連番画像変換後の出力ファイル(専用フォーマット)を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialogSelectOutput.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputFile.Text = saveFileDialogSelectOutput.FileName;
            }
        }

        /// <summary>
        /// 連番画像の変換を開始する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartConvert_Click(object sender, EventArgs e)
        {
            if ((textBoxInputFolder.Text.CompareTo("") != 0)  &&
                (textBoxOutputFolder.Text.CompareTo("") != 0) &&
                (textBoxOutputFile.Text.CompareTo("") != 0))
            {
                string inputFileNameHeader = textBoxInputFolder.Text + "\\" + textBoxInputPrefix.Text;
                string outputFileNameHeader = textBoxOutputFolder.Text + "\\" + textBoxOutputPrefix.Text;
                int conversionNumber = (int)numericUpDownConvertNum.Value;

                string help = "入力ファイル: " + inputFileNameHeader  + "0000.bmp" + "...\n" +
                              "出力ファイル: " + outputFileNameHeader + "0000.bmp" + "...\n" +
                              "変換枚数: " + conversionNumber + "\n";
                if (MessageBox.Show(help, "確認", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    ConversionProgressForm f = new ConversionProgressForm();
                    f.startConversion(inputFileNameHeader, outputFileNameHeader, conversionNumber);
                    f.ShowDialog();
                    f.Dispose();
                }
            }
            else
            {
                MessageBox.Show("入力フォルダ/出力フォルダ/出力ファイルを全て選択してください");
            }
        }
    }
}
