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
using TruckingCar.data.model;
using TruckingCar.ui.classes;

namespace TruckingCar.ui.pg
{
    /// <summary>
    /// Логика взаимодействия для pgListCars.xaml
    /// </summary>
    public partial class pgListCars : Page
    {
        public pgListCars()
        {
            InitializeComponent();

            var Client = TruckingCarEntities1.GetContext().Clients;
            var ClientID = Client.FirstOrDefault(x => x.UserID == ManagerID.UserID);
            if (ClientID != null)
                ManagerID.ClientID = ClientID.ClientID;

            var allCities = TruckingCarEntities1.GetContext().Cities.ToList();
            allCities.Insert(0, new Cities { CityName = "Все города" });
            combCities.ItemsSource = allCities;
            combCities.SelectedIndex = 0;

            dgListCars.ItemsSource = TruckingCarEntities1.GetContext().Cars.ToList();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.frameMain.Navigate(new pgOrderCar((sender as Button).DataContext as Cars));
        }

        private void CombCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentCar = TruckingCarEntities1.GetContext().Cars.ToList();

            if (combCities.SelectedIndex > 0)
                currentCar = currentCar.Where(p => p.Cities.CityName.Contains(Convert.ToString(combCities.SelectedItem as Cities))).ToList();
        }
    }
}