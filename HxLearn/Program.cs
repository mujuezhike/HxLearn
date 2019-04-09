using HxLearn.GameObject;
using HxLearn.GameStatic;
using HxLibrary;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Xml;

namespace HxLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map["ss"] = "ewe";
            Console.WriteLine(map["ss"]);


            XmlDocument document = new XmlDocument();
            document.Load(FileUtils.GetProPath()+"/res/result.xml");
            XmlElement xd = document.DocumentElement;
            Console.WriteLine(xd.Name);
            Console.WriteLine(xd.ToString());
            Console.WriteLine(xd.Value);
            KeyValuePair<string, string> kv = new KeyValuePair<string, string>("23","sss");
            Console.WriteLine(kv.Key);
            Console.WriteLine(kv.Value);

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
