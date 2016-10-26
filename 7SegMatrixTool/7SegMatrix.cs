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

        IplImage mImageFull = null; // 入力画像(フルカラー)
        IplImage mImageGray = null; // 入力画像(グレースケール)
        IplImage mImageBin  = null; // 出力画像(二値)
        IplImage mImage7Seg = null; // 出力画像(7セグ)

        public _7SegMatrix(string fileName)
        {
            mImageFull = new IplImage(fileName);
            convertFullToGray();
            convertGrayToBin();
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

        public void save(string fileName)
        {
            mImage7Seg.SaveImage(fileName);
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
        /// mImageGray --> mImageBin
        /// </summary>
        /// <param name="threshold">閾値(0-100)</param>
        private void convertBinTo7Seg(int threshold)
        {
            mImage7Seg = mImageBin.Clone();
            mImage7Seg.Zero();
            match7SegMatrix(mImageBin, mImage7Seg, threshold);
        }

        /// <summary>
        /// 7セグマトリクスへのマッチング
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dest">出力画像</param>
        /// <param name="threshold">閾値(0-100)</param>
        private void match7SegMatrix(IplImage src, IplImage dest, int threshold)
        {
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

                    byte pattern = _7Seg.match(mImageBin,
                        x * _7SEG_SIZE.Width + xGap,
                        y * _7SEG_SIZE.Height + yGap,
                        threshold);

                    _7Seg.write(mImage7Seg,
                        x * _7SEG_SIZE.Width + xGap,
                        y * _7SEG_SIZE.Height + yGap,
                        pattern);
                }
            });
        }
    }
}
