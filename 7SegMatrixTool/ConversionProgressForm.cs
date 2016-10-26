using System;
using System.Windows.Forms;
using System.Threading;

namespace _7SegMatrixTool
{
    public partial class ConversionProgressForm : Form
    {
        public ConversionProgressForm()
        {
            InitializeComponent();

            progressBar.Value = 0;
            labelProgress.Text = "";
        }

        private string mInputFileNameHeader = null;
        private string mOutputFileNameHeader = null;
        private int mConversionNumber;

        private Thread mWorkerThread = null;
        private bool mIsCanceled = false;

        /// <summary>
        /// 変換開始
        /// </summary>
        /// <param name="inputFileNameHeader">入力ファイル名のヘッダ部分</param>
        /// <param name="outputFileNameHeader">出力ファイル名のヘッダ部分</param>
        /// <param name="conversionNumber">変換枚数</param>
        public void startConversion(string inputFileNameHeader, string outputFileNameHeader, int conversionNumber)
        {
            mInputFileNameHeader = inputFileNameHeader;
            mOutputFileNameHeader = outputFileNameHeader;
            mConversionNumber = conversionNumber;

            mWorkerThread = new Thread(convertSerialNumberImage);
            mWorkerThread.IsBackground = true;
            mWorkerThread.Start();
        }

        /// <summary>
        /// キャンセルボタンが押された場合、処理を途中で停止する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            mIsCanceled = true;
        }

        private delegate void delegateUpdateProgress(int currentNumber);

        private void updateProgress(int currentNumber)
        {
            double rate = ((double)currentNumber + 1) / mConversionNumber;
            progressBar.Value = (int)(rate * 100);
            labelProgress.Text = "変換枚数: " + (currentNumber + 1).ToString() + "/" + mConversionNumber.ToString();
        }

        private delegate void delegateComplete();

        private void complete()
        {
            if (mIsCanceled)
            {
                MessageBox.Show("中断しました");
            }
            else
            {
                MessageBox.Show("完了しました");
            }
            this.Close();
        }

        private void convertSerialNumberImage()
        {
            // WORKAROUND: TODO: ダミー処理
            for (int i = 0; i < mConversionNumber; i++)
            {
                if (mIsCanceled)
                {
                    break;
                }
                Thread.Sleep(10);
                Invoke(new delegateUpdateProgress(updateProgress), i);
            }
            Invoke(new delegateComplete(complete));

            /*
            for (int i = 0; i < conversionNumber; i++)
            {
                string inputFileName = inputFileNameHeader + i.ToString("D4") + ".bmp";
                string outputFileName = outputFileNameHeader + i.ToString("D4") + ".bmp";
                _7SegMatrix matrix = new _7SegMatrix(inputFileName);
                matrix.convert(trackBarThreshold.Value);
                matrix.save(outputFileName);
            }
             */
        }
    }
}
