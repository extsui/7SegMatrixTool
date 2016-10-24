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
            }
        }

        /// <summary>
        /// 画像変換時の閾値を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
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
                // TODO:
                MessageBox.Show("保存");
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
            // TODO:
            MessageBox.Show("変換開始");
        }
    }
}
