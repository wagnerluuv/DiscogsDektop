using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDiscogsDesktop.Models
{
    public sealed class DiscogsDesktopSettings
    {
        public string Folder { get; set; }

        public string Token { get; set; }

        public bool AutomaticVideoLoading { get; set; }
    }
}
