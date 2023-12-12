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

namespace DormFinJournal
{
    public partial class TenantsComendant : Page
    {
        public TenantsComendant()
        {
            InitializeComponent();
            Loaded += TenantsComendant_Loaded;
        }

        // Выводит информацию об жильцах из базы данных
        private void TenantsComendant_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new DormitoryJournalsDBEntities())
            {
                var tenants = context.Tenants.ToList();

                TenantsList.ItemsSource = tenants;
            }
        }

        // Кнопка возврата в Главное меню пользователя
        private void btnBackMenu_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
