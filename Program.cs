using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public WakeOnLANSession(Helpers.IPv4Address ip, Helpers.MACAddress mac)
        {
            this.ipAddress = ip;
            this.macAddress = mac;
        }
        public void Send()
        {

        }
        private class Packet
        {
            public Packet()
            {

            }
        }
    }
}
