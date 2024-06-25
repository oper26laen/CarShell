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
using System.Windows.Threading;
using TruckingCar.data.model;
using TruckingCar.ui.classes;

namespace TruckingCar.ui.pg
{
    /// <summary>
    /// Логика взаимодействия для pgRentTimer.xaml
    /// </summary>
    public partial class pgRentTimer : Page
    {
        private Rentals _currentRent = new Rentals();
        private decimal moneyOfDecimal;
        private double moneyofDouble;
        public pgRentTimer()
        {
            InitializeComponent();
            _currentRent.OrderID = ManagerID.OrderID;
        }

        DispatcherTimer dt = new DispatcherTimer();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTraker;
        }

        public int increment = 0;
        private int increment_1 = 0;
        private int increment_2 = 0;
        private int increment_3 = 0;

        private void dtTraker(object sender, EventArgs e)
        {
            increment++;

            if(increment_1 < 59)
            {
                increment_1++;
            }
            else if(increment_1 > 58)
            {
                increment_2++;
                increment_1 = 0;
            }
            else if(increment_2 > 58)
            {
                increment_3++;
                increment_2 = 0;
            }

            TimerLabel.Content = increment_3.ToString() + ":" +increment_2.ToString() + ":" + increment_1.ToString();
            moneyofDouble = 1 * increment;
        }

        private void BtnStartRent_Click(object sender, RoutedEventArgs e)
        {
            _currentRent.StartTime = DateTime.Now;
            dt.Start();
            btnStartRent.Visibility = Visibility.Hidden;
            btnEndRent.Visibility = Visibility.Visible;
        }

        private void BtnEndRent_Click(object sender, RoutedEventArgs e)
        {
            _currentRent.EndTime = DateTime.Now;
            moneyOfDecimal = Convert.ToDecimal(moneyofDouble);
            _currentRent.Price = moneyOfDecimal;

            dt.Stop();

            TruckingCarEntities1.GetContext().Rentals.Add(_currentRent);
            TruckingCarEntities1.GetContext().SaveChanges();

            btnEndRent.Visibility = Visibility.Hidden;
            MessageBox.Show("Арнде завершина");
            Money.Content = Convert.ToString(moneyOfDecimal) + "р";
            btnGoHome.Visibility = Visibility.Visible;
            Content.Visibility = Visibility.Visible;
            Money.Visibility = Visibility.Visible;
        }

        private void BtnGoHome_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.frameMain.Navigate(new pgListCars());
        }
    }
}