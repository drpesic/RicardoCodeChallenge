using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace Ricardo15.Droid
{
    /// <summary>
    /// Main activity - shows categories and search textbox
    /// </summary>
	[Activity (Label = "Ricardo15.Android", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
        private ListView lstCategories;
        private EditText txtSearch;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            Config.data = new Data();
            SetContentView(Resource.Layout.Base);

            lstCategories = FindViewById<ListView>(Resource.Id.listviewCategories);
            txtSearch = FindViewById<EditText>(Resource.Id.editextSearch);
            var categoriesAdapter = new Adapters.CategoriesAdapter(this, Config.data);
            lstCategories.Adapter = categoriesAdapter;

            txtSearch.KeyPress += TxtSearch_KeyPress;
            lstCategories.ItemClick += LstCategories_ItemClick;
            Window.SetSoftInputMode(SoftInput.StateHidden);
        }

        private void TxtSearch_KeyPress(object sender, View.KeyEventArgs e)
        {
            string s = txtSearch.Text.Trim();
            if(e.KeyCode == Keycode.Enter && s != "")
                ShowDeals("", s);
        }

        private void LstCategories_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Category c = Config.data._categories[e.Position];
            ShowDeals(c.ID, "");
        }

        private async void ShowDeals(string categoryID, string searchCriteria)
        {
            Config.data.FillDeals(categoryID, searchCriteria);

            var activityDL = new Intent(this, typeof(DealListActivity));
            StartActivity(activityDL);
        }
	}
}


