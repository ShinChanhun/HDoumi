namespace Doumi.Types
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    public class Certificate
    {
        public string[] AdminList;
        public string[] GuestList;
        public string[] CustomerList;
        public bool Connect;
        private string Version;

        public void Abort()
        {
            Process.GetCurrentProcess().Kill();
        }

        public bool Access(string name)
        {
            foreach (string str in this.CustomerList)
            {
                if (string.Compare(str, name) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Flag(string ver)
        {
            if (!this.Connect || (ver != this.Version))
            {
                return false;
            }
            return true;
        }

        public bool Start()
        {
            try
            {
                string str = new StreamReader(WebRequest.Create("http://abdo.tistory.com/rss").GetResponse().GetResponseStream()).ReadToEnd();
                int startIndex = str.IndexOf("Version =") + 10;
                int num2 = str.IndexOf("Connect =") + 10;
                int num3 = str.IndexOf("CustomerList = {") + 0x10;
                int index = str.IndexOf("};");
                string str2 = str.Substring(startIndex, 7);
                string str3 = str.Substring(num2, 1);
                string str4 = str.Substring(num3, index - num3);
                this.Connect = str3 == "1";
                this.Version = str2;
                char[] separator = new char[] { ',' };
                this.CustomerList = str4.Split(separator);
                return true;
            }
            catch (WebException exception)
            {
                Console.WriteLine("주소값이 유효하지 않거나 열리지 않는 사이트입니다.\n\n" + exception.Message);
                Console.ReadLine();
                return false;
            }
            catch (Exception exception2)
            {
                Console.WriteLine(exception2.Message);
                Console.ReadLine();
                return false;
            }
        }
    }
}

