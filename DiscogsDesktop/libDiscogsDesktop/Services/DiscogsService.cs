using System;
using System.Collections.ObjectModel;
using System.IO;
using DiscogsClient.Data.Query;
using DiscogsClient.Data.Result;
using DiscogsClient.Internal;
using JetBrains.Annotations;
using DisClient = DiscogsClient.DiscogsClient;

namespace libDiscogsDesktop.Services
{
    public static class DiscogsService
    {
        private static DisClient client;

        public static void SetToken(string token)
        {
            client = new DisClient(new TokenAuthenticationInformation(token), "DiscogsDesktop", 10000);
        }

        public static DiscogsMaster GetMasterRelease(int id)
        {
            return client.GetMasterAsync(id).Result;
        }

        public static DiscogsRelease GetRelease(int id)
        {
            return client.GetReleaseAsync(id).Result;
        }

        public static DiscogsArtist GetArtist(int id)
        {
            return client.GetArtistAsync(id).Result;
        }

        public static DiscogsLabel GetLabel(int id)
        {
            return client.GetLabelAsync(id).Result;
        }

        public static void Search(string pattern, ObservableCollection<DiscogsSearchResult> observable)
        {
            client.Search(new DiscogsSearch { query = pattern }).Subscribe(observable.Add);
        }

        public static void GetLabelReleases(int id, ObservableCollection<DiscogsLabelRelease> observable)
        {
            client.GetAllLabelReleases(id).Subscribe(observable.Add);
        }

        public static void DownloadImage(DiscogsImage image, string filepath)
        {
            using (Stream stream = File.Create(filepath))
            {
                client.DownloadImageAsync(image, stream).Wait();
            }
        }
    }
}