using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Diagnostics;

namespace _7SegMatrixTool
{
    public partial class PlayerForm : Form
    {
        private FileStream mFs = null;      // 7セグマトリクス専用形式ファイルストリーム
        private int mFps = 0;               // 1秒間のフレーム数
        private SoundPlayer mPlayer = null; // 音声再生

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

        private PlayerForm PlayerFormCommon(string _7SegMatrixFile, int fps)
        {
            InitializeComponent();
            mFs = new FileStream(_7SegMatrixFile, FileMode.Open);
            mFps = fps;
            return this;
        }

        /// <summary>
        /// 再生フォーム読み込み時に呼び出され、ここで再生を開始する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerForm_Load(object sender, System.EventArgs e)
        {
            decimal drawInterval = 1000m / mFps;
            BinaryReader br = new BinaryReader(mFs);
            
            Task.Run(() =>
            {
                Stopwatch sw = new Stopwatch();
                decimal nextDrawTime = 0;

                // 音声ファイル
                if (mPlayer != null)
                {
                    mPlayer.Play();
                }

                sw.Start();

                while (mFs.Position < mFs.Length)
                {
                    byte[] _7SegPattern = br.ReadBytes(128);
                    _7SegMatrix matrix = new _7SegMatrix(_7SegPattern);

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

                // 音声ストップ
                if (mPlayer != null)
                {
                    mPlayer.Stop();
                    mPlayer.Dispose();
                }

                br.Close();
                mFs.Close();
            });
        }

        private System.DateTime prevTime = System.DateTime.Now;

        /// <summary>
        /// 委譲描画用
        /// </summary>
        /// <param name="matrix"></param>
        private void delegateDraw(_7SegMatrix matrix)
        {
            System.DateTime nowTime = System.DateTime.Now;

            this.Text = nowTime.Subtract(prevTime).ToString("fff");

            prevTime = nowTime;

            matrix.drawOutputPicture(pictureBoxIplScreen);
        }

        // TODO: Closingハンドラも作ること。音声ストップしないとダメ。
    }
}
