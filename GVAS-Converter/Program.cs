using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVAS_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("GVAS-Converter\nA program for converting Unreal Engine 4 GVAS config files to JSON and back.\n\nUsage: \n- Converting to JSON: GVAS-Converter <savegame.bin> <output.json>\n- Converting from JSON: GVAS-Converter <input.json> <savegame.bin>\n\nShould support most UE4 games. Please file an issue on GitHub if it does not and support will be added promptly.");
                return;
            }
        }
    }
}
