using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Delivery
{
    public class Courier : INotifyPropertyChanged
    {
        private string _name;
        private string _state;
        private string _time;
        private string _adress;
        private Order _order;
        // создаем таймер
        private DispatcherTimer timer;
        DateTime _startTime;

        public string Name { get { return _name; } set { _name = value; } }
        public string State { 
            get { return _state; } 
            set 
            { 
                _state = value;
                NotifyPropertyChanged();

                if (_state == "не работает")
                {
                    Adress = "дома";
                    Order = null;
                    timer.Stop();
                    Time = "-";
                } else
                {
                    _startTime = DateTime.Now;
                    timer.Start();
                    if (_state == "доставляет заказ") Adress = _order.Adress;
                    else
                    {
                        Adress = "Минина 24";
                    }
                }

            } 
        }
        public string Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
                NotifyPropertyChanged();
            }
        }
        public string Time { get { return _time; } set { _time = value; NotifyPropertyChanged(); } }
        public Order Order {
            get { return _order; } 
            set { 
                _order = value; NotifyPropertyChanged();
                if (_order != null)
                {
                    State = "доставляет заказ";
                    //value.Courier = this;
                }
            } }

        public Courier(string name, string state,  string time)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);

            Name = name;
            State = state;
            Time = time;
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Time = (DateTime.Now - _startTime).ToString().Substring(3, 5);
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
