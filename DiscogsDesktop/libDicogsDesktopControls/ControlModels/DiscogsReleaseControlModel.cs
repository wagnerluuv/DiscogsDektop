using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlModelBase;
using libDicogsDesktopControls.Controls;
using libDiscogsDesktop.Models;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.ControlModels
{
    public sealed class DiscogsReleaseControlModel : TitleAndImageControlModel
    {
        private readonly DiscogsRelease release;

        public readonly VideoModel[] Videos;

        public event Action<DiscogsLabel> LabelLoaded;

        public readonly string LabelName;

        public DiscogsReleaseControlModel(DiscogsRelease release)
        {
            this.release = release;
            this.Title = release.title;
            this.LabelName = release.labels[0].name;
            this.Videos = (release.videos ?? new DiscogsVideo[0]).Select(v => new VideoModel(v.uri, v.title)).ToArray();
        }

        public override void StartImageLoading()
        {
            Task.Run(() =>
            {
                if (this.release.images != null && this.release.images.Length > 0)
                {
                    this.Image = Image.FromFile(MediaService.GetImageFilePath(this.release.images[0]));
                }
            });
        }

        public void OpenInBrowser()
        {
            Process.Start(this.release.uri);
        }

        public void StartGetLabel()
        {
            Task.Run(() => { this.LabelLoaded?.Invoke(DiscogsService.GetLabel(this.release.labels[0].id)); });
        }
    }
}