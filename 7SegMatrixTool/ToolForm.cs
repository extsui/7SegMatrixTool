using System;
using System.Windows.Forms;
using System.Threading;

using System.IO;
using System.Threading.Tasks;
using System.Media;

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
                textBox7SegMatrixOutputFile.Text = saveFileDialogSelectOutput.FileName;
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
                (textBox7SegMatrixOutputFile.Text.CompareTo("") != 0))
            {
                string inputFileNameHeader = textBoxInputFolder.Text + "\\" + textBoxInputPrefix.Text;
                string outputFileNameHeader = textBoxOutputFolder.Text + "\\" + textBoxOutputPrefix.Text;
                int conversionNumber = (int)numericUpDownConvertNum.Value;

                string help = "入力ファイル: " + inputFileNameHeader  + "0000.bmp" + "...\n" +
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
        
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                FileStream fs = new FileStream(@"F:\Project\7SegMatrixMovieCutter\Scene\BADAPPLE.7SM", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                // 音声ファイル
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"F:\Project\7SegMatrixMovieCutter\Movie\original\badapple.wav");
                player.Play();

                while (fs.Position < fs.Length)
                {
                    byte[] _7SegPattern = br.ReadBytes(128);
                    _7SegMatrix matrix = new _7SegMatrix(_7SegPattern);
                    matrix.drawOutputPicture(pictureBoxIplOutput);

                    //textBoxInputFolder.Text = (fs.Position / 128).ToString();
                    System.Threading.Thread.Sleep(66);
                }

                // 音声ストップ
                player.Stop();
                player.Dispose();

                br.Close();
                fs.Close();
            });
        }
    }
}
