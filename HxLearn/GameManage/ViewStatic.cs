using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HxLearn.ImageLoader;

namespace HxLearn.GameManage
{
    class ViewStatic
    {

        public static Layer BackLayer = new Layer();
        public static Layer MidLayer = new Layer();
        public static Layer FrontLayer = new Layer();
        public static Layer EffectLayer = new Layer();

        public static void InitConsole()
        {
            Console.WindowWidth = 200;
            Console.WindowHeight = 61;//实际使用60
            Console.BufferHeight = 61;//实际使用60

        }

        public static Layer InitLayer(ref Layer layer)
        {
            layer.name = "layer";
            layer.map = new VBlock[100, 60];
            for (int i = 0; i < layer.map.GetLength(0); i++)
            {
                for (int j = 0; j < layer.map.GetLength(1); j++)
                {
                    VBlock vb = new VBlock();
                    vb.x = i;
                    vb.y = j;
                    vb.bColor = ConsoleColor.Black;
                    vb.fColor = ConsoleColor.White;
                    vb.font = "　";
                    vb.isTrans = true;
                    vb.isTransF = true;
                    layer.map[i, j] = vb;
                }

            }

            return layer;
        }

    }
    
}
