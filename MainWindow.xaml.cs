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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Delivery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FoodStore foodStore;
        MainController mainController;
        bool isOpened = false;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainController = new MainController();
            foodStore = mainController.OpenSystem(this);

            curierGrid.ItemsSource = foodStore.Couriers;

            orderGrid.ItemsSource = foodStore.Orders;

            storageGrid.ItemsSource = foodStore.Storage.Items;

            money_label.Text = foodStore.Money.ToString();

        }

        private void Button_AddCurier_Click(object sender, RoutedEventArgs e)
        {
            mainController.AddCurier(this);
        }


        private void Button_AddOrder_Click(object sender, RoutedEventArgs e)
        {
            mainController.AddOrder(this);
            setCour_btn.IsEnabled = true;
            ordered_btn.IsEnabled = false;
        }

        private void Button_GoWork_Click(object sender, RoutedEventArgs e)
        {
            mainController.GoWork((Courier)curierGrid.SelectedItem);
            GoWork_btn.IsEnabled = false;
        }

        private void Button_SetCourier_Click(object sender, RoutedEventArgs e)
        {
            mainController.SetCourierToOrder(this, orderGrid.SelectedIndex);
            setCour_btn.IsEnabled=false;
            ordered_btn.IsEnabled=true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainController.CloseSystem(this);
        }

        private void openShift_btn_Click(object sender, RoutedEventArgs e)
        {
            if ((string)openShift_btn.Content == "Открыть смену")
            {
                openShift_btn.Content = "Закрыть смену";
                moneyToday_label.Visibility = Visibility.Hidden;
                orders_tabItem.IsEnabled = true;
                GoWork_btn.IsEnabled = true;
                isOpened = true;

            } else
            {
                openShift_btn.Content = "Открыть смену";
                moneyToday_label.Content = "+ " + foodStore.MoneyToday + " за сегодня";
                moneyToday_label.Visibility = Visibility.Visible;
                mainController.EndDay();
                orders_tabItem.IsEnabled = false;
                GoWork_btn.IsEnabled = false;
                isOpened = false;
                money_label.Text = foodStore.Money.ToString();
            }
        }

        private void Button_Ordered_Click(object sender, RoutedEventArgs e)
        {
            mainController.OrderOver((Order)orderGrid.SelectedItem);
            money_label.Text = foodStore.Money.ToString();
        }

        private void orderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if  (orderGrid.SelectedItem != null)
            {
                if (((Order)orderGrid.SelectedItem).State == "ожидает доставки")
                {
                    setCour_btn.IsEnabled = true;
                    ordered_btn.IsEnabled = false;
                }
                else if (((Order)orderGrid.SelectedItem).State == "доставляется")
                {
                    setCour_btn.IsEnabled = false;
                    ordered_btn.IsEnabled = true;
                }
                else
                {
                    setCour_btn.IsEnabled = false;
                    ordered_btn.IsEnabled = false;
                }
            }
            
        }

        private void curierGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Courier)curierGrid.SelectedItem).State == "не работает")
            {
                back_btn.IsEnabled = false;
                if (isOpened)
                {
                    GoWork_btn.IsEnabled = true;
                } else
                {
                    GoWork_btn.IsEnabled = false;
                }

            } else if (((Courier)curierGrid.SelectedItem).State == "возвращается на склад")
            {
                back_btn.IsEnabled = true;

            } else
            {
                GoWork_btn.IsEnabled = false;
            }

        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            ((Courier)curierGrid.SelectedItem).State = "на складе";
        }
    }
}
