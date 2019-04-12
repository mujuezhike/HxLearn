using HxLearn.Extension;
using HxLearn.GameManage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace HxLearn
{
    class Program
    {
        

        static void Main(string[] args)
        {

            ControlManager.Instance.StartControl();

            Thread.Sleep(10000);

            ControlManager.Instance.EndControl();

           Thread.Sleep(1000000);
            
            Console.ReadLine();

            Bitmap[] bmc = new Bitmap[5];
            bmc[0] = new Bitmap(@"D:\csharp\ozy\ozy\shijieditu.jpg");
            bmc[1] = new Bitmap(@"D:\csharp\ozy\ozy\cloud.png");
            bmc[2] = new Bitmap(@"D:\csharp\ozy\ozy\cloud2.png");
            bmc[3] = new Bitmap(@"D:\csharp\ozy\ozy\cloudsmall.png");

            for (int i = 0; i < 1000; i++)
            {
                ImageLoader.LoadBitMap(ViewStatic.BackLayer.map, bmc[0], 0, 0, 100, 60);
                ViewStatic.InitLayer(ref ViewStatic.MidLayer);
                ImageLoader.LoadBitMap(ViewStatic.MidLayer.map, bmc[2], 50 - i % 50, 15);
                ViewStatic.InitLayer(ref ViewStatic.FrontLayer);
                ImageLoader.LoadBitMap(ViewStatic.FrontLayer.map, bmc[3], 10 + i % 50, 30 - i % 30);
                ViewStatic.InitLayer(ref ViewStatic.EffectLayer);
                ImageLoader.LoadBitMap(ViewStatic.EffectLayer.map, bmc[1], 0 + i % 50, 10);
                ImageLoader.Show(ViewStatic.EffectLayer, ViewStatic.FrontLayer, ViewStatic.MidLayer, ViewStatic.BackLayer);

                Thread.Sleep(15);
            }

            Console.ReadLine();
        }

        public static void Sort(List<int> list, Comparison<int> sr)
        {
            //用 Comparison 判断 冒泡排序
        }

        public static void Show(List<int> list)
        {
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
        }

        public static int SortAsc(int x, int y) {
            return x-y;
        }

        public static int SortDesc(int x, int y)
        {
            return y - x ;
        }
       
    }

    public class EmailSender
    {

        public event EventHandler<EmailMsgArgs> NewMail;
        protected virtual void OnNewMail(EmailMsgArgs args)
        {
            args.Raise<EmailMsgArgs>(this, ref NewMail);
        }

        public void SimulateNewMail(string from, string to, string subject)
        {
            EmailMsgArgs args = new EmailMsgArgs(from, to, subject);

            this.OnNewMail(args);
            Console.WriteLine("SimulateNewMail:From:" + args.From);
            Console.WriteLine("SimulateNewMail:To:" + args.To);
            Console.WriteLine("SimulateNewMail:Subject:" + args.Subject);
        }

    }

    public class EmailMsgArgs : EventArgs
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public EmailMsgArgs(string from, string to, string subject)
        {
            this.From = from;
            this.To = to;
            this.Subject = subject;
        }
    }
    public class EmailReciver
    {
        public EmailReciver(EmailSender es)
        {
            es.NewMail += ReciveMsg;
        }

        private void ReciveMsg(object sender
            , EmailMsgArgs eventDelegate)
        {
            Console.WriteLine("ReciveMsg:From:" + eventDelegate.From);
            Console.WriteLine("ReciveMsg:To:" + eventDelegate.To);
            Console.WriteLine("ReciveMsg:Subject:" + eventDelegate.Subject);
        }

        public void Unregister(EmailSender es)
        {
            es.NewMail -= ReciveMsg;
        }

        public static void GetMoneyA(string inputStr)
        {
            Console.WriteLine(inputStr);
        }

        public static void GetMoneyB(string inputStr)
        {
            Console.WriteLine(inputStr);
        }
    }

    public delegate void GetMoney(string inputStr);

    public delegate int Comparison(int x, int y);


}
