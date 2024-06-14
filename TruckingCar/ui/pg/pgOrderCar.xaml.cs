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
    /// Логика взаимодействия для pgOrderCar.xaml
    /// </summary>
    public partial class pgOrderCar : Page
    {
        private Cars _currentCar = new Cars();
        private Clients _currentClient = new Clients();
        private Orders _currentOrder = new Orders();
        private string ClientName;
        private string ClientSurname;
        public pgOrderCar(Cars cars)
        {
            InitializeComponent();

            if (cars != null)
                _currentCar = cars;

            DataContext = _currentCar;

            var Client = TruckingCarEntities1.GetContext().Clients;
            var ClientID = Client.FirstOrDefault(x => ManagerID.ClientID == x.ClientID);
            ClientName = ClientID.Name;
            ClientSurname = ClientID.Surname;
            lbName.Content = ClientName;
            lbSurname.Content = ClientSurname;
        }

        private void BtnOrding_Click(object sender, RoutedEventArgs e)
        {
            var Car = TruckingCarEntities1.GetContext().Cars;

            _currentOrder.ClientID = ManagerID.ClientID;
            _currentOrder.CarID = _currentCar.CarID;
            _currentOrder.DateAndTimeForOrder = DateTime.Now;
            _currentOrder.CityID = _currentCar.CityID;
            _currentOrder.StatusID = 2;

            TruckingCarEntities1.GetContext().Orders.Add(_currentOrder);
            TruckingCarEntities1.GetContext().SaveChanges();

            MessageBox.Show("Заказ одобрен");

            ManagerID.OrderID = _currentOrder.OrderID;

            ManagerFrame.frameMain.Navigate(new pgRentTimer());
        }
    }
}