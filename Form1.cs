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

        private void getIPFromHostname(object sender, EventArgs e)
        {
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
        }

        private bool ValidIPv4(string ipAddress)
        {
            string pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9]?[0-9])\.?){4,4}$";

            if (!Regex.IsMatch(ipAddress, pattern))
            {
                throw new FormatException($"{ipAddress} is not a valid IPv4 Address.");
            }
            
            return true;

        }

        private void IPAddressInput_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                this.IPAddressInput.ForeColor = Color.Red;
                this.ToolTip.Show("Invalid IP Address", IPAddressInput, 5000);
                e.Cancel = true;
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
}
