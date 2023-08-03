using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Delivery
{
    public class Storage
    {

        private List<StorageItem> _items;
        public List<StorageItem> Items { get { return _items; } }

        public Storage()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../../XML/Storage.xml");
            _items = new List<StorageItem>();
            XmlElement? xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                StorageItem item = new StorageItem(xnode.ChildNodes[0].InnerText, Int32.Parse( xnode.ChildNodes[1].InnerText));
                _items.Add(item);
            }
        }
    }
}
