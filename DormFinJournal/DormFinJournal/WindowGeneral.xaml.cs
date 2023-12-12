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
    public partial class WindowGeneral : Window
    {
        private int? role;
        private string fullNameUser;

        public WindowGeneral(string fullNameUser, int? role)
        {
            InitializeComponent();
            UserInfoLabel.Content = $"{fullNameUser} ({(role == 1 ? "Администратор" : "Комендант")})"; // Выводится на экран информация об пользователе
            this.fullNameUser = fullNameUser;
            this.role = role;
        }

        // Октрывает окно со списком жильцов
        private void btnTenant_Click(object sender, RoutedEventArgs e)
        {
            var residentsWindow = new WindowTenants(fullNameUser, role);
            residentsWindow.Show();
        }

        // Отерывает окно для создания квитанции
        private void btnReceipt_Click(object sender, RoutedEventArgs e)
        {
            WindowGenerReceipt residentsWindow = new WindowGenerReceipt(fullNameUser, role);
            residentsWindow.Show();
        }

        // Кнопка выхода из программы
        private void btnVCL_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
