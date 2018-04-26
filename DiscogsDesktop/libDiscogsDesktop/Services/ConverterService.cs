using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaToolkit;
using MediaToolkit.Model;

namespace libDiscogsDesktop.Services
{
    public static class ConverterService
    {
        public static void ConvertVideoToMp3(string videoFilePath, string mp3FilePath)
        {
            MediaFile inputFile = new MediaFile { Filename = videoFilePath };
            MediaFile outputFile = new MediaFile { Filename = mp3FilePath };

            using (Engine engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }
        }
    }
}
