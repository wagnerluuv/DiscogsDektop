using System;
using System.IO;
using System.Windows.Forms;
using DiscogsDesktop.Properties;
using JetBrains.Annotations;
using libDicogsDesktopControls.Controls;
using libDicogsDesktopControls.Dialogs;
using libDiscogsDesktop.Services;

namespace DiscogsDesktop
{
    public sealed partial class FormDiscogsDesktop : Form
    {
        public FormDiscogsDesktop()
        {
            this.InitializeComponent();

            Settings.Default.PropertyChanged += (sender, args) => this.checkSettings();

            this.toolStripTextBoxMaxItems.Text = Settings.Default.MaxItems.ToString();

            this.checkSettings();
        }

        private void checkSettings()
        {
            string hint = "";

            if (!Directory.Exists(Settings.Default.Folder))
            {
                hint += "please provide a folder to cache data\r\n\r\n";
            }

            if (string.IsNullOrWhiteSpace(Settings.Default.Token))
            {
                hint += "please provide a token to access discogs api";
            }

            if (!string.IsNullOrWhiteSpace(hint))
            {
                hint += "\r\n\r\n(can be done in settings)";
                this.panelView.Controls.Clear();
                this.panelView.Controls.Add(new Label { Text = hint, AutoSize = true });
                return;
            }

            MediaService.SetApplicationFolder(Settings.Default.Folder);

            DiscogsService.MaxItems = Settings.Default.MaxItems;

            DiscogsService.SetToken(Settings.Default.Token);

            this.panelView.Controls.Clear();
            HomeViewControl viewMain = new HomeViewControl();
            this.panelView.Controls.Add(viewMain);
            viewMain.Dock = DockStyle.Fill;
        }

        private void tokenToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (AuthenticationDialog dialog = new AuthenticationDialog { AuthenticationCode = Settings.Default.Token })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.Token = dialog.AuthenticationCode;
                }
            }

            Settings.Default.Save();
        }

        private void folderToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog
                {
                    SelectedPath = Settings.Default.Folder,
                    Description = @"Please select a folder where DiscogsDesktop can cache data",
                })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.Folder = dialog.SelectedPath;
                }
            }

            Settings.Default.Save();
        }

        private void deleteFilesToolStripMenuItemClick(object sender, EventArgs e)
        {
            MediaService.DeleteFiles();
        }

        private void toolStripTextBoxMaxItemsKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            e.Handled = true;

            if (!int.TryParse(this.toolStripTextBoxMaxItems.Text, out int maxitems))
            {
                MessageBox.Show("please provide a valid number", "invlid number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.toolStripTextBoxMaxItems.Text = Settings.Default.MaxItems.ToString();
                return;
            }

            Settings.Default.MaxItems = maxitems;
            Settings.Default.Save();
        }
    }
}