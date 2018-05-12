using System;
using System.Collections.Generic;
using Channel9.Model;
using Channel9.Core.Services;
using UIKit;
using Channel9.Core.Model;
using System.Linq;

namespace Channel9
{
    public partial class SecondViewController : UIViewController
    {
        public SecondViewController(IntPtr handle) : base(handle)
        {
        }

        public Dictionary<String, List<IPlayableItem>> Data = new Dictionary<string, List<IPlayableItem>>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.collectionView.DataSource = new FeaturedDataSource(this);

			// Perform any additional setup after loading the view, typically from a nib.
		}
        public Boolean firsTime = true;
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (firsTime || FavoritesService.FavoritesDirty)
            {
				LoadData();
				firsTime = false;
                FavoritesService.FavoritesDirty = false;
            }
		}

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if(segue.Identifier == "ShowEntryDetail")
            {
                var fc = (sender as FeaturedCell);
                var indexPath = (this.collectionView.IndexPathForCell(fc));
                var key = Data.Keys.ElementAt(indexPath.Section);
                var data = Data[key];
				var featured = data[indexPath.Row];
				var edvc = (segue.DestinationViewController as EntryDetailViewController);
                edvc.Entry = featured;
            }
        }

        private async void LoadData()
        {
            var cs = new ContentService();
            this.Data = await cs.GetHomeScreenData();
            this.collectionView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }

    public class FeaturedDataSource : UICollectionViewSource
    {
        private SecondViewController secondViewController;
        private List<Area> Favorites;
        public FeaturedDataSource(SecondViewController vc)
        {
            secondViewController = vc;
            Favorites = new List<Area>();
            Favorites.AddRange(FavoritesService.Shows);
            Favorites.AddRange(FavoritesService.Series);
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return secondViewController.Data.Count;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            var key = secondViewController.Data.Keys.ElementAt((int)section);
            return secondViewController.Data[key].Count;
		}

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            FeaturedCell fc = collectionView.DequeueReusableCell("FeaturedCell", indexPath) as FeaturedCell;
			
            var key = secondViewController.Data.Keys.ElementAt(indexPath.Section);
			var data = secondViewController.Data[key];
            var entry = data[indexPath.Row];
            fc.Configure(entry);

            return fc;
        }

        public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, Foundation.NSString elementKind, Foundation.NSIndexPath indexPath)
        {
            if (elementKind == "UICollectionElementKindSectionHeader")
            {
                var sgh = collectionView.DequeueReusableSupplementaryView((Foundation.NSString)"UICollectionElementKindSectionHeader", "GroupHeader", indexPath) as SimpleGroupHeader;
                if (sgh != null)
                {
					var key = secondViewController.Data.Keys.ElementAt(indexPath.Section);
                    sgh.Configure(key);
                }
                return sgh;
            }
            return null;
        }
    }
}
