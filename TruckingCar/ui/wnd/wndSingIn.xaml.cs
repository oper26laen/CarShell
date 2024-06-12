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
using TruckingCar.data.model;
using TruckingCar.ui.classes;

namespace TruckingCar.ui.wnd
{
    /// <summary>
    /// Логика взаимодействия для wndSingIn.xaml
    /// </summary>
    public partial class wndSingIn : Window
    {
        public wndSingIn()
        {
            InitializeComponent();
        }
        private void ChbPasswordChecked_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnSingIn_Click(object sender, RoutedEventArgs e)
        {
            var User = TruckingCarEntities.GetContext().Users;
            var CurrentUser = User.FirstOrDefault(x => x.Login == tbLogin.Text & x.Password == pbPassword.Password);
            if (CurrentUser != null)
            {
                ManagerLogin.Login = tbLogin.Text;
                wndMain wndMain = new wndMain();
                wndMain.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователя не существует!!!");
            }
        }
    }
}
