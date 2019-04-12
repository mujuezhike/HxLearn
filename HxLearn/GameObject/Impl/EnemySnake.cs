using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HxLearn.CoreEngine;
using HxLearn.GameManage;
using static HxLearn.CoreEngine.ImageLoader;

namespace HxLearn.GameObject.Impl
{
    class EnemySnake : GameObjectInterface
    {
        public bool NeedDeadCheck()
        {
            return true;
        }
        public int Id { get; set; }
        public int GetId()
        {
            return Id;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public LinkedList<Point> Body { get; set; }
        public Direction Dect { get; set; }
        public ConsoleColor HeadColor { get; set; }
        public ConsoleColor BodyColor { get; set; }


        public static Random rd = new Random();
        public void DoTurn(int i)
        {
            Direction doe = Direction.Stop;
            
            if (i % 1 == 0)
            {
                if (rd.Next(100) < 21)
                {
                    int m = rd.Next(4);
                    if (m == 0)
                    {
                        doe = Direction.Top;
                    }
                    if (m == 1)
                    {
                        doe = Direction.Left;
                    }
                    if (m == 2)
                    {
                        doe = Direction.Right;
                    }
                    if (m == 3)
                    {
                        doe = Direction.Bottom;
                    }
                }

                if (rd.Next(10) < 8 && X < 4 && Dect != Direction.Right)
                {
                    int m = rd.Next(3);
                    if (m == 0)
                    {
                        doe = Direction.Top;
                    }
                    if (m == 1)
                    {
                        doe = Direction.Right;
                    }
                    if (m == 2)
                    {
                        doe = Direction.Bottom;
                    }
                }

                if (rd.Next(10) < 8 &&  X > 86 && Dect != Direction.Left)
                {
                    int m = rd.Next(3);
                    if (m == 0)
                    {
                        doe = Direction.Top;
                    }
                    if (m == 1)
                    {
                        doe = Direction.Left;
                    }
                    if (m == 2)
                    {
                        doe = Direction.Bottom;
                    }
                }

                if (rd.Next(10) < 8 &&  Y < 4 && Dect != Direction.Bottom)
                {
                    int m = rd.Next(3);
                    if (m == 0)
                    {
                        doe = Direction.Right;
                    }
                    if (m == 1)
                    {
                        doe = Direction.Left;
                    }
                    if (m == 2)
                    {
                        doe = Direction.Bottom;
                    }
                }

                if (rd.Next(10) < 8 && Y > 56 && Dect != Direction.Top)
                {
                    int m = rd.Next(3);
                    if (m == 0)
                    {
                        doe = Direction.Right;
                    }
                    if (m == 1)
                    {
                        doe = Direction.Left;
                    }
                    if (m == 2)
                    {
                        doe = Direction.Top;
                    }
                }

                if(((int)doe+(int)Dect) != 1 && ((int)doe + (int)Dect) != 5 && doe!=Direction.Stop)
                {
                    Dect = doe;
                }

                Move();
            }
        }

     
        public EnemySnake()
        {

        }

        public EnemySnake(int id, ConsoleColor cc) : this(cc)
        {
            this.Id = id;
        }
        public EnemySnake(int id) : this((ConsoleColor)(id%16))
        {
            this.Id = id;
        }
        public EnemySnake(ConsoleColor cc):this(SnakeType.Default)
        {
            this.BodyColor = cc;
            if ((int)cc > 8)
            {
                this.HeadColor = cc - 8;
            }else
            {
                this.HeadColor = cc;
            }
            
        }

        public EnemySnake(SnakeType t)
        {
            this.X = 50;
            this.Y = 50;
            this.Body = new LinkedList<Point>();
            Point p1 = new Point();
            p1.x = 50;
            p1.y = 50;
            this.Body.AddLast(p1);
            Point p2 = new Point();
            p2.x = 50;
            p2.y = 51;
            this.Body.AddLast(p2);
            Point p3 = new Point();
            p3.x = 50;
            p3.y = 52;
            this.Body.AddLast(p3);
            Point p4 = new Point();
            p4.x = 50;
            p4.y = 53;
            this.Body.AddLast(p4);
            Point p5 = new Point();
            p5.x = 50;
            p5.y = 54;
            this.Body.AddLast(p5);
            Point p6 = new Point();
            p6.x = 50;
            p6.y = 55;
            this.Body.AddLast(p6);
            Point p7 = new Point();
            p7.x = 50;
            p7.y = 56;
            this.Body.AddLast(p7);
            this.Dect = Direction.Top;
            this.HeadColor = ConsoleColor.DarkRed;
            this.BodyColor = ConsoleColor.Red;
        }

        public void Move()
        {
            //DEBUG
            //Console.SetCursorPosition(0, 0);
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write(Dect.ToString());

            Point head = Body.First();

            Point newp = new Point();

            if (Direction.Top.Equals(Dect))
            {
                newp.x = head.x;
                newp.y = head.y - 1;
                this.Y = this.Y - 1;
            }
            if (Direction.Bottom.Equals(Dect))
            {

                newp.x = head.x;
                newp.y = head.y + 1;
                this.Y = this.Y + 1;

            }
            if (Direction.Left.Equals(Dect))
            {

                newp.x = head.x - 1;
                newp.y = head.y;
                this.X = this.X - 1;

            }
            if (Direction.Right.Equals(Dect))
            {

                newp.x = head.x + 1;
                newp.y = head.y;
                this.X = this.X + 1;

            }

            Body.AddFirst(newp);
            Body.RemoveLast();

        }

        public VBlock[] GetAbsoluteViewBlocks()
        {
            VBlock[] vbs = new VBlock[Body.Count];
            bool isHead = true;
            int i = 0;
            foreach (Point p in Body)
            {
                VBlock vb = new VBlock();
                if (isHead)
                {

                    vb.bColor = this.HeadColor;

                }
                else
                {
                    vb.bColor = this.BodyColor;
                }

                vb.x = p.x;
                vb.y = p.y;
                vb.fColor = ConsoleColor.White;
                vb.font = "　";
                vb.isTrans = false;
                vb.isTransF = false;
                vbs[i] = vb;

                i++;
                isHead = false;
            }

            return vbs;
        }

        public int GetBlockType()
        {
            return 1;
        }

        public Layer GetLayer()
        {
            return ViewStatic.FrontLayer;
        }

        public Point GetPosition()
        {
            Point p = new Point();
            p.x = X;
            p.y = Y;
            return p;
        }

        public VBlock[] GetViewBlocks()
        {
            throw new NotImplementedException();
        }
    }
}
