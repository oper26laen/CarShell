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

            pbPassword.IsEnabled = false;
            tbPassword.IsEnabled = false;
            chbPasswordChecked.IsEnabled = false;
            btnSingIn.IsEnabled = false;
        }
        private void ChbPasswordChecked_Click(object sender, RoutedEventArgs e)
        {
            var chbPassword = sender as CheckBox;
            if (chbPassword.IsChecked.Value)
            {
                tbPassword.Text = pbPassword.Password;
                pbPassword.Visibility = Visibility.Hidden;
                tbPassword.Visibility = Visibility.Visible;
            }
            else
            {
                pbPassword.Password = tbPassword.Text;
                tbPassword.Visibility = Visibility.Hidden;
                pbPassword.Visibility = Visibility.Visible;
            }
        }

        private void TbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbLogin.Text.Length > 0)
            {
                pbPassword.IsEnabled = true;
                tbPassword.IsEnabled = true;
            }
            else
            {
                pbPassword.IsEnabled = false;
                tbPassword.IsEnabled = false;
            }
        }

        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(tbLogin.Text.Length != 0 && pbPassword.Password.Length != 0)
            {
                chbPasswordChecked.IsEnabled = true;
                btnSingIn.IsEnabled = true;
            }
            else
            {
                chbPasswordChecked.IsEnabled = false;
                btnSingIn.IsEnabled = false;
            }
        }

        private void TbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(pbPassword.Password.Length == 0)
            {
                pbPassword.Password = tbPassword.Text;
            }
        }

        private void BtnSingIn_Click(object sender, RoutedEventArgs e)
        {
            var User = TruckingCarEntities1.GetContext().Users;
            var CurrentUser = User.FirstOrDefault(x => x.Login == tbLogin.Text & x.Password == pbPassword.Password);
            if (CurrentUser != null)
            {
                ManagerLogin.Login = tbLogin.Text;
                ManagerID.UserID = CurrentUser.UserID;
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
