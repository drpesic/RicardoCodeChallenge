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

namespace Ricardo15.Droid.Adapters
{
    class CategoriesAdapter : BaseAdapter
    {
        private Activity _activity;
        private Data _dat;

        public CategoriesAdapter(Activity activity, Data dat)
        {
            _activity = activity;
            _dat = dat;
        }


        public override int Count
        { get { return _dat._categories.Count; } }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            int n = position;
            var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.CategoryItem, parent, false);
            var item1 = view.FindViewById<ImageView>(Resource.Id.imageCategory);
            var item2 = view.FindViewById<TextView>(Resource.Id.titleCategory);
            var item3 = view.FindViewById<TextView>(Resource.Id.noteCategory);

            if (n > -1)
            {
                Category z = _dat._categories[n];
                item1.SetImageBitmap((Android.Graphics.Bitmap)z.BMP);
                item2.Text = z.Name;
                item3.Text = z.Count.ToString() + " deals";
            }

            return view;
        }

    }
}