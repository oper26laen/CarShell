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

namespace TruckingCar.ui.uc
{
    /// <summary>
    /// Логика взаимодействия для ClientProfilButton.xaml
    /// </summary>
    public partial class ClientProfilButton : UserControl
    {
        public ClientProfilButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string url { get; set; }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
