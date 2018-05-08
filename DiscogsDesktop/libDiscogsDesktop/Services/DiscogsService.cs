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

        public static int MaxItems { get; set; }

        public static event Action TokenChanged;

        public static void SetToken(string token)
        {
            client = new DisClient(new TokenAuthenticationInformation(token), "DiscogsDesktop", 10000);
            TokenChanged?.Invoke();
        }
        
        public static DiscogsIdentity GetUser()
        {
            return client.GetUserIdentityAsync().Result;
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

        public static void GetCollectionReleases(string username, ObservableCollection<DiscogsCollectionRelease> observable)
        {
            client.GetCollectionReleases(username, MaxItems).Subscribe(observable.Add);
        }

        public static void Search(string pattern, ObservableCollection<DiscogsSearchResult> observable)
        {
            client.Search(new DiscogsSearch { query = pattern }, MaxItems).Subscribe(observable.Add);
        }

        public static void GetLabelReleases(int id, ObservableCollection<DiscogsLabelRelease> observable)
        {
            client.GetAllLabelReleases(id, MaxItems).Subscribe(observable.Add);
        }

        public static void GetArtistReleases(int id, ObservableCollection<DiscogsArtistRelease> observable)
        {
            client.GetArtistRelease(id, new DiscogsSortInformation { sort = DiscogsArtistSortType.year, sort_order = DiscogsSortOrderType.desc }, MaxItems).Subscribe(observable.Add);
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