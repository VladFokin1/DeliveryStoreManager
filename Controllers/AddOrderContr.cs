using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Delivery
{
    public class AddOrderContr
    {
        private FoodStore _model;
        public FoodStore Model { get { return _model; } set { _model = value; } }

        public AddOrderContr(FoodStore model)
        {
            _model = model;
        }
        public void AddOrder(string adress, ObservableCollection<OrderedItem> items)
        {
            Model.AddOrder(adress, items);
        }
        public void SetCount(Window owner, ObservableCollection<OrderedItem> items, StorageItem item)
        {
            SetCountContr contr = new SetCountContr(items, item);
            SetCountWindow window = new SetCountWindow(contr);
            window.Owner = owner;
            window.Show();
        }
    }
}
