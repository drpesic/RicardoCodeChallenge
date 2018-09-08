using Foundation;
using System;
using UIKit;

namespace Ricardo15.iOS
{
    /// <summary>
    /// inherits Category and handles image for iOS platform
    /// </summary>
    public class CategoryI : Category
    {
        protected override void SetImage()
        {
            byte[] imageBytes = Convert.FromBase64String(imgbase);
            NSData data = NSData.FromArray(imageBytes);
            img = UIImage.LoadFromData(data);
        }
    }
}
