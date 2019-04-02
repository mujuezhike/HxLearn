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
        /// <summary>
        /// 获取项目路径 代码位置
        /// </summary>
        /// <returns></returns>
        public static string GetProPath()
        {
            string str = Assembly.GetExecutingAssembly().CodeBase;
            int last = str.IndexOf("/bin/");
            str = str.Substring(8,last-8);
            return str;
        }

    }
}
