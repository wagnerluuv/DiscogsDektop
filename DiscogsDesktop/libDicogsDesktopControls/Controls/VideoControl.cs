using System;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlBase;
using libDicogsDesktopControls.ControlModels;
using libDicogsDesktopControls.Extensions;
using libDiscogsDesktop.Models;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class VideoControl : LeftToRightDockingControl
    {
        private readonly VideoControlModel controlModel;

        public VideoControl(VideoModel videoModel)
        {
            this.InitializeComponent();
            this.labelTitle.Text = videoModel.Title;
            this.controlModel = new VideoControlModel(videoModel);
            this.controlModel.LoadingFinished += this.controlModelOnLoadingFinished;
            this.controlModel.StartLoading();
        }

        private void controlModelOnLoadingFinished()
        {
            this.InvokeIfRequired(() =>
            {
                this.buttonPlayAudio.Enabled = this.buttonPlayVideo.Enabled = this.controlModel.DownloadSuccessfull;
                this.progressBarLoading.Visible = false;
            });
        }

        private void buttonPlayAudioClick(object sender, EventArgs e)
        {
            this.controlModel.PlayAudio();
        }

        private void buttonPlayVideoClick(object sender, EventArgs e)
        {
            this.controlModel.PlayVideo();
        }

        private void buttonOpenUrlClick(object sender, EventArgs e)
        {
            this.controlModel.OpenVideoUrl();
        }
    }
}