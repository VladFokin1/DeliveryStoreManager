using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Delivery
{
    public class StorageItem
    {
        private string _id;
        private string _name;
        private int _price;
        private string _per;
        private int _count;

        public string ID { get { return _id; } private set { _id = value; } }
        public string Name { get { return _name; } private set { _name = value; } }
        public int Price { get { return _price; } private set { _price = value; } }
        public string Per { get { return _per; } private set { _per = value; } }
        public int Count { 
            get { return _count; } 
            set 
            { 
                _count = value;
                NotifyPropertyChanged();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("../../../XML/Storage.xml");
                XmlElement? xRoot = xDoc.DocumentElement;
                foreach (XmlElement xnode in xRoot)
                {
                    if (xnode.ChildNodes[0].InnerText == _id)
                    {
                        xnode.ChildNodes[1].InnerText = value.ToString();
                    }
                }
                xDoc.Save("../../../XML/Storage.xml");
            } 
        }

        public StorageItem(string id, int count)
        {
            _id = id;
            _count = count;
            XmlDocument _xDoc = new XmlDocument();
            _xDoc.Load("../../../XML/Goods.xml");
            XmlElement? xRoot = _xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                if (xnode.GetAttribute("id") == id)
                {

                    foreach (XmlElement childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name") Name = childnode.InnerText;
                        if (childnode.Name == "price")
                        {
                            Price = Int32.Parse(childnode.InnerText);
                            Per = childnode.GetAttribute("per");
                        }
                    }
                } 
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
