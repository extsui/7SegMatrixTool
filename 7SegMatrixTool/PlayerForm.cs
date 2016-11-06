using System.Windows.Forms;
using OpenCvSharp;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Timers;

namespace _7SegMatrixTool
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();

            fs = new FileStream(@"F:\Project\7SegMatrixMovieCutter\Scene\BADAPPLE.7SM", FileMode.Open);
            br = new BinaryReader(fs);
            player = new System.Media.SoundPlayer(@"F:\Project\7SegMatrixMovieCutter\Movie\original\badapple.wav");

        }

        FileStream fs;
        BinaryReader br;
        SoundPlayer player;
        System.Timers.Timer timer;

        private void PlayerForm_Load(object sender, System.EventArgs e)
        {
            int fps = 10;

            timer = new System.Timers.Timer();
            timer.Interval = 1000.0 / fps;
            timer.Elapsed += timer_Elapsed;
            timer.AutoReset = true;
            timer.Start();
            
            // 音声ファイル
            player.Play();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (fs.Position < fs.Length)
            {
                byte[] _7SegPattern = br.ReadBytes(128);
                _7SegMatrix matrix = new _7SegMatrix(_7SegPattern);

                // BUG:  ウィンドウサイズを変更すると頻繁にエラー画像になってしまう。
                //       _7SegMatrixクラスでdelegateしてないのが原因な気がする。
                // TODO: drowXXXPicture()にボックス渡すのは変な気がする。
                //       ⇒7SegMatrixクラスで、入力画像取得と出力画像取得メソッド作るべきでは?

                // delegate
                pictureBoxIplScreen.BeginInvoke(new System.Action<_7SegMatrix>(delegateDrow), matrix);

                // TODO: 一定周期毎に更新するのでタイマでやるべき
                //System.Threading.Thread.Sleep();
            }
            else
            {
                timer.Stop();

                // 音声ストップ
                player.Stop();
                player.Dispose();

                br.Close();
                fs.Close();
            }
        }

        private System.DateTime prevTime = System.DateTime.Now;

        private void delegateDrow(_7SegMatrix matrix)
        {
            System.DateTime nowTime = System.DateTime.Now;

            this.Text = nowTime.Subtract(prevTime).ToString("fff");

            prevTime = nowTime;

            matrix.drawOutputPicture(pictureBoxIplScreen);
        }

        // TODO: Closingハンドラも作ること。音声ストップしないとダメ。
    }
}
