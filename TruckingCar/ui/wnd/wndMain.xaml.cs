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
using TruckingCar.ui.classes;
using TruckingCar.ui.pg;

namespace TruckingCar.ui.wnd
{
    /// <summary>
    /// Логика взаимодействия для wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        public wndMain()
        {
            InitializeComponent();
            lbLoginText.Content = ManagerLogin.Login;

            frameMain.Navigate(new pgListCars());
            ManagerFrame.frameMain = frameMain;
        }

        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {
            if (frameMain.CanGoBack)
                btnGoBack.Visibility = Visibility.Visible;
            else
                btnGoBack.Visibility = Visibility.Hidden;
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.frameMain.GoBack();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            wndSingIn wndSingIn = new wndSingIn();
            wndSingIn.Show();
            this.Close();
        }
    }
}