using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.CommonUtils
{
    static class TypeUtils
    {
        public const int i = 90;
        public static bool IsStruct(object o)
        {
            if (o is ValueType)//首先是值类型
            {
                if (o is Enum)//枚举类型
                {

                }
                else if (o.GetType().IsPrimitive)//是否为基础类型
                {

                }
                else//自定义结构类型
                {
                    return true;
                }
            }

            return false;
        }
    }

    
}
