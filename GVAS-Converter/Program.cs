using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GVAS_Converter
{
    class Program
    {

        static void Main(string[] args)
        {
            // "GVAS" in ASCII in little endian
            uint GVASMagic = 0x53415647;

            if (args.Length != 3)
            {
                System.Console.WriteLine("GVAS-Converter\nA program for converting Unreal Engine 4 GVAS config files to JSON and back.\n\nUsage: \n- Converting to JSON: GVAS-Converter json <savegame.bin> <output.json>\n- Converting from JSON: GVAS-Converter raw <input.json> <savegame.bin>\n\nShould support most UE4 games. Please file an issue on GitHub if it does not and support will be added promptly.");
                return;
            }
            else
            {
                try
                {
                    if (args[0] == "json")
                    {

                        // Setup filestreams
                        FileStream configStream = new FileStream(args[1], FileMode.Open, FileAccess.ReadWrite);
                        FileStream jsonStream = new FileStream(args[2], FileMode.Create, FileAccess.ReadWrite);

                        // Setup reader/writer
                        BinaryReader reader = new BinaryReader(configStream);
                        BinaryWriter writer = new BinaryWriter(jsonStream);

                        System.Console.WriteLine("GVAS-Converter\n");

                        if(reader.ReadUInt32() != GVASMagic)
                        {
                            System.Console.WriteLine("Invalid header magic! Input file is probably not a GVAS config file.");
                            return;
                        }

                        // Read unknown value
                        reader.ReadUInt32();

                        System.Console.WriteLine("Engine version:" + reader.ReadUInt32());

                        // Unknown values (?)
                        reader.ReadUInt16();
                        reader.ReadUInt16();
                        reader.ReadUInt32();
                        reader.ReadUInt16();

                        System.Console.WriteLine("Game name and version: " + reader.ReadUE4String());




                    }
                    else if(args[0] == "raw")
                    {
                        System.Console.WriteLine("Not implemented yet.");
                        return;
                    }

                    else
                    {
                        System.Console.WriteLine("Invalid mode selected: " + args[0]+"\n\n");
                        System.Console.WriteLine("GVAS-Converter\nA program for converting Unreal Engine 4 GVAS config files to JSON and back.\n\nUsage: \n- Converting to JSON: GVAS-Converter json <savegame.bin> <output.json>\n- Converting from JSON: GVAS-Converter raw <input.json> <savegame.bin>\n\nShould support most UE4 games. Please file an issue on GitHub if it does not and support will be added promptly.");
                        return;
                    }



                }
                // Bit of error handling for when the file is either not there or unaccessible
                catch (FileNotFoundException)
                {
                    System.Console.WriteLine("The file you are trying to convert cannot be found.");
                    return;
                }
                catch (UnauthorizedAccessException)
                {
                    System.Console.WriteLine("The file you are trying to convert could not be accessed.");
                }
            }
        
        }
    }
}
