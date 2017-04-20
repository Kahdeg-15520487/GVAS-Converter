using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GVAS_Converter
{
    public static class BinaryReaderExtension
    {
        public static string ReadUE4String(this BinaryReader reader)
        {
            return new string(reader.ReadChars(reader.ReadInt32()));
        }
    }
}
