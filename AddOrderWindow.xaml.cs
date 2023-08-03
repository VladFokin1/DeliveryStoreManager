using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


namespace Delivery
{
    /// <summary>
    /// Interaction logic for AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private AddOrderContr _contr;
        private ObservableCollection<OrderedItem> _orders;
        public AddOrderContr Controller { set { _contr = value; } }
        public AddOrderWindow(AddOrderContr contr)
        {
            InitializeComponent();
            _orders = new ObservableCollection<OrderedItem>();
            _contr = contr;
            itemsList.ItemsSource = _contr.Model.Storage.Items;
            orderList.ItemsSource = _orders;
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            _contr.AddOrder(orderName_textbox.Text, _orders);
            Close();
        }

        private void itemsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _contr.SetCount(this, _orders, (StorageItem)itemsList.SelectedItem);
        }
    }
}
