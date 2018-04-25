using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using VideoLibrary;
using YoutubeExtractor;

namespace libDiscogsDesktop.Services
{
    public static class YoutubeService
    {
        private const string Folder = "D:\\LIBRARY\\Downloads";

        public static void DownloadVideo(string url, out string filepath)
        {
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(url);

            VideoInfo video = videoInfos
                .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);
            
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            filepath = Path.Combine(Folder, "With Youtube Extractor" + video.VideoExtension);

            VideoDownloader videoDownloader = new VideoDownloader(video, filepath);
            
            videoDownloader.Execute();
        }
   
        public static void DownloadVideo2(string url, out string filepath)
        {
            YouTube youTube = YouTube.Default; // starting point for YouTube actions
            YouTubeVideo video = youTube.GetVideo(url); // gets a Video object with info about the video
            filepath = Path.Combine(Folder, "With Video Library" + video.FileExtension);
            File.WriteAllBytes(filepath, video.GetBytes());
        }
    }
}
