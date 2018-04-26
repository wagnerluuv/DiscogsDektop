using System;
using System.Diagnostics;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.Dialogs
{
    public sealed partial class AuthenticationDialog : Form
    {
        public string AuthenticationCode { get; private set; }

        public AuthenticationDialog()
        {
            this.InitializeComponent();
            
        }
        
        private void buttonAuthorizeClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxCode.Text))
            {
                return;
            }

            this.AuthenticationCode = this.textBoxCode.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.discogs.com/settings/developers");
        }
    }
}