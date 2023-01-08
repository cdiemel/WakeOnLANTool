using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            string hostname = this.HostnameInput.Text;
            this.OutputBox.Text += $"Hostname: {hostname}" + Environment.NewLine;

        }
    }
}
