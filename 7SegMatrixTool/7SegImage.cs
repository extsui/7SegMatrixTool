using OpenCvSharp;
using System.Windows.Forms;

namespace _7SegMatrixTool
{
    class _7SegImage
    {
        private const int SEGMENT_X_SPAN = 1; /* (39 + <1>) * 16 --> 640 */
        private const int SEGMENT_Y_SPAN = 8; /* (52 + <8>) * 8  --> 480 */

        public static void _7SegmentMatching(IplImage src, IplImage dest)
        {
            SegmentEditor se = new SegmentEditor();
            for (int y = 0; y < 8; y++)
            {
                int yspan = y * SEGMENT_Y_SPAN;
                for (int x = 0; x < 16; x++)
                {
                    int xspan = x * SEGMENT_X_SPAN;
                    byte pattern = se.Match7Segment(src, x * 39 + xspan, y * 52 + yspan);
                    se.Write7Segment(dest, x * 39 + xspan, y * 52 + yspan, pattern);
                }
            }
        }
    }

    /*****************************************************************************/

    class SegmentEditor
    {
        const int SEGMENT_NUM = 8;
        IplImage[] segment = new IplImage[SEGMENT_NUM];

        public SegmentEditor()
        {
            for (int i = 0; i < SEGMENT_NUM; i++)
            {
                /*
                 * "../../../x.bmp"を読み込む．
                 * xは0-7であり，それぞれa-.セグメントに対応．
                 * 全ての画像は同一サイズとする．
                 */
                segment[i] = new IplImage(@"../../../" + i + ".bmp");
            }
        }

        private IplImage Create7SegmentImage(byte pattern)
        {
            // segment[0]を原型として使用する
            IplImage patternImage = segment[0].Clone();
            patternImage.Zero();

            // segment[a,b,..,.] : bit[0x80,0x40,..,0x01]
            byte bit = 0x80;
            for (int i = 0; i < SEGMENT_NUM; i++)
            {
                if ((pattern & bit) != 0)
                {
                    patternImage.Or(segment[i], patternImage);
                }
                bit >>= 1;
            }
            return patternImage;
        }

        public void Write7Segment(IplImage canvas, int x, int y, byte pattern)
        {
            IplImage writeImage = Create7SegmentImage(pattern);

            for (int _y = 0; _y < segment[0].Height; _y++)
            {
                for (int _x = 0; _x < segment[0].Width; _x++)
                {
                    CvScalar cs = writeImage.Get2D(_y, _x);
                    canvas.Set2D(y + _y, x + _x, cs);
                }
            }
        }

        /***/
        public static double thresholdRate;
        /***/

        /// <summary>
        /// srcで指定された画像の座標(x, y)に対して，7セグメントマッチングを行う．
        /// マッチング結果はdestで指定された画像に書き込む．
        /// TODO: ビットパターンを返すというのもあり．
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="origin"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public byte Match7Segment(IplImage src, int x, int y)
        {
            //const double thresholdRate = 0.50;

            byte pattern = 0x00;
            for (int i = 0; i < SEGMENT_NUM; i++)
            {
                // TODO: segmentそれぞれに白ピクセル数を覚えさせておくと高速化できそう
                int samePixelNum = 0;
                int totalPixelNum = 0;
                for (int _y = 0; _y < segment[i].Height; _y++)
                {
                    for (int _x = 0; _x < segment[i].Width; _x++)
                    {
                        CvScalar segmentPixel = segment[i].Get2D(_y, _x);
                        if (segmentPixel.Val0 == 255 &&
                            segmentPixel.Val1 == 255 &&
                            segmentPixel.Val2 == 255 &&
                            segmentPixel.Val3 == 0)
                        {
                            CvScalar srcPixel = src.Get2D(y + _y, x + _x);
                            // TODO: 応急処置
                            // (255, 0, 0, 0)の画像もあるみたい

                            /***
                            if (srcPixel.Val0 == 255 &&
                                srcPixel.Val1 == 255 &&
                                srcPixel.Val2 == 255 &&
                                srcPixel.Val3 == 0)
                             ***/
                            if (srcPixel.Val0 == 255 &&
                                srcPixel.Val1 == 0   &&
                                srcPixel.Val2 == 0   &&
                                srcPixel.Val3 == 0)
                            {
                                samePixelNum++;
                            }
                            totalPixelNum++;
                        }
                    }
                }
                // 白ピクセル部分全体に占める対象画像の白ピクセル数の割合を求める．
                // ある一定以上の割合であると当該セグメントを書き込む．
                if ((double)samePixelNum / totalPixelNum >= thresholdRate)
                {
                    pattern |= (byte)(0x80 >> i);
                }
            }
            return pattern;
        }
    }
}
