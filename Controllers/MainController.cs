using System;
using System.Windows;

namespace Delivery
{
    internal class MainController
    {
        FoodStore _model;
        private readonly string _path = $"{Environment.CurrentDirectory}\\foodStore.json";
        IOService _iOService;

        public MainController()
        {
            _iOService = new IOService(_path);
        }

        public void AddOrder(Window owner)
        {
            AddOrderContr addOrderContr = new AddOrderContr(_model);
            AddOrderWindow window = new AddOrderWindow(addOrderContr);
            window.Owner = owner;
            window.Show();
        }
        public void AddCurier(Window owner)
        {
            AddCourContr addCourContr = new AddCourContr(_model);
            AddCurierWindow window = new AddCurierWindow(addCourContr);
            window.Owner = owner;
            window.Show();
        }
        public void SetCourierToOrder(Window owner, int index)
        {
            SetCurToOrdContr setCurToOrdContr = new SetCurToOrdContr(_model, index);
            SetCurToOrderWindow window = new SetCurToOrderWindow(setCurToOrdContr);
            window.Owner = owner;
            window.Show();
        }
        public void GoWork(Courier courier)
        {
            courier.State = "на складе";
        }
        public void CloseSystem(Window window)
        {
            try
            {
                _model.EndDay();
                _iOService.SaveData(_model.Couriers, _model.Money);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                window.Close();
            }
        }

        public FoodStore OpenSystem(Window window)
        {
            try
            {
                _model = _iOService.LoadData();
                return _model;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                window.Close();
                return null;
            }
        }

        public void EndDay()
        {
            _model.EndDay();
        }
        
        public void OrderOver(Order order)
        {
            order.State = "доставлен";
            order.Courier.State = "возвращается на склад";
        }
    }
}
