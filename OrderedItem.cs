using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    public class OrderedItem
    {
        private string _id;
        private string _name;
        private int _price;
        private string _per;
        private int _count;
        

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public string Per { get { return _per; } }
        public int Count { get { return _count; } }
        public int TotalPrice
        {
            get
            {
                return Count * Price;
            }
        }
        public OrderedItem(string id, string name, int price, string per, int count)
        {
            _id = id;
            _name = name;
            _price = price;
            _per = per;
            _count = count;
        }
    }
}
