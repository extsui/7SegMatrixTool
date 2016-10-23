using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace _7SegMatrixTool
{
    class _7SegMatrix
    {
        IplImage mImageFull = null; // 入力画像(フルカラー)
        IplImage mImageGray = null; // 入力画像(グレースケール)
        IplImage mImageBin  = null; // 出力画像(二値)
        IplImage mImage7Seg = null; // 出力画像(7セグ)

        private int mThreshold;     // 二値画像⇒7セグ変換時の閾値

        public _7SegMatrix(string fileName)
        {
            mImageFull = new IplImage(fileName);
            fullToGray();
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
            // TODO:
            // drawPicture(pb, mImage7Seg);

            grayToBin();
            drawPicture(pb, mImageGray);
        }

        /// <summary>
        /// グレースケール⇒7セグ変換時の閾値を設定する
        /// </summary>
        /// <param name="threshold">閾値(0-100)</param>
        public void setThreshold(int threshold)
        {
            mThreshold = threshold;
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
        private void fullToGray()
        {
            mImageGray = new IplImage(mImageFull.GetSize(), BitDepth.U8, 1);
            mImageFull.CvtColor(mImageGray, ColorConversion.BgrToGray);
        }

        /// <summary>
        /// グレースケール画像(8bit)を二値画像(8bit)に変換する
        /// mImageGray --> mImageBin
        /// </summary>
        private void grayToBin()
        {
            using (IplImage binaryOtsu = mImageGray.Clone())
            {
                Cv.Threshold(mImageGray, binaryOtsu, 0, 255, ThresholdType.Otsu);
                mImageGray = binaryOtsu.Clone();
            }
        }

        /// <summary>
        /// 二値画像(8bit)を7セグ画像(8bit)に変換する
        /// mImageGray --> mImageBin
        /// </summary>
        private void BinTo7Seg()
        {
            // TODO:
        }
    }
}
