using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.GameObject
{
    interface IGameObject
    {
        void Draw();

        void Remove();

        void MovePeer();
    }
}
