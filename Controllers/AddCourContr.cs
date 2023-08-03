using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    public class AddCourContr
    {
        private FoodStore _model;
        public FoodStore Model { get { return _model; } set { _model = value; } }

        public AddCourContr(FoodStore model)
        {
            _model = model;
        }
        public void AddCourier(string name)
        {
            Model.AddCourier(name);
        }
    }
}
