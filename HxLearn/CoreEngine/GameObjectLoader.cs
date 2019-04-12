using HxLearn.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HxLearn.CoreEngine.ImageLoader;

namespace HxLearn.CoreEngine
{
    class GameObjectLoader
    {
        static public VBlock[,] LoadGameObject(VBlock[,] layer, GameObject.GameObjectInterface go)
        {
            lock (ImageLoader.objlock)
            {
                if (go.GetBlockType() == 0)
                {
                    for (int i = 0; i < go.GetViewBlocks().Length; i++)
                    {
                        VBlock vb = go.GetViewBlocks()[i];
                        Point p = go.GetPosition();
                        if (!vb.isTrans)
                        {
                            layer[vb.x + p.x, vb.y + p.y] = vb;
                        }
                        
                    }

                }

                if (go.GetBlockType() == 1)
                {
                    for (int i = 0; i < go.GetAbsoluteViewBlocks().Length; i++)
                    {
                        VBlock vb = go.GetAbsoluteViewBlocks()[i];
                        if (!vb.isTrans)
                        {
                            layer[vb.x, vb.y] = vb;
                        }
                    }
                }
                

                return layer;
            }
        }

    }
}
