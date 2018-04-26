using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;

namespace libDiscogsDesktop.Services
{
    public static class MediaService
    {
        public const string ImageExtension = ".bmp";

        public const string VideoExtension = ".mp4";

        public static string ApplicationFolder { get; private set; }

        public static string VideoFolder => Path.Combine(ApplicationFolder ?? "", "Videos");

        public static string ImageFolder => Path.Combine(ApplicationFolder ?? "", "Images");

        public static void SetApplicationFolder(string folder)
        {
            ApplicationFolder = folder;

            if (!Directory.Exists(VideoFolder))
            {
                Directory.CreateDirectory(VideoFolder);
            }

            if (!Directory.Exists(ImageFolder))
            {
                Directory.CreateDirectory(ImageFolder);
            }
        }

        public static string GetVideoFilePath(string youtubeUrl)
        {
            string path = getVideoFilePath(youtubeUrl);

            if (inProgress.ContainsKey(path))
            {
                while (!File.Exists(path))
                {
                    Thread.Sleep(50);
                }

                while (inProgress.ContainsKey(path))
                {
                    inProgress.TryRemove(path, out _);
                }

                return path;
            }

            if (File.Exists(path))
            {
                return path;
            }

            inProgress.TryAdd(path, "");

            if (!YoutubeService.DownloadVideo(youtubeUrl, path))
            {

            }

            return path;
        }

        public static string GetReleaseImageFilePath(DiscogsImage image)
        {
            string path = getImageFilePath(image.uri);

            if (!File.Exists(path))
            {
                DiscogsService.DownloadImage(image, path);
            }

            return path;
        }

        private static string getVideoFilePath(string youtubeUrl)
        {
            return Path.Combine(VideoFolder, getEscaped(youtubeUrl) + VideoExtension);
        }

        private static string getImageFilePath(string imageUrl)
        {
            return Path.Combine(ImageFolder, getEscaped(imageUrl) + ImageExtension);
        }

        private static string getEscaped(string youtubeUrl)
        {
            return Path.GetInvalidFileNameChars().Aggregate(youtubeUrl, (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, '_'));
        }

        private static readonly ConcurrentDictionary<string, string> inProgress = new ConcurrentDictionary<string, string>();
    }
}