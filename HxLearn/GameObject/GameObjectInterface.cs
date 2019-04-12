using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HxLearn.CoreEngine.ImageLoader;

namespace HxLearn.GameObject
{
    public interface GameObjectInterface
    {
        bool NeedDeadCheck();
        int GetId();
        //GetBlockType 0 
        VBlock[] GetViewBlocks();

        //GetBlockType 1
        VBlock[] GetAbsoluteViewBlocks();

        Point GetPosition();

        int GetBlockType();

        Layer GetLayer();

        /// <summary>
        /// i 标准时间间隔
        /// </summary>
        /// <param name="i"></param>
        void DoTurn(int i);

    }
}
