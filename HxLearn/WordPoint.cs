using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HxLearn.ImageLoader;

namespace HxLearn
{
    class WordPoint
    {
        static string HZK16path = @"/mres/HZK16";
        public static string CharacterToCoding(string character)
        {

            try
            {
                string coding1 = "";
                string[] coding = new string[16];
                string a = "";

                for (int i = 0; i < character.Length; i++)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(character.Substring(i, 1)); //取出二进制编码内容

                    int b0 = (short)(array[0] - 160);

                    int b1 = (short)(array[1] - 160);

                    string lowCode = System.Convert.ToString(b0);//取出高字节编码内容（两位16进制）

                    if (lowCode.Length == 1)
                        lowCode = "0" + lowCode;

                    string hightCode = System.Convert.ToString(b1);//取出高字节编码内容（两位16进制）

                    if (hightCode.Length == 1)
                        hightCode = "0" + hightCode;

                    //qw_show.Text = lowCode + hightCode;//显示区位信息;

                    //coding += (lowCode + hightCode);//加入到字符串中,
                    int b = (94 * (b0 - 1) + (b1 - 1)) * 32;
                    FileStream fs = new FileStream(FileUtils.GetProPath()+ HZK16path, FileMode.Open, FileAccess.Read);
                    byte[] desBytes = new byte[fs.Length];
                    fs.Read(desBytes, 0, desBytes.Length);

                    //读取字模信息;

                    //string c="";
                    int x = 0;
                    for (int j = b; j < b + 32; x++)
                    {
                        coding[x] = characterLength(Convert.ToString(desBytes[j], 2), 8) + characterLength(Convert.ToString(desBytes[j + 1], 2), 8);
                        coding1 += characterLength(Convert.ToString(+desBytes[j], 16), 2) + " " + characterLength(Convert.ToString(+desBytes[j + 1], 16), 2) + " ";
                        j = j + 2;

                    }
                    for (int y = 0; y < coding.Length; y++)
                    {
                        for (int y1 = 0; y1 < 16; y1++)
                        {
                            if (Convert.ToString(coding[y][y1]) != "1")
                            {
                                a += "　";
                            }
                            else
                            {
                                a += "▇";
                            }

                        }
                        a += "\r\n";

                    }


                    //zm_show.Text = coding1;
                    fs.Close();

                }
                return a;
            }
            catch (Exception)
            {
                return "";
            }

        }

        public static VBlock[,] LoadCharacterToCoding(VBlock[,] layer, string character, int xr, int yr, ConsoleColor cl)
        {
            try
            {
                string coding1 = "";
                string[] coding = new string[16];
                string a = "";

                for (int i = 0; i < character.Length; i++)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(character.Substring(i, 1)); //取出二进制编码内容

                    int b0 = (short)(array[0] - 160);

                    int b1 = (short)(array[1] - 160);

                    string lowCode = System.Convert.ToString(b0);//取出高字节编码内容（两位16进制）

                    if (lowCode.Length == 1)
                        lowCode = "0" + lowCode;

                    string hightCode = System.Convert.ToString(b1);//取出高字节编码内容（两位16进制）

                    if (hightCode.Length == 1)
                        hightCode = "0" + hightCode;

                    //qw_show.Text = lowCode + hightCode;//显示区位信息;

                    //coding += (lowCode + hightCode);//加入到字符串中,
                    int b = (94 * (b0 - 1) + (b1 - 1)) * 32;
                    FileStream fs = new FileStream(FileUtils.GetProPath() + HZK16path, FileMode.Open, FileAccess.Read);
                    byte[] desBytes = new byte[fs.Length];
                    fs.Read(desBytes, 0, desBytes.Length);

                    //读取字模信息;

                    //string c="";
                    int x = 0;
                    for (int j = b; j < b + 32; x++)
                    {
                        coding[x] = characterLength(Convert.ToString(desBytes[j], 2), 8) + characterLength(Convert.ToString(desBytes[j + 1], 2), 8);
                        coding1 += characterLength(Convert.ToString(+desBytes[j], 16), 2) + " " + characterLength(Convert.ToString(+desBytes[j + 1], 16), 2) + " ";
                        j = j + 2;

                    }
                    for (int y = 0; y < coding.Length; y++)
                    {
                        for (int y1 = 0; y1 < 16; y1++)
                        {
                            if (Convert.ToString(coding[y][y1]) != "1")
                            {
                                VBlock vb = new VBlock();
                                vb.x = y1 + xr;
                                vb.y = y + yr;
                                vb.bColor = cl;
                                vb.fColor = cl;
                                vb.font = "　";
                                vb.isTrans = true;
                                layer[y1 + xr, y + yr] = vb;
                            }
                            else
                            {
                                VBlock vb = new VBlock();
                                vb.x = y1 + xr;
                                vb.y = y + yr;
                                vb.bColor = cl;
                                vb.fColor = cl;
                                vb.font = "　";
                                vb.isTrans = false;
                                layer[y1 + xr, y + yr] = vb; ;
                            }

                        }

                    }


                    //zm_show.Text = coding1;
                    fs.Close();

                }
                return layer;
            }
            catch (Exception)
            {
                return layer;
            }
        }

        public static string characterLength(string character, int l)
        {

            while (character.Length != l)
            {
                character = "0" + character;
            };
            return character;

        }
    }
}
