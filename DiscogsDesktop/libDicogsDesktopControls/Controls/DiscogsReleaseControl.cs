using System;
using System.Windows.Forms;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.Extensions;
using libDicogsDesktopControls.Viewmodels;
using libDiscogsDesktop.Models;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class DiscogsReleaseControl : UserControl
    {
        private readonly DiscogsReleaseControlViewmodel viewmodel;

        public DiscogsReleaseControl(DiscogsRelease release)
        {
            this.InitializeComponent();

            this.viewmodel = new DiscogsReleaseControlViewmodel(release);

            this.viewmodel.ImageLoaded += () => { this.pictureBox1.InvokeIfRequired(() => { this.pictureBox1.Image = this.viewmodel.Image; }); };

            this.loadVideos();
        }

        private void loadVideos()
        {
            foreach (VideoModel viewmodelVideo in this.viewmodel.Videos)
            {
                LinkLabel label = new LinkLabel
                    {
                        Tag = viewmodelVideo,
                        Text = viewmodelVideo.Title,
                        AutoSize = false,
                        Width = this.flowLayoutPanelVideos.Width - 10
                    };
                label.LinkClicked += (sender, args) => { this.viewmodel.Play((VideoModel)((LinkLabel)sender).Tag); };
                this.flowLayoutPanelVideos.Controls.Add(label);
            }
        }
    }
}