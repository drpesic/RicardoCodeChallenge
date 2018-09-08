using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace Ricardo15.Droid
{
    /// <summary>
    /// Shows list of deals based on search or chosen category
    /// </summary>
	[Activity(Label = "DealList", Theme = "@style/Theme.Splash", ScreenOrientation = ScreenOrientation.Portrait)]
	public class DealListActivity : Activity
	{
        private ListView lstDeals;
        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DealList);
            lstDeals = FindViewById<ListView>(Resource.Id.listviewDealList);

            var deallistAdapter = new Adapters.DealListAdapter(this, Config.data);
            lstDeals.Adapter = deallistAdapter;

            lstDeals.ItemClick += LstDeals_ItemClick;
        }

        private void LstDeals_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Config.data.SelectedDeal = e.Position;

            var activityDL = new Intent(this, typeof(DealActivity));
            StartActivity(activityDL);
        }
    }
}