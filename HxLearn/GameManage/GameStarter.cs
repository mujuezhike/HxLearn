using HxLearn.CoreEngine;
using HxLearn.GameObject;
using HxLearn.GameObject.Impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.GameManage
{
    public class GameStarter
    {

        public static void GameStart()
        {
            
            ViewManager.Instance.Start();
            LogicManager.Instance.Start();

            Snake skp = new Snake(SnakeType.Default);
            Snake.mainSnake = skp;
            LogicManager.lk.AddLast(skp);
            //for (int i = 0; i < 10; i++)
            //{
            //    EnemySnake sk = new EnemySnake(i + 500, ConsoleColor.Red);
            //    LogicManager.lk.AddLast(sk);
            //}

            for (int i=0; i < 16;i++)
            {
                EnemySnake sk = new EnemySnake(i+100/*,ConsoleColor.Blue*/);
                LogicManager.lk.AddLast(sk);
            }
            Cloud cd = new Cloud(20,20, Direction.Right,54);
            Cloud cd1 = new Cloud(85,22, Direction.Left,55);
            //Cloud cd2 = new Cloud(45, 27, Direction.Left);
            //BigCloud bc = new BigCloud(75, 23, Direction.Left);
            LogicManager.lk.AddLast(cd);
            LogicManager.lk.AddLast(cd1);
            //LogicManager.lk.AddLast(cd2);
            //LogicManager.lk.AddLast(bc);

            ControlManager.Instance.Start();
        }
    }
}
