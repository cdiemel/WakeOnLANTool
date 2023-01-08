
namespace WakeOnLANTool
{
    partial class WOLToolForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HostnameInput = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.HostnameLabel = new System.Windows.Forms.Label();
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.IPAddressInput = new System.Windows.Forms.TextBox();
            this.MACInput = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HostnameInput
            // 
            this.HostnameInput.Location = new System.Drawing.Point(109, 43);
            this.HostnameInput.Name = "HostnameInput";
            this.HostnameInput.Size = new System.Drawing.Size(113, 20);
            this.HostnameInput.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(32, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(190, 24);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Wake On LAN Tool";
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // HostnameLabel
            // 
            this.HostnameLabel.AutoSize = true;
            this.HostnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostnameLabel.Location = new System.Drawing.Point(33, 47);
            this.HostnameLabel.Name = "HostnameLabel";
            this.HostnameLabel.Size = new System.Drawing.Size(70, 16);
            this.HostnameLabel.TabIndex = 2;
            this.HostnameLabel.Text = "Hostname";
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressLabel.Location = new System.Drawing.Point(29, 73);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(74, 16);
            this.IPAddressLabel.TabIndex = 4;
            this.IPAddressLabel.Text = "IP Address";
            // 
            // IPAddressInput
            // 
            this.IPAddressInput.Location = new System.Drawing.Point(109, 72);
            this.IPAddressInput.Name = "IPAddressInput";
            this.IPAddressInput.Size = new System.Drawing.Size(113, 20);
            this.IPAddressInput.TabIndex = 3;
            // 
            // MACInput
            // 
            this.MACInput.AutoSize = true;
            this.MACInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MACInput.Location = new System.Drawing.Point(12, 100);
            this.MACInput.Name = "MACInput";
            this.MACInput.Size = new System.Drawing.Size(91, 16);
            this.MACInput.TabIndex = 6;
            this.MACInput.Text = "MAC Address";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(113, 20);
            this.textBox2.TabIndex = 5;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(109, 125);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(113, 23);
            this.SendButton.TabIndex = 7;
            this.SendButton.Text = "SEND";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Location = new System.Drawing.Point(15, 154);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(207, 151);
            this.textBox1.TabIndex = 8;
            // 
            // WOLToolForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 317);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MACInput);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.IPAddressLabel);
            this.Controls.Add(this.IPAddressInput);
            this.Controls.Add(this.HostnameLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.HostnameInput);
            this.Name = "WOLToolForm1";
            this.Text = "WoL Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HostnameInput;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label HostnameLabel;
        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.TextBox IPAddressInput;
        private System.Windows.Forms.Label MACInput;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

