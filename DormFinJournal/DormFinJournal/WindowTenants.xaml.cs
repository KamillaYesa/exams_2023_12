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

namespace DormFinJournal
{
    public partial class WindowTenants : Window
    {
        private int? role;

        //в зависимоти от роли октрываем соответсвующий фрейм
        public WindowTenants(string fullNameUser, int? role)
        {
            this.role = role;

            InitializeComponent();
            if (role == 1)
            {
                MainFrame.Navigate(new TenantsAdmin());
            }
            else if (role == 2)
            {
                MainFrame.Navigate(new TenantsComendant());
            }
        }
    }
}
