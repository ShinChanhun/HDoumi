namespace Doumi
{
    using Doumi.Nexon.IO;
    using Doumi.Nexon.Net;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    public static class Metafile
    {
        private static List<FileDescription> files = new List<FileDescription>();

        public static void CacheFile(FileInfo fileInfo)
        {
            //files.Add(new FileDescription(fileInfo.Name, Crc32Provider.ComputeChecksum(CompressionProvider.Inflate(File.ReadAllBytes(fileInfo.FullName)))));
        }

        public static void List(NexonPacket packet)
        {
            packet.WriteU2((ushort) files.Count);
            foreach (FileDescription description in files)
            {
                packet.WriteC1(description.Name);
                packet.WriteU4(description.Hash);
            }
        }

        private class FileDescription
        {
            //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
            //private uint <Hash>k__BackingField;
            //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
            //private string <Name>k__BackingField;

            public FileDescription(string name, uint hash)
            {
                this.Name = name;
                this.Hash = hash;
            }

            public uint Hash { get; set; }

            public string Name { get; set; }
        }
    }
}

