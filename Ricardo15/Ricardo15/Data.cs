using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;

namespace Ricardo15
{
    /// <summary>
    /// Class that handles data for both platforms
    /// </summary>
    public class Data
    {
        public List<Category> _categories = new List<Category>();
        public List<DealObject> _alldeals = new List<DealObject>();
        public List<DealObject> _deals = new List<DealObject>();
        public int SelectedDeal = -1;
        private string errmess = "";
        public Data()
        {
            LoadXMLData();
        }

        public string LastErrorMessage
        { get { return errmess; } }

        /// <summary>
        /// Loads data from xml files
        /// </summary>
        private async void LoadXMLData()
        {
#if __ANDROID__
            string resPrefix = "Ricardo15.Droid.";
#endif
#if __IOS__
			string resPrefix = "Ricardo15.iOS.";
#endif
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                Stream stream = assembly.GetManifestResourceStream(resPrefix + "CATEGORIES.xml");

                //await Task.Factory.StartNew(delegate          //for some reason does not work in iOS, hence omitted
                //{
                    XmlDocument doc = new XmlDocument();
                    doc.Load(stream);
                    foreach (XmlNode s in doc.SelectSingleNode("DEALS").ChildNodes)
                    {
#if __ANDROID__
                        Category cat = new Ricardo15.Droid.CategoryD();
#endif
#if __IOS__
			            Category cat = new Ricardo15.iOS.CategoryI();
#endif

                        cat.ID = s.SelectSingleNode("ID").InnerText;
                        cat.Name = s.SelectSingleNode("NAME").InnerText;
                        cat.ImageBase = s.SelectSingleNode("IMAGE").InnerText;
                        _categories.Add(cat);
                    }
                //});

                stream = assembly.GetManifestResourceStream(resPrefix + "DEALS.xml");

                //await Task.Factory.StartNew(delegate          
                //{
                XmlDocument docD = new XmlDocument();
                    docD.Load(stream);
                    foreach (XmlNode s in docD.SelectSingleNode("DEALS").ChildNodes)
                    {
#if __ANDROID__
                        DealObject d = new Ricardo15.Droid.DealD();
#endif
#if __IOS__
			            DealObject d = new Ricardo15.iOS.DealI();
#endif

                        d.ID = s.SelectSingleNode("ID").InnerText;
                        d.CategoryID = s.SelectSingleNode("CATEGORYID").InnerText;
                        int k = Convert.ToInt32(d.CategoryID);
                        _categories[k - 1].Count++;
                        d.Title = s.SelectSingleNode("TITLE").InnerText;
                        d.Description = s.SelectSingleNode("DESCRIPTION").InnerText;
                        d.ImageBase = s.SelectSingleNode("IMAGE").InnerText;
                        _alldeals.Add(d);
                    }
                //});
            }
            catch (Exception exc)
            {
                errmess = exc.Message;
            }
        }

        /// <summary>
        /// Based on search word or chosen category, fills list _deals with appropriate ones
        /// </summary>
        public void FillDeals(string catID, string searchCriteria)
        {
            searchCriteria = searchCriteria.ToLower();
            _deals = new List<DealObject>();

            foreach (DealObject d in _alldeals)
            {
                if ((catID != "" && catID == d.CategoryID) || (searchCriteria != "" && (d.Title.ToLower().Contains(searchCriteria) || d.Description.ToLower().Contains(searchCriteria))))
                    _deals.Add(d);
            }
        }

        /// <summary>
        /// Returns selected deal
        /// </summary>
        public DealObject GetSelectedDeal()
        {
            if (SelectedDeal > -1 && SelectedDeal < _deals.Count) return _deals[SelectedDeal];
            return new DealObject();
        }
    }
}
