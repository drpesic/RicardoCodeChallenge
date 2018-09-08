using System;

namespace Ricardo15
{
    public class Category
    {
        protected string imgbase;
        protected object img;
        protected int numberofitems = 0;
        public string ID { get; set; }
        public string Name { get; set; }
        public int Count
        {
            get { return numberofitems; }
            set { numberofitems = value; }
        }
        public string ImageBase
        {
            get { return imgbase; }
            set { imgbase = value; SetImage(); }
        }
        public object BMP
        { get { return img; } }
        public override string ToString()
        {
            return (Name);
        }
        protected virtual void SetImage() { }
    }
}

