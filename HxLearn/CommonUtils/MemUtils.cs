using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.CommonUtils
{
    public static class MemUtils
    {
        public static string GetMemoryAddress(Object o)
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.WeakTrackResurrection);
            IntPtr addr = GCHandle.ToIntPtr(h);
            return "0x" + addr.ToString("X");
        }
    }
}
