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
    /// Interaction logic for AddCurierWindow.xaml
    /// </summary>
    public partial class AddCurierWindow : Window
    {

        AddCourContr _contr;
        public AddCurierWindow(AddCourContr contr)
        {
            _contr = contr;
            InitializeComponent();
        }

        private void AddCurier_click(object sender, RoutedEventArgs e)
        {
            _contr.Model.AddCourier(courierName_textbox.Text);
            this.Close();
        }

    }
}
