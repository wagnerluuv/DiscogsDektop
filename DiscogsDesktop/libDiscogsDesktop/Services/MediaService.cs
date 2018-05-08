using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using Microsoft.VisualBasic.FileIO;

namespace libDiscogsDesktop.Services
{
    public static class MediaService
    {
        public const string SuccessSuffix = "_success";

        public const string FailureSuffix = "_failure";

        public const string ImageExtension = ".bmp";

        public const string VideoExtension = ".mp4";

        public static string ApplicationFolder { get; private set; }

        public static string VideoFolder => Path.Combine(ApplicationFolder ?? "", "Videos");

        public static string ImageFolder => Path.Combine(ApplicationFolder ?? "", "Images");

        public static void DeleteFiles()
        {
            FileSystem.DeleteDirectory(VideoFolder, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
            FileSystem.DeleteDirectory(ImageFolder, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
            //try
            //{
            //    foreach (string videoFile in Directory.GetFiles(VideoFolder))
            //    {
            //        try
            //        {
            //            File.Delete(videoFile);
            //        }
            //        catch
            //        {
            //            //ignore
            //        }
            //    }
            //    foreach (string imageFile in Directory.GetFiles(ImageFolder))
            //    {
            //        try
            //        {
            //            File.Delete(imageFile);
            //        }
            //        catch
            //        {
            //            //ignore
            //        }
            //    }
            //}
            //catch 
            //{
            //    //ignore
            //}
        }

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

        public static bool GetVideoFilePath(string youtubeUrl, out string path)
        {
            ensureExistingDirectory(VideoFolder);

            path = downloadedVideoPath(youtubeUrl);

            if (inProgress.ContainsKey(youtubeUrl))
            {
                while (path == null)
                {
                    Thread.Sleep(200);
                    path = downloadedVideoPath(youtubeUrl);
                }

                while (inProgress.ContainsKey(youtubeUrl))
                {
                    inProgress.TryRemove(youtubeUrl, out _);
                }
            }

            if (path != null)
            {
                return path.Contains(SuccessSuffix);
            }

            getVideoFilePath(youtubeUrl, out path, out string failurePath);

            return YoutubeService.DownloadVideoViaVideoLibrary(youtubeUrl, path, failurePath);
        }

        public static string GetImageFilePath(DiscogsImage image)
        {
            ensureExistingDirectory(ImageFolder);

            string path = getImageFilePath(image.uri);

            if (!File.Exists(path))
            {
                DiscogsService.DownloadImage(image, path);
            }

            return path;
        }

        private static string downloadedVideoPath(string url)
        {
            getVideoFilePath(url, out string successPath, out string failurePath);

            if (File.Exists(successPath))
            {
                return successPath;
            }

            if (File.Exists(failurePath))
            {
                return failurePath;
            }

            return null;
        }

        private static void getVideoFilePath(string youtubeUrl, out string successPath, out string failurePath)
        {
            string fileKey = getEscaped(youtubeUrl);
            successPath = Path.Combine(VideoFolder, $"{fileKey}{SuccessSuffix}{VideoExtension}");
            failurePath = Path.Combine(VideoFolder, $"{fileKey}{FailureSuffix}{VideoExtension}");
        }

        private static string getImageFilePath(string imageUrl)
        {
            return Path.Combine(ImageFolder, getEscaped(imageUrl) + ImageExtension);
        }

        private static string getEscaped(string youtubeUrl)
        {
            return Path.GetInvalidFileNameChars().Aggregate(youtubeUrl, (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, '_'));
        }

        private static void ensureExistingDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static readonly ConcurrentDictionary<string, string> inProgress = new ConcurrentDictionary<string, string>();
    }
}