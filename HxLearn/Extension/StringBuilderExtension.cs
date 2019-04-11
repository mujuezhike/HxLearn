using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.Extension
{
    static class StringBuilderExtension
    {
        public static int IndexOf(this StringBuilder sb,Char c)
        {
            for(int i=0;i<sb.Length ;i++)
            {
                if (sb[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
