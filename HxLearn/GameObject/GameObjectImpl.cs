using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HxLearn.CoreEngine;

namespace HxLearn.GameObject
{
    class GameObjectImpl : GameObjectInterface
    {
        public bool NeedDeadCheck() {
            return true;
        }
        public int Id { get; set; }
        public int GetId()
        {
            return Id;
        }
        public void DoTurn(int i)
        {
            throw new NotImplementedException();
        }

        public int Draw()
        {
            throw new NotImplementedException();
        }

        public ImageLoader.VBlock[] GetAbsoluteViewBlocks()
        {
            throw new NotImplementedException();
        }

        public int GetBlockType()
        {
            throw new NotImplementedException();
        }

        public ImageLoader.Layer GetLayer()
        {
            throw new NotImplementedException();
        }

        public ImageLoader.Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public ImageLoader.VBlock[] GetViewBlocks()
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
