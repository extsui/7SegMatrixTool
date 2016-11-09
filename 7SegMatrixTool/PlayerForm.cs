using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Threading;

namespace _7SegMatrixTool
{
    public partial class PlayerForm : Form
    {
        private FileStream mFs = null;      // 7セグマトリクス専用形式ファイルストリーム
        private int mFps = 0;               // 1秒間のフレーム数
        private SoundPlayer mPlayer = null; // 音声再生
        private Thread mThread = null;      // 再生スレッド
        private bool mIsCanceled = false;   // スレッドがキャンセルされたか

        /// <summary>
        /// 音声無し再生フォーム
        /// </summary>
        /// <param name="_7SegMatrixFile">7セグマトリクス専用形式ファイル</param>
        /// <param name="fps">1秒間のフレーム数</param>
        public PlayerForm(string _7SegMatrixFile, int fps)
        {
            PlayerFormCommon(_7SegMatrixFile, fps);
        }

        /// <summary>
        /// 音声有り再生フォーム
        /// </summary>
        /// <param name="_7SegMatrixFile">7セグマトリクス専用形式ファイル</param>
        /// <param name="fps">1秒間のフレーム数</param>
        /// <param name="waveFile">音声形式ファイル</param>
        public PlayerForm(string _7SegMatrixFile, int fps, string waveFile)
        {
            PlayerFormCommon(_7SegMatrixFile, fps);
            mPlayer = new SoundPlayer(waveFile);
        }

        /// <summary>
        /// コンストラクタ共通部
        /// </summary>
        /// <param name="_7SegMatrixFile"></param>
        /// <param name="fps"></param>
        /// <returns></returns>
        private PlayerForm PlayerFormCommon(string _7SegMatrixFile, int fps)
        {
            InitializeComponent();
            mFs = new FileStream(_7SegMatrixFile, FileMode.Open);
            mFps = fps;
            return this;
        }

        /// <summary>
        /// 再生フォーム読み込み時に呼び出され、ここで再生スレッドを開始する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerForm_Load(object sender, System.EventArgs e)
        {
            mThread = new Thread(doWork);
            mThread.IsBackground = true;
            mThread.Start();
        }

        /// <summary>
        /// 再生スレッドのメイン処理
        /// 閉じるボタンが押下されるか、7セグマトリクスの最後まで再生したら終了する。
        /// </summary>
        private void doWork()
        {
            BinaryReader br = new BinaryReader(mFs);
            Stopwatch sw = new Stopwatch();
            decimal drawInterval = 1000m / mFps;
            decimal nextDrawTime = 0;

            StartPlayer();
            sw.Start();
            
            while (mFs.Position < mFs.Length)
            {
                byte[] _7SegPattern = br.ReadBytes(_7SegMatrix._7SEG_NUM_IN_MATRIX);
                _7SegMatrix matrix = new _7SegMatrix(_7SegPattern);

                // 終了処理を共通化したかったので、フラグを使用して、閉じるボタンが
                // 押下された場合と押下されず再生が終了した場合で同じ経路を通るようにした。
                if (mIsCanceled)
                {
                    break;
                }

                // System.Timers.Timerの周期ハンドラは満足のいく精度でなかったため、
                // ストップウォッチで経過時間をポーリングで計測する方式とした。
                while (true)
                {
                    if (nextDrawTime <= sw.ElapsedMilliseconds)
                    {
                        pictureBoxIplScreen.BeginInvoke(new System.Action<_7SegMatrix>(delegateDraw), matrix);
                        nextDrawTime += drawInterval;
                        break;
                    }
                    else
                    {
                        // 負荷は上がるが描画タイミング精度を向上させるため最小周期でポーリングする。
                        System.Threading.Thread.Sleep(1);
                    }
                }
            }

            sw.Stop();
            StopPlayer();
            
            br.Close();
            mFs.Close();

            this.BeginInvoke(new System.Action(delegateClose));
        }

        /// <summary>
        /// 音声再生を開始する(音声ファイルが指定されている場合)
        /// </summary>
        private void StartPlayer()
        {
            if (mPlayer != null)
            {
                mPlayer.Play();
            }
        }
        
        /// <summary>
        /// 音声再生を停止する(音声ファイルが指定されている場合)
        /// </summary>
        private void StopPlayer()
        {
            if (mPlayer != null)
            {
                mPlayer.Stop();
                mPlayer.Dispose();
            }
        }

        /// <summary>
        /// 閉じるボタンが押された時に呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mIsCanceled = true;

            // 以下の流れを作るために少し待つ
            //  1.スレッド(doWork())からウィンドウを閉じる処理(delegateClose())
            //  2.FormClosing()完了
            // ※2⇒1の順番になった場合、閉じるウィンドウが無いために例外が発生してしまう
            System.Threading.Thread.Sleep(100);
        }

        /// <summary>
        /// 委譲描画
        /// タイトルバーに前回からの描画間隔時間を表示する
        /// </summary>
        /// <param name="matrix"></param>
        private void delegateDraw(_7SegMatrix matrix)
        {
            matrix.drawOutputPicture(pictureBoxIplScreen);
        }

        /// <summary>
        /// 委譲クローズ
        /// スレッドの最後で呼ばれる
        /// </summary>
        private void delegateClose()
        {
            this.Close();
        }
    }
}
