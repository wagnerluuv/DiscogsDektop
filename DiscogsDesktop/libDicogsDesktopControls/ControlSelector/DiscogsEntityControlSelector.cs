using System;
using System.Windows.Forms;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.Controls;

namespace libDicogsDesktopControls.ControlSelector
{
    public static class DiscogsEntityControlSelector
    {
        public static Control GetControl(DiscogsEntity entity)
        {
            switch (entity) {
                case DiscogsMaster _:
                    break;
                case DiscogsRelease _:
                    return new DiscogsReleaseControl((DiscogsRelease)entity);
                case DiscogsArtist _:
                    break;
                case DiscogsLabel _:
                    break;
            }

            return new Control();
        }
    }
}