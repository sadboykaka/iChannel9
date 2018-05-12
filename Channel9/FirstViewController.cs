using System;
using System.Collections.Generic;
using Channel9.Core.Model;
using Channel9.Core.Services;
using Foundation;
using UIKit;
using System.Linq;

namespace Channel9
{
    public partial class FirstViewController : UIViewController, IUICollectionViewSource
    {
        public FirstViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            this.collectionView.DataSource = this; // new ShowsDataSource(this);
            LoadData();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (segue.Identifier == "ShowShowEntries")
            {
                var sc = (sender as ShowCell);
                var indexPath = this.collectionView.IndexPathForCell(sc);
                var show = Shows[indexPath.Row];
                var sevc = (segue.DestinationViewController as ShowEntriesViewController);
                sevc.Show = show;
            }
        }

        private Boolean hasMoreData = false;
		private Boolean isLoading = false;

		private async void LoadData()
		{
            try
            {
                isLoading = true;
				var cs = new ContentService();
                var newShows = await cs.GetShows(Shows.Count);
                this.Shows.AddRange(newShows);
				hasMoreData = newShows.Count == ContentService.PageSize;
                var indexPaths = newShows.Select(s => NSIndexPath.FromRowSection( Shows.IndexOf(s),0));
                //this.collectionView.ReloadData();
                this.collectionView.InsertItems(indexPaths.ToArray());
			}
            finally
            {
                isLoading = false;
            }
		}


        public List<Area> Shows { get; private set; } = new List<Area>();

		public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

         // UICollectionViewSource

        [Export("numberOfSectionsInCollectionView:")]
        public nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }
        [Export("collectionView:numberOfItemsInSection:")]
        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Shows.Count;
        }
        [Export("collectionView:cellForItemAtIndexPath:")]
        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
			ShowCell sc = collectionView.DequeueReusableCell("ShowCell", indexPath) as ShowCell;

			var show = Shows[indexPath.Row];

			sc.Configure(show);

            if (!isLoading && hasMoreData && indexPath.Row == Shows.Count - 1)
            {
                LoadData();
            }

            return sc;
        }
    }
	
}
