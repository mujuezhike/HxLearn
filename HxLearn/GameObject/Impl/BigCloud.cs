using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HxLearn.CoreEngine;
using static HxLearn.CoreEngine.ImageLoader;
using HxLearn.GameManage;

namespace HxLearn.GameObject.Impl
{
    class BigCloud : GameObjectInterface
    {
        public bool NeedDeadCheck()
        {
            return false;
        }
        public int Id { get; set; }
        public int GetId() {
            return Id;
        }

        public static Bitmap cloudImage;
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Dect { get; set; }

        static BigCloud()
        {
            cloudImage = new Bitmap(@"D:\csharp\ozy\ozy\cloud2.png");
        }

        public BigCloud()
        {

        }

        public BigCloud(int x, int y, Direction d)
        {
            this.X = x;
            this.Y = y;
            this.Dect = d;
        }

        public void DoTurn(int i)
        {
            if (i % 5 == 0)
            {
                if (Direction.Top.Equals(Dect))
                {
                    if (Y == 0)
                    {
                        Y = 50;
                    }
                    else
                    {
                        Y = (Y - 1) % 50;
                    }
                }
                if (Direction.Bottom.Equals(Dect))
                {
                    Y = (Y + 1) % 50;
                }
                if (Direction.Left.Equals(Dect))
                {
                    if (X == 0)
                    {
                        X = 90;
                    }
                    else
                    {
                        X = (X - 1) % 90;
                    }
                }
                if (Direction.Right.Equals(Dect))
                {
                    X = (X + 1) % 90;
                }
                if (Direction.Stop.Equals(Dect))
                {
                }
            }
        }

        public ImageLoader.VBlock[] GetAbsoluteViewBlocks()
        {
            throw new NotImplementedException();
        }

        public int GetBlockType()
        {
            return 0;
        }

        public Layer GetLayer()
        {
            return ViewStatic.EffectLayer;
        }

        public ImageLoader.Point GetPosition()
        {
            ImageLoader.Point p = new ImageLoader.Point();
            p.x = X;
            p.y = Y;
            return p;
        }

        public VBlock[] GetViewBlocks()
        {
            VBlock[,] vbm = new VBlock[20, 20];
            ImageLoader.LoadBitMap(vbm, cloudImage, 0, 0);

            VBlock[] vbl = new VBlock[400];
            for (int i = 0; i < 400; i++)
            {
                vbl[i] = vbm[i / 20, i % 20];
            }

            return vbl;
        }
    }
}
