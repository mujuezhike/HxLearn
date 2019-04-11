using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HxLearn.Extension
{
    static class EventArgExtension
    {
        public static void Raise<TEventArgs>(this TEventArgs e,Object sender
            ,ref EventHandler<TEventArgs> eventDelegate)
            where TEventArgs:EventArgs
        {
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);
            if (null != temp)
            {
                temp(sender, e);
            }
        }

    }
}
