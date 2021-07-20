using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TMTD
{
    class Utils
    {
        public static class EnemiesReader 
        {
            public static Enemies ReadEnemiesFromFile(string path) 
            {
                Enemies e = new Enemies();
                string[] lines;
                try
                {
                    lines = File.ReadAllLines(path);
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                    throw;
                }
                string name = lines[0];
                return e;
            }
        }
           
    }
}
