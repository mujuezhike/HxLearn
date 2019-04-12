using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HxLearn.GameManage
{
    class ControlManager
    {
        private static ControlManager instance;

        public static ControlManager Instance
        {
            get
            {
                if(null== instance)
                {
                    instance = new ControlManager();
                }
                return instance;
            }
        }

        private ControlManager()
        {

        }

        private static bool isContinue = false;
        public void StartControl()
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
                char c = Console.ReadKey(true).KeyChar;

                //输出输入
                Console.WriteLine(c);
            }
        }

        public void EndControl()
        {
            isContinue = false;
        }
    }
}
