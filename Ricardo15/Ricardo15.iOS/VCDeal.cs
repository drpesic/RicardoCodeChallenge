using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace Ricardo15.iOS
{
    /// <summary>
    /// Shows chosen deal
    /// </summary>
    [Register("VCDeal")]
    public class VCDeal : TransparentViewController
    {
        public VCDeal()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            nfloat w = View.Bounds.Width;
            nfloat h = View.Bounds.Height;

            View.BackgroundColor = UIColor.White;
            View.TintColor = UIColor.Black;
            DealObject d = Config.data.GetSelectedDeal();

            UILabel lblTitle = new UILabel(new CoreGraphics.CGRect(20, 65, w - 40, 60));
            lblTitle.Lines = 2;
            lblTitle.Text = d.Title;
            View.AddSubview(lblTitle);

            UIImageView imageView = new UIImageView();
            imageView.Image = (UIImage)d.BMP;
            imageView.Frame = new CoreGraphics.CGRect(40, 130, 128, 128);
            View.AddSubview(imageView);

            UILabel lblDescription = new UILabel(new CoreGraphics.CGRect(10, 270, w - 20, h - 270));
            lblDescription.Lines = 25;
            lblDescription.Text = d.Description;
            View.AddSubview(lblDescription);
        }
    }
}