using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.CommonUtils
{
    class Paixu
    {

        public static void Sort(int[] a)
        {
            int i, j, temp;
            for(j=0;j<a.Length-1;j++)
            {
                for(i=0;i< a.Length - 1 - j; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                    }
                }
            }

        }

    }

   
}
