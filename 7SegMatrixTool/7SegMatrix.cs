using System.Threading.Tasks;
using OpenCvSharp;

namespace _7SegMatrixTool
{
    class _7SegMatrix
    {
        private const int X_7SEG_NUM = 16;  // 7セグマトリクスのX方向の個数
        private const int Y_7SEG_NUM = 8;   // 7セグマトリクスのY方向の個数
        private const int X_7SEG_GAP = 1;   // 7セグ間のX方向の間隔((39 + <1>) * 16 --> 640)
        private const int Y_7SEG_GAP = 8;   // 7セグ間のY方向の間隔((52 + <8>) * 8  --> 480)
        private const int _7SEG_NUM_IN_MATRIX = X_7SEG_NUM * Y_7SEG_NUM;    // 7セグマトリクスの7セグの個数

        IplImage mImageFull = null; // 入力画像(フルカラー)
        IplImage mImageGray = null; // 入力画像(グレースケール)
        IplImage mImageBin  = null; // 出力画像(二値)
        IplImage mImage7Seg = null; // 出力画像(7セグ)

        byte[] m7SegPattern = null;    // 7セグパターン配列

        public _7SegMatrix(string fileName)
        {
            mImageFull = new IplImage(fileName);
            convertFullToGray();
            convertGrayToBin();
        }

        /// <summary>
        /// 7セグパターンから7セグ画像作成
        /// </summary>
        /// <param name="_7SegPattern">7セグパターン</param>
        public _7SegMatrix(byte[] _7SegPattern)
        {
            mImage7Seg = new IplImage(640, 480, BitDepth.U8, 1);
            mImage7Seg.Zero();
            _7SegImage _7Seg = new _7SegImage();

            // 以下のfor文を並列化
            // for (int y = 0; y < Y_7SEG_NUM; y++)
            Parallel.For(0, Y_7SEG_NUM, y =>
            {
                int yGap = y * Y_7SEG_GAP;
                for (int x = 0; x < X_7SEG_NUM; x++)
                {
                    int xGap = x * X_7SEG_GAP;
                    CvSize _7SEG_SIZE = _7Seg.getSize();

                    _7Seg.write(mImage7Seg,
                        x * _7SEG_SIZE.Width + xGap,
                        y * _7SEG_SIZE.Height + yGap,
                        _7SegPattern[y * X_7SEG_NUM + x]);
                }
            });

        }

        /// <summary>
        /// 入力画像を描画する
        /// </summary>
        /// <param name="pb">描画先のPictureBox</param>
        public void drawInputPicture(OpenCvSharp.UserInterface.PictureBoxIpl pb)
        {
            drawPicture(pb, mImageFull);
        }

        /// <summary>
        /// 出力画像を描画する
        /// </summary>
        /// <param name="pb">描画先のPictureBox</param>
        public void drawOutputPicture(OpenCvSharp.UserInterface.PictureBoxIpl pb)
        {
            drawPicture(pb, mImage7Seg);
        }

        /// <summary>
        /// 指定された閾値でグレースケール⇒7セグ変換を行う
        /// </summary>
        /// <param name="threshold">閾値(0-100)</param>
        public void convert(int threshold)
        {
            convertBinTo7Seg(threshold);
        }

        /// <summary>
        /// 7セグパターンを取得する
        /// </summary>
        /// <returns></returns>
        public byte[] get7SegPattern()
        {
            return m7SegPattern;
        }

        /// <summary>
        /// 7セグ画像をファイルに保存する
        /// </summary>
        /// <param name="fileName"></param>
        public void save(string fileName)
        {
            mImage7Seg.SaveImage(fileName);
        }

        /// <summary>
        /// 指定されたPictureBoxに画像を描画する
        /// </summary>
        /// <param name="pb">描画先のPictureBox</param>
        /// <param name="img">描画する画像</param>
        private void drawPicture(OpenCvSharp.UserInterface.PictureBoxIpl pb, IplImage img)
        {
            using (IplImage pictureImage = new IplImage(img.GetSize(), img.Depth, img.NChannels))
            {
                pictureImage.SetROI(0, 0, pb.Width, pb.Height);
                img.Resize(pictureImage);
                pb.ImageIpl = pictureImage;
            }
        }

        /// <summary>
        /// フルカラー画像(24bit)をグレースケール画像(8bit)に変換する
        /// mImageFull --> mImageGray
        /// </summary>
        private void convertFullToGray()
        {
            mImageGray = new IplImage(mImageFull.GetSize(), BitDepth.U8, 1);
            mImageFull.CvtColor(mImageGray, ColorConversion.BgrToGray);
        }

        /// <summary>
        /// グレースケール画像(8bit)を二値画像(8bit)に変換する
        /// mImageGray --> mImageBin
        /// </summary>
        private void convertGrayToBin()
        {
            mImageBin = mImageGray.Clone();
            Cv.Threshold(mImageGray, mImageBin, 0, 255, ThresholdType.Otsu);
        }

        /// <summary>
        /// 二値画像(8bit)を7セグ画像(8bit)に変換する
        /// mImageGray --> mImageBin, m7SegPattern
        /// </summary>
        /// <param name="threshold">閾値(0-100)</param>
        private void convertBinTo7Seg(int threshold)
        {
            mImage7Seg = mImageBin.Clone();
            mImage7Seg.Zero();
            m7SegPattern = match7SegMatrix(mImageBin, mImage7Seg, threshold);
        }

        /// <summary>
        /// 7セグマトリクスへのマッチング
        /// マッチング結果の画像と7セグパターンを作成する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dest">出力画像</param>
        /// <param name="threshold">閾値(0-100)</param>
        /// <returns>7セグパターン配列</returns>
        private byte[] match7SegMatrix(IplImage src, IplImage dest, int threshold)
        {
            _7SegImage _7Seg = new _7SegImage();
            byte[] patterns = new byte[_7SEG_NUM_IN_MATRIX];

            // 以下のfor文を並列化
            // for (int y = 0; y < Y_7SEG_NUM; y++)
            Parallel.For(0, Y_7SEG_NUM, y =>
            {
                int yGap = y * Y_7SEG_GAP;
                for (int x = 0; x < X_7SEG_NUM; x++)
                {
                    int xGap = x * X_7SEG_GAP;
                    CvSize _7SEG_SIZE = _7Seg.getSize();

                    byte pattern = _7Seg.match(mImageBin,
                        x * _7SEG_SIZE.Width + xGap,
                        y * _7SEG_SIZE.Height + yGap,
                        threshold);

                    _7Seg.write(mImage7Seg,
                        x * _7SEG_SIZE.Width + xGap,
                        y * _7SEG_SIZE.Height + yGap,
                        pattern);

                    patterns[y * X_7SEG_NUM + x] = pattern;
                }
            });

            return patterns;
        }
    }
}
