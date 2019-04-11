namespace Doumi.Net
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public class ProxyPatronSettings
    {
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(ProxyPatronSettings));
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private string <MapRenderingMode>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private byte <MonsterForm>k__BackingField;
        //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
        //private byte <TeleportRange>k__BackingField;

        public ProxyPatronSettings()
        {
            this.MapRenderingMode = "Cartesian";
            this.TeleportRange = 12;
        }

        public static ProxyPatronSettings Load(string filename)
        {
            FileInfo info = new FileInfo(filename);
            if (!info.Exists)
            {
                return new ProxyPatronSettings();
            }
            using (FileStream stream = info.OpenRead())
            {
                return (serializer.Deserialize(stream) as ProxyPatronSettings);
            }
        }

        public static void Save(string filename, ProxyPatronSettings value)
        {
            using (FileStream stream = new FileInfo(filename).Create())
            {
                serializer.Serialize((Stream) stream, value);
            }
        }

        public string MapRenderingMode { get; set; }

        public byte MonsterForm { get; set; }

        public byte TeleportRange { get; set; }
    }
}

