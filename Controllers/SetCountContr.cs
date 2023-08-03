using System;
using System.Collections.ObjectModel;

namespace Delivery
{
    public class SetCountContr
    {
        private ObservableCollection<OrderedItem> _items;
        private StorageItem _item;
        public SetCountContr(ObservableCollection<OrderedItem> items, StorageItem item)
        {
            _items = items;
            _item = item;
        }

        public void setCount (string countSTR)
        {
            string name = _item.Name;
            int price = _item.Price;
            string per = _item.Per;
            string id = _item.ID;
            int count  = Int32.Parse(countSTR);
            _items.Add(new OrderedItem(id, name, price, per, count));
            _item.Count -= count;
        }
    }
}
