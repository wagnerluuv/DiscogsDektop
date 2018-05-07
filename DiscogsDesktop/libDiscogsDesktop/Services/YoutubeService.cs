using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using VideoLibrary;
using YoutubeExtractor;

namespace libDiscogsDesktop.Services
{
    public static class YoutubeService
    {
        public static bool DownloadVideoViaVideoLibrary(string url, string successPath, string failurePath)
        {
            try
            {
                File.WriteAllBytes(successPath, YouTube.Default.GetVideo(url).GetBytes());
                return true;
            }
            catch
            {
                File.Create(failurePath).Close();
                return false;
            }
        }

        public static bool DownloadVideoViaYoutubeExtractor(string url, string successPath, string failurePath)
        {
            try
            {
                VideoInfo[] videoInfos = DownloadUrlResolver.GetDownloadUrls(url)
                    .Where(info => info.VideoType == VideoType.Mp4 && info.Resolution != 0)
                    .ToArray();

                VideoInfo video = videoInfos
                    .First(info => info.Resolution == videoInfos.Min(vi => vi.Resolution));

                if (video.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(video);
                }

                VideoDownloader videoDownloader = new VideoDownloader(video, successPath);

                videoDownloader.Execute();
                return true;
            }
            catch
            {
                File.Create(failurePath).Close();
                return false;
            }
        }
    }
}