using System.Windows.Forms;
using OpenCvSharp;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Timers;
using System.Diagnostics;

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

        private void PlayerForm_Load(object sender, System.EventArgs e)
        {
            int fps = 10;
            decimal drawInterval = 1000m / fps;
            
            Task.Run(() =>
            {
                Stopwatch sw = new Stopwatch();
                decimal nextDrawTime = 0;

                // 音声ファイル
                player.Play();

                sw.Start();

                while (fs.Position < fs.Length)
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
                player.Stop();
                player.Dispose();

                br.Close();
                fs.Close();
            });
        }

        private System.DateTime prevTime = System.DateTime.Now;

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
