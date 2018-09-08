using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using CoreGraphics;

namespace Ricardo15.iOS
{
    /// <summary>
    /// Main controller - shows categories and search textbox
    /// </summary>
    [Register("VCCategoryList")]
    public class VCCategoryList : TransparentViewController
    {
        public VCCategoryList()
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
            int cellh = Convert.ToInt32((h - 182) / 6);   //105;

            View.BackgroundColor = UIColor.White;
            UIGraphics.BeginImageContext(this.View.Frame.Size);
            UIImage i = UIImage.FromBundle("Splash");
            i = i.Scale(this.View.Frame.Size);
            View.BackgroundColor = UIColor.FromPatternImage(i);

            UITextField searchField = new UITextField
            {
                Placeholder = "Search",
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(20, 90, w - 40, 31.0f)
            };
            searchField.ShouldReturn += SearchDeals;
            View.AddSubview(searchField);

            for (int j = 0; j < Config.data._categories.Count; j++)
            {
                int y = 125 + j * cellh;

                Category c = Config.data._categories[j];

                UIButton btnCategory = UIButton.FromType(UIButtonType.Custom);
                btnCategory.Frame = new CoreGraphics.CGRect(20, y, 128, cellh);
                btnCategory.SetImage((UIImage)c.BMP, UIControlState.Normal);
                btnCategory.Tag = Convert.ToInt32(c.ID);
                btnCategory.TouchUpInside += BtnCategory_TouchUpInside;
                View.AddSubview(btnCategory);


                UILabel lblTitle = new UILabel(new CoreGraphics.CGRect(150, y, w - 170, 34));
                lblTitle.Text = c.Name;
                View.AddSubview(lblTitle);

                if (cellh > 79)
                {
                    UILabel lblCount = new UILabel(new CoreGraphics.CGRect(150, y + 45, w - 170, 34));
                    lblCount.Text = c.Count.ToString() + " deals";
                    View.AddSubview(lblCount);
                }
            }
        }

        private void BtnCategory_TouchUpInside(object sender, EventArgs e)
        {
            UIButton btnClicked = (UIButton)sender;
            nint k = btnClicked.Tag;
            ShowDeals(k.ToString(), "");
        }
        private bool SearchDeals(UITextField textField)
        {
            string srch = textField.Text.Trim();
            ShowDeals("", srch);
            return false;
        }

        private async void ShowDeals(string categoryID, string searchCriteria)
        {
            Config.data.FillDeals(categoryID, searchCriteria);

            var controller2 = new VCDealList();
            this.NavigationController.PushViewController(controller2, true);
        }
    }
}