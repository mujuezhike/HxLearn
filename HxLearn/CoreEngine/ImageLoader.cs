using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace HxLearn.CoreEngine
{
    public class ImageLoader
    {
        public static object objlock = new object();

        private static VBlock[,] LastTemp;

        public struct Point
        {
            public Int32 x;
            public Int32 y;
        }
        /// <summary>
        /// 图层显示块
        /// </summary>
        public struct VBlock
        {
            public Int32 x;
            public Int32 y;
            public ConsoleColor fColor;
            public ConsoleColor bColor;
            public String font;
            public bool isTrans;
            public bool isTransF;

            public override bool Equals(object obj)
            {
                if (obj is VBlock)
                {
                    VBlock objv = (VBlock)obj;
                    if(    this.x == objv.x 
                        && this.y == objv.y
                        && this.fColor == objv.fColor
                        && this.bColor == objv.bColor
                        && this.font == objv.font
                        && this.isTrans == objv.isTrans
                        && this.isTransF == objv.isTransF)
                    {
                        return true;
                    }
                    return false;

                }
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// 图层
        /// </summary>
        public class Layer
        {
            public String name;
            public VBlock[,] map;
        }

        /// <summary>
        /// 颜色匹配器
        /// </summary>
        static int[,] ColorFilter = {
            { 0,0,0,0 }, //ConsoleColor.Black
            { 0,0,255,9},//ConsoleColor.Blue
            { 0,255,255,11},//ConsoleColor.Cyan
            { 0,0,128,1},//ConsoleColor.DarkBlue
            { 0,128,128,3},//ConsoleColor.DarkCyan
            { 128,128,128,8},//ConsoleColor.DarkGray
            { 0,128,0,2},//ConsoleColor.DarkGreen
            { 128,0,128,5},//ConsoleColor.DarkMagenta
            { 128,0,0,4},//ConsoleColor.DarkRed
            { 128,128,0,6},//ConsoleColor.DarkYellow
            { 192,192,192,7},//ConsoleColor.Gray
            { 0,255,0,10},//ConsoleColor.Green
            { 255,0,255,13},//ConsoleColor.Magenta
            { 255,0,0,12},//ConsoleColor.Red
            { 255,255,255,15},//ConsoleColor.White
            { 255,255,0,14},//ConsoleColor.Yellow
        };

        static public String Read(String path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            String sunLine = "";
            while ((line = sr.ReadLine()) != null)
            {
                sunLine += line;
                sunLine += "\n";
            }
            return sunLine;
        }

        static public void ShowBitMap(Bitmap bm, int x, int y)
        {
            for (int i = 0; i < bm.Height; i++)
            {
                for (int j = 0; j < bm.Width; j++)
                {
                    Color c = bm.GetPixel(j, i);
                    int min = 255 * 3;
                    int color = 15;
                    for (int m = 0; m < ColorFilter.GetLength(0); m++)
                    {
                        int ce = Math.Abs(c.R - ColorFilter[m, 0])
                               + Math.Abs(c.G - ColorFilter[m, 1])
                               + Math.Abs(c.B - ColorFilter[m, 2]);
                        if (ce < min)
                        {
                            min = ce;
                            color = ColorFilter[m, 3];
                        }
                    }

                    Console.SetCursorPosition(j * 2 + x, i + y);
                    Console.CursorVisible = false;
                    Console.BackgroundColor = (ConsoleColor)color;
                    Console.Write("　");

                    Console.WriteLine();
                }
            }
        }

        static public void ShowBitMap(Bitmap bm, int x, int y, int w, int l)
        {
            bm = bm.ScaleToSize(w, l);

            for (int i = 0; i < bm.Height; i++)
            {
                for (int j = 0; j < bm.Width; j++)
                {
                    Color c = bm.GetPixel(j, i);
                    int min = 255 * 3;
                    int color = 15;
                    for (int m = 0; m < ColorFilter.GetLength(0); m++)
                    {
                        int ce = Math.Abs(c.R - ColorFilter[m, 0])
                               + Math.Abs(c.G - ColorFilter[m, 1])
                               + Math.Abs(c.B - ColorFilter[m, 2]);
                        if (ce < min)
                        {
                            min = ce;
                            color = ColorFilter[m, 3];
                        }
                    }

                    Console.SetCursorPosition(j * 2 + x, i + y);
                    Console.CursorVisible = false;
                    Console.BackgroundColor = (ConsoleColor)color;
                    Console.Write("　");

                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// 将Bitmap 载入图层
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="bm"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        static public VBlock[,] LoadBitMap(VBlock[,] layer, Bitmap bm, int x, int y, int w, int l)
        {
            lock (objlock)
            {
                bm = bm.ScaleToSize(w, l);

                for (int i = 0; i < bm.Height; i++)
                {
                    for (int j = 0; j < bm.Width; j++)
                    {
                        Color c = bm.GetPixel(j, i);

                        int min = 255 * 3;
                        int color = 15;
                        for (int m = 0; m < ColorFilter.GetLength(0); m++)
                        {
                            int ce = Math.Abs(c.R - ColorFilter[m, 0])
                                   + Math.Abs(c.G - ColorFilter[m, 1])
                                   + Math.Abs(c.B - ColorFilter[m, 2]);
                            if (ce < min)
                            {
                                min = ce;
                                color = ColorFilter[m, 3];
                            }
                        }

                        //Console.SetCursorPosition(j * 2 + x, i + y);
                        VBlock vb = new VBlock();
                        vb.x = j + x;
                        vb.y = i + y;
                        vb.bColor = (ConsoleColor)color;
                        vb.fColor = ConsoleColor.White;
                        vb.font = "　";
                        vb.isTrans = c.A == 0 ? true : false;
                        layer[j + x, i + y] = vb;

                    }
                }

                return layer;
            }
        }

        static public VBlock[,] LoadBitMap(VBlock[,] layer, Bitmap bm, int x, int y)
        {
            lock (objlock)
            {
                for (int i = 0; i < bm.Height; i++)
                {
                    for (int j = 0; j < bm.Width; j++)
                    {
                        Color c = bm.GetPixel(j, i);

                        int min = 255 * 3;
                        int color = 15;
                        for (int m = 0; m < ColorFilter.GetLength(0); m++)
                        {
                            int ce = Math.Abs(c.R - ColorFilter[m, 0])
                                   + Math.Abs(c.G - ColorFilter[m, 1])
                                   + Math.Abs(c.B - ColorFilter[m, 2]);
                            if (ce < min)
                            {
                                min = ce;
                                color = ColorFilter[m, 3];
                            }
                        }

                        //Console.SetCursorPosition(j * 2 + x, i + y);
                        VBlock vb = new VBlock();
                        vb.x = j + x;
                        vb.y = i + y;
                        vb.bColor = (ConsoleColor)color;
                        vb.fColor = ConsoleColor.White;
                        vb.font = "　";
                        vb.isTrans = c.A == 0 ? true : false;
                        layer[j + x, i + y] = vb;

                    }
                }

                return layer;
            }
        }

        static public void ShowMutiLayer(params Layer[] layers)
        {
            if (layers != null && layers.Length > 0)
            {
                Layer mainLayer = layers[0];
                VBlock[,] blocks = mainLayer.map;
                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    for (int j = 0; j < blocks.GetLength(1); j++)
                    {
                        int m = 0;
                        while (true)
                        {
                            Layer showLayer = layers[m];
                            VBlock vb = showLayer.map[i, j];
                            if (!vb.isTrans)
                            {
                                Console.SetCursorPosition(i * 2, j);
                                Console.CursorVisible = false;
                                Console.BackgroundColor = vb.bColor;
                                Console.Write(vb.font);
                                break;
                            }
                            if (m < layers.Length - 1)
                            {
                                m++;
                            }
                            else
                            {
                                //默认背景
                                Console.SetCursorPosition(i * 2, j);
                                Console.CursorVisible = false;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("　");
                                break;
                            }
                        }

                    }

                }
            }
        }

        public static void UpdateMutiLayer(int x1, int y1, int x2, int y2, params Layer[] layers)
        {
            if (layers != null && layers.Length > 0)
            {
                Layer mainLayer = layers[0];
                VBlock[,] blocks = mainLayer.map;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        int m = 0;
                        while (true)
                        {
                            Layer showLayer = layers[m];
                            VBlock vb = showLayer.map[i, j];
                            if (!vb.isTrans)
                            {
                                Console.SetCursorPosition(i * 2, j);
                                Console.CursorVisible = false;
                                Console.BackgroundColor = vb.bColor;
                                Console.Write(vb.font);
                                break;
                            }
                            if (m < layers.Length - 1)
                            {
                                m++;
                            }
                            else
                            {
                                //默认背景
                                Console.SetCursorPosition(i * 2, j);
                                Console.CursorVisible = false;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("　");
                                break;
                            }
                        }

                    }

                }
            }
        }

        /// <summary>
        /// 合并图层
        /// </summary>
        /// <param name="layers"></param>
        /// <returns></returns>
        public static VBlock[,] ComBineLayer(params Layer[] layers)
        {
            if (layers != null && layers.Length > 0)
            {
                Layer mainLayer = layers[0];
                VBlock[,] blocks = mainLayer.map;
                VBlock[,] cbBlocks = new VBlock[blocks.GetLength(0), blocks.GetLength(1)];
                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    for (int j = 0; j < blocks.GetLength(1); j++)
                    {
                        VBlock cbBlock = new VBlock();
                        int m = 0;
                        while (true)
                        {
                            Layer showLayer = layers[m];
                            VBlock vb = showLayer.map[i, j];
                            if (!vb.isTrans)
                            {
                                cbBlock.x = i;
                                cbBlock.y = j;
                                cbBlock.isTrans = false;
                                cbBlock.bColor = vb.bColor;
                                cbBlock.font = "　";
                                break;
                            }
                            if (m < layers.Length - 1)
                            {
                                m++;
                            }
                            else
                            {
                                //默认背景
                                cbBlock.x = i;
                                cbBlock.y = j;
                                cbBlock.isTrans = false;
                                cbBlock.bColor = ConsoleColor.Black;
                                cbBlock.font = "　";
                                break;
                            }
                        }

                        int mm = 0;
                        while (true)
                        {
                            Layer showLayer = layers[mm];
                            VBlock vb = showLayer.map[i, j];
                            if (!vb.isTransF)
                            {
                                cbBlock.isTransF = false;
                                cbBlock.fColor = vb.fColor;
                                cbBlock.font = vb.font;
                                break;
                            }
                            if (mm < layers.Length - 1)
                            {
                                mm++;
                            }
                            else
                            {
                                //默认背景
                                cbBlock.isTransF = false;
                                cbBlock.fColor = ConsoleColor.White;
                                cbBlock.font = "　";
                                break;
                            }
                        }

                        cbBlocks[i, j] = cbBlock;

                    }

                }

                return cbBlocks;
            }
            return null;
        }

        /// <summary>
        /// 复制VBlocks 用于下次比较
        /// </summary>
        /// <param name="oBlocks"></param>
        /// <returns></returns>
        public static VBlock[,] CopyVBlocks(VBlock[,] oBlocks)
        {
            if (null != oBlocks)
            {
                VBlock[,] nBlocks = new VBlock[oBlocks.GetLength(0), oBlocks.GetLength(1)];
                for (int i = 0; i < oBlocks.GetLength(0); i++)
                {
                    for (int j = 0; j < oBlocks.GetLength(1); j++)
                    {
                        VBlock vb = new VBlock();
                        VBlock ovb = oBlocks[i, j];
                        vb.x = ovb.x;
                        vb.y = ovb.y;
                        vb.bColor = ovb.bColor;
                        vb.fColor = ovb.fColor;
                        vb.isTrans = ovb.isTrans;
                        vb.isTransF = ovb.isTransF;
                        vb.font = ovb.font;
                        nBlocks[i, j] = vb;
                    }
                }
                return nBlocks;
            }

            return null;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="layers"></param>
        public static void Show(params Layer[] layers)
        {
            lock (objlock)
            {

                VBlock[,] nBlocks = ComBineLayer(layers);
                int m = 0;
                if (null != nBlocks)
                {
                    for (int i = 0; i < nBlocks.GetLength(0); i++)
                    {
                        for (int j = 0; j < nBlocks.GetLength(1); j++)
                        {
                            VBlock vb = nBlocks[i, j];
                            if (null == LastTemp || !LastTemp[i, j].Equals(vb))
                            {
                                Console.SetCursorPosition(i * 2, j);
                                Console.BackgroundColor = vb.bColor;
                                Console.ForegroundColor = vb.fColor;
                                Console.CursorVisible = false;
                                Console.Write(vb.font);
                                m++;
                            }

                        }
                    }
                }
                //DEBUG
                //Console.SetCursorPosition(0, 0);
                //Console.BackgroundColor = ConsoleColor.Black;
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.Write(m);
                LastTemp = CopyVBlocks(nBlocks);
            }
        }
    }
}
