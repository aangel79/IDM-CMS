/***************************************************************************************************

Copyright (c) 2018 Intellectual Ventures Property Holdings, LLC (IVPH) All rights reserved.

EMOD is licensed under the Creative Commons Attribution-Noncommercial-ShareAlike 4.0 License.
To view a copy of this license, visit https://creativecommons.org/licenses/by-nc-sa/4.0/legalcode

***************************************************************************************************/

using System.IO;

namespace matfilelib
{
    class ArrayName : IElement
    {
        public ArrayName(string name)
        {
            Name = name;
        }

        public uint Size
        {
            get
            {
                if (Name.Length > 4)
                {
                    var size = (uint) (8 + ((Name.Length + 7) & ~7));

                    return size;
                }

                return 8;
            }
        }

        public string Name { get; set; }

        public void WriteToStream(BinaryWriter binaryWriter)
        {
            if (Name.Length > 4)
            {
                binaryWriter.Write((uint)MatlabType.MiInt8);
                binaryWriter.Write((uint)Name.Length);
                binaryWriter.Write(Name.ToCharArray());
                for (int count = Name.Length; (count & 7) != 0; count++)
                {
                    binaryWriter.Write('\0');
                }
            }
            else
            {
                var arrayFlags = (uint) ((Name.Length << 16) + (uint) MatlabType.MiInt8);
                binaryWriter.Write(arrayFlags);
                binaryWriter.Write(Name.ToCharArray());
                for (int count = Name.Length; count < 4; count++)
                {
                    binaryWriter.Write('\0');
                }
            }
        }
    }
}