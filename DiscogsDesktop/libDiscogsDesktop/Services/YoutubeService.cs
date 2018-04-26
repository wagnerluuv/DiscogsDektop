using System;
using System.IO;
using JetBrains.Annotations;
using VideoLibrary;

namespace libDiscogsDesktop.Services
{
    public static class YoutubeService
    {
        public static bool DownloadVideo(string url, string filepath)
        {
            try
            {
                File.WriteAllBytes(filepath, YouTube.Default.GetVideo(url).GetBytes());
                return true;
            }
            catch
            {
                File.Create(filepath).Close();
                return false;
            }
        }
    }
}