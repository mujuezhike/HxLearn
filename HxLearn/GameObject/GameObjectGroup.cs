using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.GameObject
{
    public class GameObjectGroup<T>
    {
        public T GetOne()
        {
            return GetOne<string>("");
        }

        public T GetOne(T t)
        {
            return default(T);
        }

        public S GetOne<S>(S s,T t)
        {
            return default(S);
        }

        public T GetOne<S>(S s)
        {
            return default(T);
        }
    }

}
