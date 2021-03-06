﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Content.Res;

namespace Ricardo15.Droid.Adapters
{
    class DealListAdapter : BaseAdapter
    {
        private Activity _activity;
        private Data _dat;

        public DealListAdapter(Activity activity, Data dat)
        {
            _activity = activity;
            _dat = dat;
        }

        public override int Count
        { get { return _dat._deals.Count; } }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            int n = position;
            var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.DealListItem, parent, false);
            var item1 = view.FindViewById<ImageView>(Resource.Id.imageDealList);
            var item2 = view.FindViewById<TextView>(Resource.Id.titleDealList);

            if (n > -1)
            {
                DealObject z = _dat._deals[n];
                item1.SetImageBitmap((Android.Graphics.Bitmap)z.BMP);
                item2.Text = z.Title;
            }

            return view;
        }
    }
}