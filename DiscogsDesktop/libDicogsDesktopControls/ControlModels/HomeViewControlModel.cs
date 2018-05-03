    using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using DiscogsClient.Data.Query;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.ControlModels
{
    public sealed class HomeViewControlModel : DependencyObject
    {
        public string SearchPattern
        {
            get { return (string)this.GetValue(SearchPatternProperty); }
            set { this.SetValue(SearchPatternProperty, value); }
        }

        public static readonly DependencyProperty SearchPatternProperty = DependencyProperty.Register(
            nameof(SearchPattern), typeof(string), typeof(HomeViewControlModel), new PropertyMetadata());

        public readonly DataTable ResultsTable = new DataTable();

        public delegate void SelectedEntityChangedEventHandler();

        public event SelectedEntityChangedEventHandler SelectedEntityChanged;

        private DiscogsEntity selectedEntity;

        public DiscogsEntity SelectedEntity
        {
            get => this.selectedEntity;
            set
            {
                this.selectedEntity = value;
                this.SelectedEntityChanged?.Invoke();
            }
        }

        public HomeViewControlModel()
        {
            this.searchResults.CollectionChanged += this.searchResultsOnCollectionChanged;

            this.ResultsTable.Columns.AddRange(new[]
                {
                    new DataColumn("Type"),
                    new DataColumn("Title"),
                    new DataColumn("Id"),
                });
        }

        public void SelectSearchResult(DataRow row)
        {
            Task.Run(() =>
            {
                switch ((DiscogsEntityType)Enum.Parse(typeof(DiscogsEntityType), row["Type"].ToString()))
                {
                    case DiscogsEntityType.release:
                        this.SelectedEntity = DiscogsService.GetRelease(int.Parse(row["Id"].ToString()));
                        break;
                    case DiscogsEntityType.master:
                        this.SelectedEntity = DiscogsService.GetMasterRelease(int.Parse(row["Id"].ToString()));
                        break;
                    case DiscogsEntityType.artist:
                        this.SelectedEntity = DiscogsService.GetArtist(int.Parse(row["Id"].ToString()));
                        break;
                    case DiscogsEntityType.label:
                        this.SelectedEntity = DiscogsService.GetLabel(int.Parse(row["Id"].ToString()));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

        public void Search()
        {
            this.ResultsTable.Rows.Clear();
            this.searchResults.Clear();
            DiscogsService.Search(this.SearchPattern, this.searchResults);
        }

        private readonly ObservableCollection<DiscogsSearchResult> searchResults = new ObservableCollection<DiscogsSearchResult>();

        private void searchResultsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (DiscogsSearchResult searchResult in notifyCollectionChangedEventArgs.NewItems ?? new DiscogsSearchResult[0])
            {
                if (searchResult.type == DiscogsEntityType.master)
                {
                    return;
                }

                this.ResultsTable.Rows.Add(searchResult.type, searchResult.title, searchResult.id);
            }
        }
    }
}