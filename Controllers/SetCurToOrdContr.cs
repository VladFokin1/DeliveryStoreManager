using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    public class SetCurToOrdContr
    {
        private FoodStore _model;
        private int _index;
        public FoodStore Model { get { return _model; } set { _model = value; } }

        public SetCurToOrdContr(FoodStore model, int index)
        {
            _model = model;
            _index = index;
        }
        public void SetCur(Courier courier)
        {
            courier.Order = Model.Orders[_index];
            Model.Orders[_index].Courier = courier;
        }
    }
}
