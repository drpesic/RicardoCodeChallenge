using Foundation;
using System;
using UIKit;

namespace Ricardo15.iOS
{
    /// <summary>
    /// inherits DealObject and handles image for iOS platform
    /// </summary>
    public class DealI : DealObject
    {
        protected override void SetImage()
        {
            byte[] imageBytes = Convert.FromBase64String(imgbase);
            NSData data = NSData.FromArray(imageBytes);
            img = UIImage.LoadFromData(data);
        }
    }
}
