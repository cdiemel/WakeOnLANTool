using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakeOnLANTool
{
    public partial class WOLToolForm1 : Form
    {
        public WOLToolForm1()
        {
            InitializeComponent();
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            this.OutputBox.Text += "test" + Environment.NewLine;
        }

        private void HostnameInput_ModifiedChanged(object sender, EventArgs e)
        {
            //this.OutputBox.Text += e.ToString() + Environment.NewLine;
            //this.OutputBox.Text += sender.ToString() + Environment.NewLine;
            //MessageBox.Show("You are in the TextBoxBase.ModifiedChanged event.");
        }

        private void getIPFromHostname(object sender, EventArgs e)
        {
            //this.OutputBox.Text += e.ToString() + Environment.NewLine;
            string hostname = this.HostnameInput.Text + Helpers.domain;
            this.OutputBox.Text += $"Hostname: {hostname}" + Environment.NewLine;
            try
            {
                IPAddress ip = Helpers.getIPfromHostname(hostname);
                this.IPAddressInput.Text = ip.ToString();
                this.IPAddressInput.ReadOnly = true;
                this.OutputBox.Text += $"IP: {ip.ToString()}" + Environment.NewLine;
            } catch (Exception ip_except)
            {
                this.IPAddressInput.ReadOnly = false;
            }
            
        }
    }

    public static class Helpers
    {
        static public string domain = ".lan";

        public static IPAddress getIPfromHostname(string hostname)
        {
            IPHostEntry host;
            try
            {
                host = Dns.GetHostEntry(hostname);
            } catch (Exception hostname_except)
            {
                Console.WriteLine(hostname_except.ToString());
                //return new IPAddress(0x00000000);
                //return new IPAddress(0x4F50A8C0);
                throw hostname_except;
            }
            Console.WriteLine(host.HostName);
            //Console.WriteLine(host.ToString());
            //Console.WriteLine(host.HostName);
            //Console.WriteLine(host.AddressList.ToArray().ToString());
            foreach(IPAddress addr in host.AddressList)
            {
                if(addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine(addr.ToString());
                    Console.WriteLine(addr.AddressFamily);
                    return addr;
                }
            }

            // 192.168.80.79
            return new IPAddress(0x00000000);
            //return new IPAddress(0x4F50A8C0);

        }
    }
}
