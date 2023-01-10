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
        private Boolean bool_IPValid = false;
        private Boolean bool_MACValid = false;
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
            Helpers.IPv4Address ip = new Helpers.IPv4Address(this.IPAddressInput.Text);
            Helpers.MACAddress mac = new Helpers.MACAddress(this.MACInput.Text);
            WakeOnLANSession wols = new WakeOnLANSession(ip,mac);
            wols.Send();
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

        private void IPAddressInput_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            Console.WriteLine("IPAddressInput_TypeValidationCompleted");
            if (!e.IsValidInput)
            {
                this.IPAddressInput.ForeColor = Color.Red;
                this.ToolTip.Show("Invalid IP Address", IPAddressInput, 5000);
                //e.Cancel = true;
                this.bool_IPValid = false;
                this.SendButton.Enabled = false;
                return;
            }
            this.bool_IPValid = true;
            this.IPAddressInput.ForeColor = Color.Black;
            if(this.bool_IPValid & this.bool_MACValid)
            {
                this.SendButton.Enabled = true;
            }
        }

        private void MACInput_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            Console.WriteLine("MACInput_TypeValidationCompleted");
            if (!e.IsValidInput)
            {
                this.MACInput.ForeColor = Color.Red;
                this.ToolTip.Show("Invalid MAC Address", MACInput, 5000);
                //e.Cancel = true;
                this.bool_MACValid = false;
                this.SendButton.Enabled = false;
                return;
            }
            this.bool_MACValid = true;
            this.MACInput.ForeColor = Color.Black;
            if (this.bool_IPValid & this.bool_MACValid)
            {
                this.SendButton.Enabled = true;
            }
        }
    }
}
