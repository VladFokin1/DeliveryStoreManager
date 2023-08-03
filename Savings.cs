using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    public class Savings
    {
        public int Money { get; set; }
        public ObservableCollection<Courier> Couriers { get; set; }

        public Savings (int money, ObservableCollection<Courier> couriers)
        {
            Money = money;
            Couriers = couriers;
        }

    }
}
