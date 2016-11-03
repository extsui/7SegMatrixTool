using System;
using System.Windows.Forms;
using System.Threading;

namespace _7SegMatrixTool
{
    /// <summary>
    /// 進捗状況クラス
    /// ・要素数と現在値を渡すことで進捗状況バーの表示を更新する。
    /// ・定期的にIsCanceledの値を確認することでキャンセルボタン押下を検出すること。
    /// ・完了/キャンセルの判定はDialogResultで判定すること。
    ///     - 完了:DialogResult.OK / キャンセル:DialogResult.Cancel
    /// </summary>
    public partial class ProgressForm : Form
    {
        private bool mIsCanceled = false;   // キャンセルされたか

        public ProgressForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームを表示する
        /// </summary>
        public new void Show()
        {
            DialogResult = DialogResult.OK;
            mIsCanceled = false;
            base.Show();
        }

        /// <summary>
        /// キャンセルされたか否か
        /// </summary>
        public bool IsCanceled
        {
            get
            {
                return mIsCanceled;
            }
        }

        /// <summary>
        /// フォームのタイトル文字列
        /// </summary>
        public string Title
        {
            set
            {
                this.Text = value;
            }
        }

        /// <summary>
        /// 進捗状況の要素数
        /// </summary>
        public int ProgressCount
        {
            get
            {
                return progressBar.Maximum;
            }

            set
            {
                progressBar.Maximum = value;
            }
        }

        /// <summary>
        /// 進捗状況の現在値
        /// 現在値を更新した場合、進捗状況バーの表示も更新する。
        /// なお、配列の添え字のような0～MAX-1の範囲の値を使用する場合、
        /// +1した値を設定する必要がある。
        /// </summary>
        public int ProgressValue
        {
            get
            {
                return progressBar.Value;
            }

            set
            {
                progressBar.Value = value;
                int rate = (int)((double)ProgressValue / ProgressCount * 100);
                labelProgress.Text = rate.ToString() + "%" + " (" + value.ToString() + "/" + ProgressCount.ToString() + ")";
            }
        }

        /// <summary>
        /// キャンセルボタンが押された場合、処理を途中で停止する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            mIsCanceled = true;
            DialogResult = DialogResult.Cancel;
        }
    }
}
