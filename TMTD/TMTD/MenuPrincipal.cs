using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;
using System.IO;

namespace TMTD
{
    class MenuPrincipal
    {
        private string[] Lines;
        private int ResAnswer;
        private uint Width;
        private uint Height;
        public  MenuPrincipal () 
        {
          
        }
        public void ShowMenu() 
        {
            try
            {
                Lines = File.ReadAllLines("/Res/Resoluciones.txt");
            }
            catch (Exception)
            {

                throw;
            }
            Console.WriteLine("Que Resolucion desea?");
            Console.WriteLine("0 = 800 x 600 - 1 = 600 x 1024 - 2 = 720 x 1280 - 3 = 1024 x 768");
            Console.WriteLine("4 = 1280 x 1024 - 5 = 1360 x 760 - 6 = 1366 x 768 - 7 = 1380 x 768");
            Console.WriteLine("8 = 1440 x 900 - 9 = 1600 x 900 - 10 = 1680 x 1050 - 11 = 1920 x 1080");
            ResAnswer = Convert.ToInt32(Console.ReadKey());
            switch (ResAnswer)
            {
                case 0:
                    Width = Convert.ToUInt32(Lines[0]);
                    Height = Convert.ToUInt32(Lines[1]);
                    break;
                case 1:
                    Width = Convert.ToUInt32(Lines[2]);
                    Height = Convert.ToUInt32(Lines[3]);
                    break;
                case 2:
                    Width = Convert.ToUInt32(Lines[4]);
                    Height = Convert.ToUInt32(Lines[5]);
                    break;
                case 3:
                    Width = Convert.ToUInt32(Lines[6]);
                    Height = Convert.ToUInt32(Lines[7]);
                    break;
                case 4:
                    Width = Convert.ToUInt32(Lines[8]);
                    Height = Convert.ToUInt32(Lines[9]);
                    break;
                case 5:
                    Width = Convert.ToUInt32(Lines[10]);
                    Height = Convert.ToUInt32(Lines[11]);
                    break;
                case 6:
                    Width = Convert.ToUInt32(Lines[12]);
                    Height = Convert.ToUInt32(Lines[13]);
                    break;
                case 7:
                    Width = Convert.ToUInt32(Lines[14]);
                    Height = Convert.ToUInt32(Lines[15]);
                    break;
                case 8:
                    Width = Convert.ToUInt32(Lines[16]);
                    Height = Convert.ToUInt32(Lines[17]);
                    break;
                case 9:
                    Width = Convert.ToUInt32(Lines[18]);
                    Height = Convert.ToUInt32(Lines[19]);
                    break;
                case 10:
                    Width = Convert.ToUInt32(Lines[20]);
                    Height = Convert.ToUInt32(Lines[21]);
                    break;
                case 11:
                    Width = Convert.ToUInt32(Lines[22]);
                    Height = Convert.ToUInt32(Lines[23]);
                    break;
                default:
                    Width = Convert.ToUInt32(Lines[7]);
                    Height = Convert.ToUInt32(Lines[8]);
                    break;
            }
        }
        public uint GetScreenWidth() 
        {
            return Width;     
        }
        public uint GetScreenHeith() 
        {
            return Height;
        }
    }
}
