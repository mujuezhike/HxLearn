using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HxLearn.GameManage
{

    public class ViewManager
    {
        private static ViewManager instance;

        public static ViewManager Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new ViewManager();
                }
                return instance;
            }
        }

        private ViewManager()
        {

        }

        private static bool isContinue = false;
        private static bool isInit = false;

        private static Thread tr;

        public void StartShow()
        {
            if (!isInit)
            {
                initView();
            }

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
                ImageLoader.Show(ViewStatic.EffectLayer, ViewStatic.FrontLayer, ViewStatic.MidLayer, ViewStatic.BackLayer);
                Thread.Sleep(30);
            }
        }

        public void EndShow()
        {
            isContinue = false;
        }

        public void initView()
        {
            ViewStatic.InitConsole();
            ViewStatic.InitLayer(ref ViewStatic.BackLayer);
            ViewStatic.InitLayer(ref ViewStatic.MidLayer);
            ViewStatic.InitLayer(ref ViewStatic.FrontLayer);
            ViewStatic.InitLayer(ref ViewStatic.EffectLayer);
            ThreadPool.SetMaxThreads(5,1);
            isInit = true;

        }
    }
}
