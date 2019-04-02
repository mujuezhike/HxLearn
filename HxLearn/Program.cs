using HxLearn.GameObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            Monster er = new Monster();
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
