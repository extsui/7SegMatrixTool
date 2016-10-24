using OpenCvSharp;
using System.Windows.Forms;

namespace _7SegMatrixTool
{
    class _7SegImage
    {
        private const int SEGMENT_NUM = 8;  // 7セグメントのセグメント数
        private IplImage[] segment = null;  // 各セグメントのマスクパターン画像

        public _7SegImage()
        {
            /*
             * 0.bmp ... aセグメントに対応
             * 1.bmp ... bセグメントに対応
             * ...
             * 7.bmp ... dotセグメントに対応
             * (画像は全ては同一サイズ)
             */
            segment = new IplImage[SEGMENT_NUM];
            for (int i = 0; i < SEGMENT_NUM; i++)
            {
                segment[i] = new IplImage(@"../../../" + i + ".bmp");
            }
        }

        /// <summary>
        /// マッチングに使用する7セグメント画像のサイズを返す
        /// </summary>
        /// <returns>画像サイズ</returns>
        public CvSize getSize()
        {
            return segment[0].GetSize();
        }

        /// <summary>
        /// srcで指定されたマッチング対象の画像の座標(x, y)に対して、
        /// 7セグメントのマッチングを行い、マッチング結果を7セグの
        /// ビットパターンとして返す。
        /// </summary>
        /// <param name="src">マッチング対象の画像</param>
        /// <param name="x">x座標始点</param>
        /// <param name="y">y座標始点</param>
        /// <param name="threshold">マッチングに使用する閾値(0-100)</param>
        /// <returns>7セグメントのビットパターン</returns>
        public byte match(IplImage src, int x, int y, int threshold)
        {
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
                if (((double)samePixelNum / totalPixelNum) * 100 >= threshold)
                {
                    pattern |= (byte)(0x80 >> i);
                }
            }
            return pattern;
        }

        /// <summary>
        /// destで指定された画像の座標(x, y)に対して、patternで
        /// 指定された7セグメントのビットパターンを書き込む。
        /// </summary>
        /// <param name="dest">パターンを書き込む画像</param>
        /// <param name="x">x座標始点</param>
        /// <param name="y">y座標始点</param>
        /// <param name="pattern">7セグメントのビットパターン</param>
        public void write(IplImage dest, int x, int y, byte pattern)
        {
            IplImage writeImage = create(pattern);

            for (int _y = 0; _y < segment[0].Height; _y++)
            {
                for (int _x = 0; _x < segment[0].Width; _x++)
                {
                    CvScalar cs = writeImage.Get2D(_y, _x);
                    dest.Set2D(y + _y, x + _x, cs);
                }
            }
        }

        /// <summary>
        /// 指定された7セグメントのビットパターン画像を作成する
        /// </summary>
        /// <param name="pattern">7セグメントのビットパターン</param>
        /// <returns>7セグメントのビットパターン画像</returns>
        private IplImage create(byte pattern)
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
    }
}
