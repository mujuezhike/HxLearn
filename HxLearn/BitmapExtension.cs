using System.Drawing;
using System.Drawing.Drawing2D;

namespace HxLearn
{
    static class BitmapExtension
    {
        /// <summary>
        /// 变换大小
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ScaleToSize(this Bitmap bitmap, int width, int height)
        {
            if (bitmap.Width == width && bitmap.Height == height)
            {
                return bitmap;
            }

            var scaledBitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(scaledBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bitmap, 0, 0, width, height);
            }

            return scaledBitmap;
        }

        /// <summary>
        /// 切割部分
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static Bitmap ShearCut(this Bitmap bitmap, int x1, int y1, int x2, int y2)
        {
            if (x1 < 0)
            {
                x1 = 0;
            }

            if (y2 < 0)
            {
                y2 = 0;
            }

            if (x2 > bitmap.Width)
            {
                x2 = bitmap.Width;
            }

            if (y2 > bitmap.Height)
            {
                y2 = bitmap.Height;
            }

            Bitmap newBitmap = new Bitmap(x2 - x1, y2 - y1);

            for (int i = 0; i < x2 - x1; i++)
            {
                for (int j = 0; j < y2 - y1; j++)
                {
                    Color co = bitmap.GetPixel(x1 + i, y1 + j);
                    Color c = Color.FromArgb(co.A, co.R, co.G, co.B);

                    newBitmap.SetPixel(i, j, c);
                }
            }

            return newBitmap;

        }
    }
}
