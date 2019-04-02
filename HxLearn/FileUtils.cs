using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn
{
    public static class FileUtils
    {

        public static string GetProPath()
        {
            string str = Assembly.GetExecutingAssembly().CodeBase;

            
            int last = str.IndexOf("/bin/Debug");
            str = str.Substring(8,last-8);
            return str;
        }

    }
}
