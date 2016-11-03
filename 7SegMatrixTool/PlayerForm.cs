using System.Windows.Forms;
using OpenCvSharp;
using System.Threading.Tasks;
using System.IO;

namespace _7SegMatrixTool
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
        }

        private void PlayerForm_Load(object sender, System.EventArgs e)
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

                    // BUG:  ウィンドウサイズを変更すると頻繁にエラー画像になってしまう。
                    //       _7SegMatrixクラスでdelegateしてないのが原因な気がする。
                    // TODO: drowXXXPicture()にボックス渡すのは変な気がする。
                    //       ⇒7SegMatrixクラスで、入力画像取得と出力画像取得メソッド作るべきでは?
                    matrix.drawOutputPicture(pictureBoxIplScreen);

                    //textBoxInputFolder.Text = (fs.Position / 128).ToString();

                    // TODO: 一定周期毎に更新するのでタイマでやるべき
                    System.Threading.Thread.Sleep(66);
                }

                // 音声ストップ
                player.Stop();
                player.Dispose();

                br.Close();
                fs.Close();
            });
        }

        // TODO: Closingハンドラも作ること。音声ストップしないとダメ。
    }
}
