using HxLearn.CoreEngine;
using HxLearn.GameObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HxLearn.CoreEngine.ImageLoader;

namespace HxLearn.GameManage
{
    class LogicManager
    {
        public static Bitmap[] bmc;

        public static LinkedList<GameObjectInterface> lk = new LinkedList<GameObjectInterface>();
        public static List<int> deadList = new List<int>();
        public static int timeBean = 0;

        private static LogicManager instance;

        public static LogicManager Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new LogicManager();
                }
                return instance;
            }
        }

        private LogicManager()
        {
            bmc = new Bitmap[5];
            bmc[0] = new Bitmap(@"D:\csharp\ozy\ozy\mapmutou.png");
            
        }

        private static bool isContinue = false;
        public void Start()
        {
            if (!isContinue)
            {
                ThreadPool.QueueUserWorkItem(BackLoop, null);
            }
        }

        private static void BackLoop(object o)
        {
            isContinue = true;
            while (isContinue)
            {
                lock (ImageLoader.objlock)
                {
                ViewStatic.InitLayer(ref ViewStatic.BackLayer);
                 
                ImageLoader.LoadBitMap(ViewStatic.BackLayer.map, bmc[0], 0, 0, 100, 60);
                ViewStatic.InitLayer(ref ViewStatic.MidLayer);
                ViewStatic.InitLayer(ref ViewStatic.FrontLayer);
                ViewStatic.InitLayer(ref ViewStatic.EffectLayer);

                    foreach (GameObjectInterface go in lk)
                    {
                        go.DoTurn(timeBean);    
                    }

                    foreach (GameObjectInterface go in lk)
                    {
                        //判断伤害死亡
                        if(go.NeedDeadCheck() && (go.GetPosition().x <0
                            || go.GetPosition().x >= 100
                            || go.GetPosition().y < 0
                            || go.GetPosition().y >= 60))
                        {
                            deadList.Add(go.GetId());
                        }
                             
                    }

                    if(null!= deadList && deadList.Count > 0)
                    {
                        LinkedList<GameObjectInterface> nlk = new LinkedList<GameObjectInterface>();

                        foreach (GameObjectInterface go in lk)
                        {
                            if (!deadList.Contains(go.GetId()))
                            {
                                nlk.AddLast(go);
                            }
                        }

                        deadList = new List<int>();
                        lk = nlk;

                    }
                    
                    foreach (GameObjectInterface go in lk)
                    {
                        
                        Layer ly = go.GetLayer();
                        GameObjectLoader.LoadGameObject(ly.map, go);
                    }


                    timeBean++;
                }
                Thread.Sleep(25);
            }
        }

        public void End()
        {
            isContinue = false;
        }
    }
}
