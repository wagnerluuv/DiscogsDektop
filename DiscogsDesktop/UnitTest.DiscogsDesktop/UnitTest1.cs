using System;
using System.Diagnostics;
using libDiscogsDesktop.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.DiscogsDesktop
{
    [TestClass]
    public sealed class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            YoutubeService.DownloadVideo2("https://www.youtube.com/watch?v=hzcwBVixIw4&index=5&list=RDSaTIxquLX5c", out string filepath2);
            ConverterService.ConvertVideoToMp3(filepath2);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch = new Stopwatch();

            stopwatch.Start();
            YoutubeService.DownloadVideo("https://www.youtube.com/watch?v=hzcwBVixIw4&index=5&list=RDSaTIxquLX5c", out string filepath1);
            ConverterService.ConvertVideoToMp3(filepath1);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            

        }
    }
}
