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
    /// Interaction logic for SetCountWindow.xaml
    /// </summary>
    public partial class SetCountWindow : Window
    {
        private SetCountContr _contr;
        public SetCountWindow(SetCountContr contr)
        {
            _contr = contr;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _contr.setCount(count_textbox.Text);
            this.Close();
        }
    }
}
