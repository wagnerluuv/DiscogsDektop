using System;
using JetBrains.Annotations;

namespace libDiscogsDesktop.Models
{
    public sealed class VideoModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}