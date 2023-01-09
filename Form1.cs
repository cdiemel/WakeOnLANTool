using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

        private void MACInput_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Console.WriteLine(sender.ToString());
            Console.WriteLine($"hint: {e.RejectionHint.ToString()}");
            Console.WriteLine($"position: {e.Position.ToString()}");
            //throw new System.NotImplementedException();
        }

        private bool ValidIPv4(string ipAddress)
        {
            string pattern  = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.";
            pattern += @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.";
            pattern += @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.";
            pattern += @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            if(!Regex.IsMatch(ipAddress, pattern))
            {
                throw new FormatException($"{ipAddress} is not a valid IPv4 Address.");
            }
            
            return true;

            //throw new System.NotImplementedException();
        }

        private void IPAddressInput_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                this.IPAddressInput.ForeColor = Color.Red;
                this.ToolTip.Show("Invalid IP Address", IPAddressInput, 5000);
                //e.Cancel = true;
                return;
            }
            try
            {
                this.ValidIPv4(this.IPAddressInput.Text);
            }
            catch (FormatException bad_format)
            {
                Console.WriteLine(bad_format.Message);
                this.OutputBox.Text += bad_format.Message + Environment.NewLine;
                this.IPAddressInput.ForeColor = Color.Red;
                this.ToolTip.Show("Invalid IP Address", IPAddressInput, 5000);
                return;
            }

            this.IPAddressInput.ForeColor = Color.Black;
        }

        private void MACInput_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            Console.WriteLine("MACInput_TypeValidationCompleted");
            if (!e.IsValidInput)
            {
                this.MACInput.ForeColor = Color.Red;
                this.ToolTip.Show("Invalid MAC Address", MACInput, 5000);
                e.Cancel = true;
                return;
            }

            this.MACInput.ForeColor = Color.Black;
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
                throw hostname_except;
            }
            Console.WriteLine(host.HostName);
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
            //return new IPAddress(0x4F50A8C0);
            return new IPAddress(0x00000000);

        }
    
        public class MACAddress
        {
            public string rawString;
            public MACAddress(string macString=null)
            {
                this.rawString = macString;
            }

            /// <summary>
            ///     Converts an IP address string to an System.Net.IPAddress instance.
            /// </summary>
            /// <param name="macString">
            ///     A string that contains a MAC address in hexadecimal notation.
            /// <code>
            /// AABBCCDDEEFF
            /// AA:BB:CC:DD:EE:FF
            /// AA-BB-CC-DD-EE-FF
            /// </code>
            /// </param>
            /// <returns>A <see cref="WakeOnLANTool"/>.<see cref="Helpers"/>.<see cref="MACAddress"/> instance.</returns>
            /// <exception cref="System.ArgumentNullException">macString is null</exception>
            /// <exception cref="System.FormatException">macString is not a valid MAC address</exception>
            public static MACAddress Parse(string macString)
            {
                if (macString is null) { throw new ArgumentNullException("macString", "is null"); }
                macString = macString.ToUpper();
                string pattern = @"^([0-9A-F]{2,2}[:-]?){6,6}$";
                if(Regex.IsMatch(macString, pattern))
                {
                    return new MACAddress(macString);
                }
                throw new FormatException($"{macString} is not a valid MAC address.");
            }
            /// <summary>
            ///     Determines whether a string is a valid MAC address.
            /// </summary>
            /// <param name="macString">The string to validate.</param>
            /// <param name="address">The <see cref="WakeOnLANTool"/>.<see cref="Helpers"/>.<see cref="MACAddress"/> version of the string.</param>
            /// <returns>true if macString was able to be parsed as a MAC address; otherwise, false.</returns>
            public static bool TryParse(string macString, out MACAddress address)
            {
                try
                {
                    address = MACAddress.Parse(macString);
                    return true;
                } 
                catch
                {
                    address = null;
                    return false;
                }
                
            }
        }
    }
}
