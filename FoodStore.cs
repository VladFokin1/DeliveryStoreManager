using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{

    public class FoodStore
    {
        private ObservableCollection<Courier> _couriers;
        private ObservableCollection<Order> _orders;

        private Storage _storage;
        private int _money;
        private int _moneyToday;

        public ObservableCollection<Courier> Couriers { get { return _couriers; } set { _couriers = value; } }
        public ObservableCollection<Order> Orders { get { return _orders; } }
        public Storage Storage { get { return _storage; } }
        public int Money { 
            get { return _money; } 
            set 
            {
                _money = value;
                NotifyPropertyChanged();
            } 
        }
        public int MoneyToday { get { return _moneyToday; } }

        public FoodStore()
        {
            _storage = new Storage();
            _couriers = new ObservableCollection<Courier>();
            _orders = new ObservableCollection<Order>();
            _money = 0;
            _moneyToday = 0;
        }
        public void AddCourier(string name)
        {
            Courier courier = new Courier(name, "не работает", "-");
            _couriers.Add(courier);
        }
        
        public void AddOrder(string adress, ObservableCollection<OrderedItem> _items)
        {
            Order order  = new Order(adress, _items);
            _orders.Add(order);
            foreach (OrderedItem item in _items)
            {
                _moneyToday += item.TotalPrice;
                Money += item.TotalPrice;
            }
        }

        public void EndDay()
        {
            _moneyToday = 0;
            Orders.Clear();
            foreach (Courier courier in Couriers)
            {
                courier.State = "не работает";
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
