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
    /// Shows chosen deal
    /// </summary>
    [Activity(Label = "DealActivity", Theme = "@style/Theme.Deal", ScreenOrientation = ScreenOrientation.Portrait)]
    public class DealActivity : Activity
    {
        private TextView lblTitle, lblDescription;
        private ImageView imgView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Deal);
            lblTitle = FindViewById<TextView>(Resource.Id.titleDeal);
            lblDescription = FindViewById<TextView>(Resource.Id.descriptionDeal);
            imgView = FindViewById<ImageView>(Resource.Id.imageDeal);

            DealObject d = Config.data.GetSelectedDeal();
            lblTitle.Text = d.Title;
            lblDescription.Text = d.Description;
            imgView.SetImageBitmap((Android.Graphics.Bitmap)d.BMP);
        }
    }
}