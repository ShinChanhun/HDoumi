namespace Doumi
{
    using Doumi.Net;
    using Doumi.Nexon.IO;
    using Doumi.Properties;
    using System;
    using System.Drawing;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    internal static class Program
    {
        public static FormMain Form;
        public static ProxyServer[] Servers = new ProxyServer[3];
        public static Image[] SkillIcons;
        public static Image[] SpellIcons;

        [DllImport("KERNEL32.DLL")]
        public static extern void Beep(int freq, int dur);
        [STAThread]
        private static int Main()
        {
            int num;
            try
            {
                NexonFileFormat<NexonEpfFile>.FromBuffer(Resources.SkillEpf).RenderTo(ref SkillIcons, NexonFileFormat<NexonPalFile>.FromBuffer(Resources.ImagePal));
                NexonFileFormat<NexonEpfFile>.FromBuffer(Resources.SpellEpf).RenderTo(ref SpellIcons, NexonFileFormat<NexonPalFile>.FromBuffer(Resources.ImagePal));
                Servers[0] = new ProxyServer(new IPAddress(727016914L), 2610);
                Servers[1] = new ProxyServer(new IPAddress(727016914L), 10011);
                Servers[2] = new ProxyServer(new IPAddress(727016914L), 10021);
                ProxyServer[] servers = Servers;
                for (int i = 0; i < servers.Length; i++)
                {
                    servers[i].Start();
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FormMain mainForm = new FormMain();
                Form = mainForm;
                Application.Run(mainForm);
                ProxyServer[] serverArray2 = Servers;
                for (int j = 0; j < serverArray2.Length; j++)
                {
                    serverArray2[j].Abort();
                }
                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine("ERROR: {0}", exception.Message);
                num = -1;
            }
            return num;
        }
    }
}

