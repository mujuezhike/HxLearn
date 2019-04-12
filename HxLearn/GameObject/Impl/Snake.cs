using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HxLearn.CoreEngine;
using static HxLearn.CoreEngine.ImageLoader;
using HxLearn.GameManage;

namespace HxLearn.GameObject.Impl
{
    enum SnakeType
    {
        Default,
    }
    class Snake : GameObjectInterface
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

        public static Snake mainSnake;

        public int X { get; set; }
        public int Y { get; set; }
        public LinkedList<Point> Body { get; set; }
        
        public Direction Dect { get; set; }

        public Snake()
        {

        }
        public Snake(SnakeType t)
        {
            this.X = 10;
            this.Y = 10;
            this.Body = new LinkedList<Point>();
            Point p1 = new Point();
            p1.x = 10;
            p1.y = 10;
            this.Body.AddLast(p1);
            Point p2 = new Point();
            p2.x = 9;
            p2.y = 10;
            this.Body.AddLast(p2);
            Point p3 = new Point();
            p3.x = 8;
            p3.y = 10;
            this.Body.AddLast(p3);
            Point p4 = new Point();
            p4.x = 7;
            p4.y = 10;
            this.Body.AddLast(p4);
            this.Dect = Direction.Right;
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

        public void Move()
        {
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

            Point tail = Body.Last.Previous.Value;


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

                    vb.bColor = ConsoleColor.DarkRed;

                }
                else
                {
                    vb.bColor = ConsoleColor.Red;
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

        public void DoTurn(int i)
        {
            if (i % 1 == 0)
            {
                Move();
            }
        }

        public Layer GetLayer()
        {
            return ViewStatic.FrontLayer;
        }
    }
}
