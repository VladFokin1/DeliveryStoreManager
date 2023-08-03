using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Delivery
{
    /// <summary>
    /// Interaction logic for SetCurToOrderWindow.xaml
    /// </summary>
    public partial class SetCurToOrderWindow : Window
    {
        private SetCurToOrdContr _contr;

        public SetCurToOrderWindow(SetCurToOrdContr contr)
        {
            InitializeComponent();
            _contr = contr;
            curierLW.ItemsSource = _contr.Model.Couriers.Where(cour => cour.State == "на складе");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _contr.SetCur((Courier)curierLW.SelectedItem);
            Close();
        }
    }
}
