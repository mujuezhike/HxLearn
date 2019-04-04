using HxLearn.GameObject;
using HxLearn.GameStatic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HxLearn
{
    class Program
    {
        static void Main(string[] args)
        {
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
            
            /*
            Monster er = new Monster();
            int i = er[1];
            er.Name = "ername";
            EliteMonster em = 32;
            em.Name = "sds";
            Monster emm = em;
            em = (EliteMonster)emm;

            string ename = (er as EliteMonster).Name;
            Console.WriteLine(ename);

                var client = new HttpClient();
            var uri = new Uri(Uri.EscapeUriString("http://www.baidu.com"));
            var str = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result.ToString();

            GetName("http://www.baidu.com");
            Console.WriteLine("cc:1");


            string s = "{'id':14,'name':'dsss'}";

            Monster rb = JsonConvert.DeserializeObject<Monster>(s);
            Console.WriteLine(rb.Id);
            Console.WriteLine(rb.Name);

            string m = JsonConvert.SerializeObject(rb);
            Console.WriteLine(m);

            string ls = "[{'id':14,'name':'dsss'},{'id':15,'name':'dcss'},{'id':16,'name':'90ss'}]";
            List<Monster> lm = JsonConvert.DeserializeObject<List<Monster>>(ls);

            Console.WriteLine(lm[0].Id);
            Console.WriteLine(lm[1].Id);
            Console.WriteLine(lm[2].Name);

            string ml = JsonConvert.SerializeObject(lm);
            Console.WriteLine(ml);
            
            DateTime dt = DateTime.Now;
           
            Console.WriteLine(string.Format("{0:D}", dt));
            Console.WriteLine(string.Format("{0:d}", dt));
            Console.WriteLine(string.Format("{0:yy-MM-dd hh:mm:ss}", dt));
            Console.ReadLine();
            */
        }

        async static void GetName(string uri)
        {
            var client = new HttpClient();
            var task = await client.GetAsync(uri);
            Thread.Sleep(1000);
            Console.WriteLine( "cc:2");
        }
    }
}
