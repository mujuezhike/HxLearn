using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxLearn.GameObject
{
    class GameObjectImpl : GameObjectInterface<int>
    {
        public int Draw()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public static GameObjectImpl operator +(GameObjectImpl o, GameObjectImpl m )
        {
            return new GameObjectImpl();
        }
    }
}
