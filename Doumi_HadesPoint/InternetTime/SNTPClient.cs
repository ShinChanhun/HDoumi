namespace InternetTime
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;

    public class SNTPClient
    {
        public DateTime DestinationTimestamp;
        private const byte offOriginateTimestamp = 0x18;
        private const byte offReceiveTimestamp = 0x20;
        private const byte offReferenceID = 12;
        private const byte offReferenceTimestamp = 0x10;
        private const byte offTransmitTimestamp = 40;
        private byte[] SNTPData = new byte[0x30];
        private const byte SNTPDataLength = 0x30;
        private string TimeServer;

        public SNTPClient(string host)
        {
            this.TimeServer = host;
        }

        private DateTime ComputeDate(ulong milliseconds)
        {
            TimeSpan span = TimeSpan.FromMilliseconds((double) milliseconds);
            DateTime time = new DateTime(0x76c, 1, 1);
            return (time + span);
        }

        public void Connect(bool UpdateSystemTime)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(Dns.GetHostEntry(this.TimeServer).AddressList[0], 0x7b);
                UdpClient client = new UdpClient();
                client.Connect(endPoint);
                this.Initialize();
                client.Send(this.SNTPData, this.SNTPData.Length);
                this.SNTPData = client.Receive(ref endPoint);
                if (!this.IsResponseValid())
                {
                    throw new Exception("Invalid response from " + this.TimeServer);
                }
                this.DestinationTimestamp = DateTime.Now;
            }
            catch (SocketException exception)
            {
                throw new Exception(exception.Message);
            }
            if (UpdateSystemTime)
            {
                this.SetTime();
            }
        }

        private ulong GetMilliSeconds(byte offset)
        {
            ulong num = 0L;
            ulong num2 = 0L;
            for (int i = 0; i <= 3; i++)
            {
                num = (((ulong) 0x100L) * num) + this.SNTPData[offset + i];
            }
            for (int j = 4; j <= 7; j++)
            {
                num2 = (((ulong) 0x100L) * num2) + this.SNTPData[offset + j];
            }
            return ((num * ((ulong) 0x3e8L)) + ((num2 * ((ulong) 0x3e8L)) / ((ulong) 0x100000000L)));
        }

        private void Initialize()
        {
            this.SNTPData[0] = 0x1b;
            for (int i = 1; i < 0x30; i++)
            {
                this.SNTPData[i] = 0;
            }
            this.TransmitTimestamp = DateTime.Now;
        }

        public bool IsResponseValid() => 
            ((this.SNTPData.Length >= 0x30) && (this.Mode == _Mode.Server));

        private void SetDate(byte offset, DateTime date)
        {
            ulong num = 0L;
            ulong num2 = 0L;
            DateTime time = new DateTime(0x76c, 1, 1, 0, 0, 0);
            TimeSpan span = (TimeSpan) (date - time);
            ulong totalMilliseconds = (ulong) span.TotalMilliseconds;
            num = totalMilliseconds / ((ulong) 0x3e8L);
            num2 = ((totalMilliseconds % ((ulong) 0x3e8L)) * ((ulong) 0x100000000L)) / ((ulong) 0x3e8L);
            ulong num4 = num;
            for (int i = 3; i >= 0; i--)
            {
                this.SNTPData[offset + i] = (byte) (num4 % ((ulong) 0x100L));
                num4 /= (ulong) 0x100L;
            }
            num4 = num2;
            for (int j = 7; j >= 4; j--)
            {
                this.SNTPData[offset + j] = (byte) (num4 % ((ulong) 0x100L));
                num4 /= (ulong) 0x100L;
            }
        }

        [DllImport("kernel32.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME time);
        private void SetTime()
        {
            SYSTEMTIME systemtime;
            DateTime time = DateTime.Now.AddMilliseconds((double) this.LocalClockOffset);
            systemtime.year = (short) time.Year;
            systemtime.month = (short) time.Month;
            systemtime.dayOfWeek = (short) time.DayOfWeek;
            systemtime.day = (short) time.Day;
            systemtime.hour = (short) time.Hour;
            systemtime.minute = (short) time.Minute;
            systemtime.second = (short) time.Second;
            systemtime.milliseconds = (short) time.Millisecond;
            SetLocalTime(ref systemtime);
        }

        public override string ToString()
        {
            string str = "Leap Indicator: ";
            switch (this.LeapIndicator)
            {
                case _LeapIndicator.NoWarning:
                    str = str + "No warning";
                    break;

                case _LeapIndicator.LastMinute61:
                    str = str + "Last minute has 61 seconds";
                    break;

                case _LeapIndicator.LastMinute59:
                    str = str + "Last minute has 59 seconds";
                    break;

                case _LeapIndicator.Alarm:
                    str = str + "Alarm Condition (clock not synchronized)";
                    break;
            }
            str = str + "\r\nVersion number: " + this.VersionNumber.ToString() + "\r\nMode: ";
            switch (this.Mode)
            {
                case _Mode.SymmetricActive:
                    str = str + "Symmetric Active";
                    break;

                case _Mode.SymmetricPassive:
                    str = str + "Symmetric Pasive";
                    break;

                case _Mode.Client:
                    str = str + "Client";
                    break;

                case _Mode.Server:
                    str = str + "Server";
                    break;

                case _Mode.Broadcast:
                    str = str + "Broadcast";
                    break;

                case _Mode.Unknown:
                    str = str + "Unknown";
                    break;
            }
            str = str + "\r\nStratum: ";
            switch (this.Stratum)
            {
                case _Stratum.Unspecified:
                case _Stratum.Reserved:
                    str = str + "Unspecified";
                    break;

                case _Stratum.PrimaryReference:
                    str = str + "Primary Reference";
                    break;

                case _Stratum.SecondaryReference:
                    str = str + "Secondary Reference";
                    break;
            }
            string[] textArray1 = new string[] { 
                str, "\r\nLocal time: ", this.TransmitTimestamp.ToString(), "\r\nPrecision: ", this.Precision.ToString(), " s\r\nPoll Interval: ", this.PollInterval.ToString(), " s\r\nReference ID: ", this.ReferenceID.ToString(), "\r\nRoot Delay: ", this.RootDelay.ToString(), " ms\r\nRoot Dispersion: ", this.RootDispersion.ToString(), " ms\r\nRound Trip Delay: ", this.RoundTripDelay.ToString(), " ms\r\nLocal Clock Offset: ",
                this.LocalClockOffset.ToString(), " ms\r\n"
            };
            return string.Concat(textArray1);
        }

        public _LeapIndicator LeapIndicator
        {
            get
            {
                switch (((byte) (this.SNTPData[0] >> 6)))
                {
                    case 0:
                        return _LeapIndicator.NoWarning;

                    case 1:
                        return _LeapIndicator.LastMinute61;

                    case 2:
                        return _LeapIndicator.LastMinute59;
                }
                return _LeapIndicator.Alarm;
            }
        }

        public int LocalClockOffset
        {
            get
            {
                TimeSpan span = (TimeSpan) ((this.ReceiveTimestamp - this.OriginateTimestamp) + (this.TransmitTimestamp - this.DestinationTimestamp));
                return (int) (span.TotalMilliseconds / 2.0);
            }
        }

        public _Mode Mode
        {
            get
            {
                switch (((byte) (this.SNTPData[0] & 7)))
                {
                    case 1:
                        return _Mode.SymmetricActive;

                    case 2:
                        return _Mode.SymmetricPassive;

                    case 3:
                        return _Mode.Client;

                    case 4:
                        return _Mode.Server;

                    case 5:
                        return _Mode.Broadcast;
                }
                return _Mode.Unknown;
            }
        }

        public DateTime OriginateTimestamp =>
            this.ComputeDate(this.GetMilliSeconds(0x18));

        public uint PollInterval =>
            ((uint) Math.Pow(2.0, (double) ((sbyte) this.SNTPData[2])));

        public double Precision =>
            Math.Pow(2.0, (double) ((sbyte) this.SNTPData[3]));

        public DateTime ReceiveTimestamp
        {
            get
            {
                DateTime time = this.ComputeDate(this.GetMilliSeconds(0x20));
                TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                return (time + utcOffset);
            }
        }

        public string ReferenceID
        {
            get
            {
                string str = "";
                switch (this.Stratum)
                {
                    case _Stratum.Unspecified:
                    case _Stratum.PrimaryReference:
                    {
                        string[] textArray1 = new string[] { str, ((char) this.SNTPData[12]).ToString(), ((char) this.SNTPData[13]).ToString(), ((char) this.SNTPData[14]).ToString(), ((char) this.SNTPData[15]).ToString() };
                        return string.Concat(textArray1);
                    }
                    case _Stratum.SecondaryReference:
                        if (this.VersionNumber == 3)
                        {
                            string[] textArray2 = new string[] { this.SNTPData[12].ToString(), ".", this.SNTPData[13].ToString(), ".", this.SNTPData[14].ToString(), ".", this.SNTPData[15].ToString() };
                            string hostNameOrAddress = string.Concat(textArray2);
                            try
                            {
                                return (Dns.GetHostEntry(hostNameOrAddress).HostName + " (" + hostNameOrAddress + ")");
                            }
                            catch (Exception)
                            {
                                return "N/A";
                            }
                            break;
                        }
                        break;

                    default:
                        return str;
                }
                return "N/A";
            }
        }

        public DateTime ReferenceTimestamp
        {
            get
            {
                DateTime time = this.ComputeDate(this.GetMilliSeconds(0x10));
                TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                return (time + utcOffset);
            }
        }

        public double RootDelay
        {
            get
            {
                int num = 0;
                num = (0x100 * ((0x100 * ((0x100 * this.SNTPData[4]) + this.SNTPData[5])) + this.SNTPData[6])) + this.SNTPData[7];
                return (1000.0 * (((double) num) / 65536.0));
            }
        }

        public double RootDispersion
        {
            get
            {
                int num = 0;
                num = (0x100 * ((0x100 * ((0x100 * this.SNTPData[8]) + this.SNTPData[9])) + this.SNTPData[10])) + this.SNTPData[11];
                return (1000.0 * (((double) num) / 65536.0));
            }
        }

        public int RoundTripDelay
        {
            get
            {
                TimeSpan span = (TimeSpan) ((this.DestinationTimestamp - this.OriginateTimestamp) - (this.ReceiveTimestamp - this.TransmitTimestamp));
                return (int) span.TotalMilliseconds;
            }
        }

        public _Stratum Stratum
        {
            get
            {
                byte num = this.SNTPData[1];
                switch (num)
                {
                    case 0:
                        return _Stratum.Unspecified;

                    case 1:
                        return _Stratum.PrimaryReference;
                }
                if (num <= 15)
                {
                    return _Stratum.SecondaryReference;
                }
                return _Stratum.Reserved;
            }
        }

        public DateTime TransmitTimestamp
        {
            get
            {
                DateTime time = this.ComputeDate(this.GetMilliSeconds(40));
                TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                return (time + utcOffset);
            }
            set
            {
                this.SetDate(40, value);
            }
        }

        public byte VersionNumber =>
            ((byte) ((this.SNTPData[0] & 0x38) >> 3));

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }
    }
}

