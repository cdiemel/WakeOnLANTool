using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakeOnLANTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WOLToolForm1());
        }
    }

    public class WakeOnLANSession
    {
        private readonly Helpers.IPv4Address ipAddress;
        private readonly Helpers.MACAddress macAddress;
        private byte byte_WOLPort = 8;
        private readonly IPEndPoint endPoint;

        public WakeOnLANSession(Helpers.IPv4Address ip, Helpers.MACAddress mac)
        {
            this.ipAddress = ip;
            this.macAddress = mac;
            this.endPoint = new IPEndPoint(this.ipAddress.ToLong(), this.byte_WOLPort);
        }
        public void Send()
        {
            new Packet(this.macAddress);
        }
        private class Packet
        {
            private byte[] test;
            public Packet(Helpers.MACAddress mac)
            {
                String mac16 = String.Concat(Enumerable.Repeat(mac.ToString(), 16));
                byte[] macBytes = Encoding.ASCII.GetBytes(mac16);
                Console.WriteLine(BitConverter.ToString(macBytes).Replace("-", string.Empty));
            }

            public byte[] ToBytes()
            {
                return test;
            }
        }
    }
}
