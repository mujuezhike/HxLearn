using HxLearn.GameStatic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace HxLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 1;
            int l = 4;
            Console.WriteLine("322");
            Debug.WriteLine("4333");
            Console.ReadLine();

            ViewStatic.InitConsole();
            ViewStatic.InitLayer(ref ViewStatic.BackLayer);
            ViewStatic.InitLayer(ref ViewStatic.MidLayer);
            ViewStatic.InitLayer(ref ViewStatic.FrontLayer);
            ViewStatic.InitLayer(ref ViewStatic.EffectLayer);

            Bitmap[] bmc = new Bitmap[5];
            bmc[0] = new Bitmap(@"D:\csharp\ozy\ozy\shijieditu.jpg");
            bmc[1] = new Bitmap(@"D:\csharp\ozy\ozy\cloud.png");
            bmc[2] = new Bitmap(@"D:\csharp\ozy\ozy\cloud2.png");
            bmc[3] = new Bitmap(@"D:\csharp\ozy\ozy\cloudsmall.png");

            for (int i =0; i<1000;i++)
            {
                ImageLoader.LoadBitMap(ViewStatic.BackLayer.map, bmc[0], 0, 0, 100, 60);
                ViewStatic.InitLayer(ref ViewStatic.MidLayer);
                ImageLoader.LoadBitMap(ViewStatic.MidLayer.map, bmc[2], 50-i%50, 15);
                ViewStatic.InitLayer(ref ViewStatic.FrontLayer);
                ImageLoader.LoadBitMap(ViewStatic.FrontLayer.map, bmc[3], 10 + i % 50, 30 - i%30);
                ViewStatic.InitLayer(ref ViewStatic.EffectLayer);
                ImageLoader.LoadBitMap(ViewStatic.EffectLayer.map, bmc[1], 0 + i % 50, 10);
                ImageLoader.Show(ViewStatic.EffectLayer, ViewStatic.FrontLayer, ViewStatic.MidLayer, ViewStatic.BackLayer);

                Thread.Sleep(15);
            }

            Console.ReadLine();
        }

    }
}
