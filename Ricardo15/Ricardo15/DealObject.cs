using System;
using System.Collections.Generic;
using System.Text;

namespace Ricardo15
{
    public class DealObject
    {
        protected string imgbase;
        protected object img;
        public string ID { get; set; }
        public string CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageBase
        {
            get { return imgbase; }
            set { imgbase = value; SetImage(); }
        }
        public object BMP
        { get { return img; } }
        protected virtual void SetImage() { }
    }
}
