using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace Ricardo15.iOS
{
    /// <summary>
    /// Shows list of deals based on search or chosen category
    /// </summary>
    [Register("VCDealList")]
    public class VCDealList : TransparentViewController
    {
        public VCDealList()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            nfloat w = View.Bounds.Width;
            nfloat h = View.Bounds.Height;
            int cellh = Convert.ToInt32((h - 182) / 6);

            View.BackgroundColor = UIColor.White;
            UIGraphics.BeginImageContext(this.View.Frame.Size);
            UIImage i = UIImage.FromBundle("Splash");
            i = i.Scale(this.View.Frame.Size);
            View.BackgroundColor = UIColor.FromPatternImage(i);

            for (int j = 0; j < Config.data._deals.Count; j++)
            {
                int y = 100 + j * cellh;

                DealObject d = Config.data._deals[j];

                UIButton btnDeal = UIButton.FromType(UIButtonType.Custom);
                btnDeal.Frame = new CoreGraphics.CGRect(20, y, 128, cellh);
                btnDeal.SetImage((UIImage)d.BMP, UIControlState.Normal);
                btnDeal.Tag = j;
                btnDeal.TouchUpInside += btnDeal_TouchUpInside;
                View.AddSubview(btnDeal);


                UILabel lblTitle = new UILabel(new CoreGraphics.CGRect(150, y, w - 170, cellh));
                lblTitle.Lines = 3;
                lblTitle.Text = d.Title;
                View.AddSubview(lblTitle);
            }
        }

        private void btnDeal_TouchUpInside(object sender, EventArgs e)
        {
            UIButton btnClicked = (UIButton)sender;
            nint k = btnClicked.Tag;
            Config.data.SelectedDeal = (int)k;

            var controller2 = new VCDeal();
            this.NavigationController.PushViewController(controller2, true);
        }
    }
}