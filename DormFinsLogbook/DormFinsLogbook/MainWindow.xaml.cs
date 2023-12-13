using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace DormFinsLogbook
{
    public partial class MainWindow : Window
    {
        private DormitoryManagerBDEntities _db = new DormitoryManagerBDEntities();
        private int _accessCode;
        private bool _isCodeValid = true;

        public MainWindow()
        {
            InitializeComponent();
            // Блокируем доступ ко всем элемнтам окна, кроме строки Логина и кнопки "Сброс"
            txtPassword.IsEnabled = false;
            tbAccessCode.IsEnabled = false;
            btnSMSgen.IsEnabled = false;
            btnCheckPass.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Сбросавыем вводимые значения и возвращаем элементы окна в иначальное состояние
            txtLogin.Clear();
            txtPassword.Clear();
            tbAccessCode.Clear();
            txtPassword.IsEnabled = false;
            tbAccessCode.IsEnabled = false;
            btnSMSgen.IsEnabled = false;
            btnCheckPass.IsEnabled = false;
        }

        private void btnCheckLogin_Click(object sender, RoutedEventArgs e)
        {
            // При нажатии кнопки на окне возле строки ввода логина должна провестись проверка правильности вввода логина пользователя.
            CheckLogin();
        }

        private void btnCheckPass_Click(object sender, RoutedEventArgs e)
        {
            // При нажатии кнопки на окне возле строки ввода пароля должна провестись проверка правильности вввода пароля пользователя.
            CheckPassword();
        }

        private void btnSMScode_Click(object sender, RoutedEventArgs e)
        {
            // При нажатии кнопки "Снова СМС" получать через диалоговое окно код из 4 чисел на 10 секунд.
            GenerateAccessCode();
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            // После ввода данных в поле ввода логина при нажатии на Enter должна провестись правильности вввода логина пользователя.
            if (e.Key == Key.Enter)
            {
                CheckLogin();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // После ввода данных в поле ввода пароля при нажатии на Enter должна провестись правильность вввода пароля пользователя.
            if (e.Key == Key.Enter)
            {
                CheckPassword();
            }
        }

        private void CheckLogin()
        {
            // Проверка наличия логина в бд.
            var query = from login in _db.Logins
                        where login.LoginName == txtLogin.Text
                        select login;

            var userLogin = query.FirstOrDefault();

            if (userLogin != null)
            {
                txtPassword.IsEnabled = true;
                txtPassword.Focus();
            }
            else
            {
                MessageBox.Show("Логин не найден.");
            }
        }

        private void CheckPassword()
        {
            // Проверка верности ввода пароля пользователя.
            var query = from user in _db.Users
                        join login in _db.Logins on user.UserLogin equals login.ID_login
                        where login.LoginName == txtLogin.Text && login.Password == txtPassword.Password
                        select new { user.UserFullName, login.ID_login };

            var userInfo = query.FirstOrDefault();

            if (userInfo != null)
            {
                GenerateAccessCode();
                tbAccessCode.IsEnabled = true;
                tbAccessCode.Focus();
                btnSMSgen.IsEnabled = true;

                _isCodeValid = false;
            }
            else
            {
                MessageBox.Show("Неверный пароль.");
            }
        }


        private void AccessCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверка кода доступа и открытие доступа к функционалу системы
            if (e.Key == Key.Enter)
            {
                if (_isCodeValid && tbAccessCode.Text == _accessCode.ToString())
                {
                    var query = from user in _db.Users
                                join login in _db.Logins on user.UserLogin equals login.ID_login
                                where login.LoginName == txtLogin.Text && login.Password == txtPassword.Password
                                select new { user.UserFullName, login.ID_login };

                    var userInfo = query.FirstOrDefault();

                    string role = userInfo.ID_login == 1 ? "Администратор" : "Комендант";
                    MessageBox.Show($"Добро пожаловать, {userInfo.UserFullName}! Ваша роль: {role}.");
                    WindowTenants tenantsWindow = new WindowTenants(userInfo.UserFullName, userInfo.ID_login);
                    WindowGenerReceipt grWindow = new WindowGenerReceipt(userInfo.UserFullName, userInfo.ID_login);
                    WindowGeneral generalWindow = new WindowGeneral(userInfo.UserFullName, userInfo.ID_login);
                    generalWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный код доступа из СМС. Попробуйте ещё раз.");
                }
            }
        }

        private async void GenerateAccessCode()
        {
            // Генерация рандомного кода из 4 цифр
            _accessCode = new Random().Next(1000, 10000);
            MessageBox.Show($"Код доступа: {_accessCode}");
            _isCodeValid = true;

            await Task.Delay(10000);
            _isCodeValid = false;
        }
    }
}
