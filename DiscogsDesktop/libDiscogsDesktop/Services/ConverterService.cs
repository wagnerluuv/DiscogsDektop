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
        private const string Folder = "D:\\LIBRARY\\Downloads";

        public static void ConvertVideoToMp3(string filepath)
        {
            MediaFile inputFile = new MediaFile { Filename = filepath };
            MediaFile outputFile = new MediaFile { Filename = $"{filepath}.mp3" };

            using (Engine engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }
        }
    }
}
