using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.GameObject
{
    public interface GameObjectInterface<out T>
    {
        T Draw();

        void Remove();

        void Move();
    }
}
