using System;
using System.IO;
using JetBrains.Annotations;
using VideoLibrary;

namespace libDiscogsDesktop.Services
{
    public static class YoutubeService
    {
        public static bool DownloadVideo(string url, string successPath, string failurePath)
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
    }
}