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
    public class Order : INotifyPropertyChanged
    {
        private string _adress;
        private string _state;
        private Courier _courier;
        private string _courierName;
        private string _startTime;
        private string _endTime;
        private ObservableCollection<OrderedItem> _items;

        public string Adress { get { return _adress; } set { _adress = value; } }
        public string CourierName
        {
            get { return _courierName; }
            set { _courierName = value; NotifyPropertyChanged(); }
        }
        public Courier Courier
        {
            get { return _courier; }
            set
            {
                _courier = value;
                NotifyPropertyChanged();
                CourierName = _courier.Name;
                if (_courier == null)
                {
                    CourierName = "не назначен";
                }
                else
                {
                    CourierName = _courier.Name;
                    State = "доставляется";
                }

            }
        }

        public string StartTime { get { return _startTime; } set { _startTime = value; } }
        public string EndTime { get { return _endTime; } set { _endTime = value; } }

        public string State
        {
            get { return _state; }
            set
            {
                if (value == "доставлен")
                {
                    _endTime = DateTime.Now.ToShortTimeString();
                    _state = "доставлен в " + _endTime;
                }
                else
                {
                    _state = value;
                }
                NotifyPropertyChanged();
            }
        }
        public int TotalPrice
        {
            get
            {
                int total = 0;
                foreach(OrderedItem orderedItem in _items)
                {
                    total += orderedItem.TotalPrice;
                }
                return total;
            }
        }

        public ObservableCollection<OrderedItem> Items { get { return _items; } }

        public Order(string adress, ObservableCollection<OrderedItem> items)
        {
            _items = items;
            _adress = adress;
            _startTime = DateTime.Now.ToShortTimeString();
            CourierName = "не назначен";
            State = "ожидает доставки";
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
