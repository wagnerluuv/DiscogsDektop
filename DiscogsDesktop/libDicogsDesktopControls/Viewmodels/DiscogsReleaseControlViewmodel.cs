using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlSelector;
using libDiscogsDesktop.Models;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.Viewmodels
{
    public sealed class DiscogsReleaseControlViewmodel : DependencyObject
    {
        public VideoModel[] Videos { get; }

        public event Action ImageLoaded;

        private Image image;

        public Image Image
        {
            get => this.image;
            set
            {
                this.image = value;
                this.ImageLoaded?.Invoke();
            }
        }

        public DiscogsReleaseControlViewmodel(DiscogsRelease release)
        {
            this.Videos = (release.videos ?? new DiscogsVideo[0]).Select(v =>
            {
                Task.Run(() => { MediaService.GetVideoFilePath(v.uri); });
                return new VideoModel
                    {
                        Title = v.title,
                        Url = v.uri
                    };
            }).ToArray();

            Task.Run(() =>
            {
                if (release.images != null && release.images.Length > 0)
                {
                    this.Image = Image.FromFile(MediaService.GetReleaseImageFilePath(release.images[0]));
                }
            });
        }

        public void Play(VideoModel video)
        {
            SoundPlayerControlSelector.Player.Play(MediaService.GetVideoFilePath(video.Url), video.Title);
        }
    }
}