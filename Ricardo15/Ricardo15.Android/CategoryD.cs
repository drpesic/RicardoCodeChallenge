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
using Android.Graphics;

namespace Ricardo15.Droid
{
    /// <summary>
    /// inherits Category and handles image for Android platform
    /// </summary>
    public class CategoryD : Category
    {
        protected override void SetImage()
        {
            byte[] imageBytes = Convert.FromBase64String(imgbase);
            img = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
        }
    }
}