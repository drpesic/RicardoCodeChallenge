using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace Ricardo15.iOS
{
    [Register("TransparentViewController")]
    public class TransparentViewController : UIViewController
    {
        public TransparentViewController()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (NavigationController != null)
            {
                NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
                NavigationController.NavigationBar.ShadowImage = new UIImage();
                NavigationController.NavigationBar.Translucent = true;
                NavigationController.View.BackgroundColor = UIColor.Clear;
                NavigationController.NavigationBar.BackgroundColor = UIColor.Clear;
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            if (NavigationController != null)
            {
                NavigationController.NavigationBar.SetBackgroundImage(null, UIBarMetrics.Default);
                NavigationController.NavigationBar.ShadowImage = null;
                NavigationController.NavigationBar.BarTintColor = UIColor.White;
            }
        }
    }
}