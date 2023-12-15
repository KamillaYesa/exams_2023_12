using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace DormFinsLogbook
{
    public partial class WindowGenerReceipt : Window
    {
        private int? role;
        private string fullNameUser;

        public WindowGenerReceipt(string fullNameUser, int? role)
        {
            InitializeComponent();

            // фильтр для выпадающего списка - не выводим ушедших жильцов
            using (var db = new DormitoryManagerBDEntities())
            {
                DateTime currentDate = DateTime.Now;
                TenantsComboBox.ItemsSource = db.Tenants
                    .Where(t => !string.IsNullOrEmpty(t.TenantFullName) && t.DateEviction == null)
                    .ToList();
                TenantsComboBox.DisplayMemberPath = "TenantFullName";
                TenantsComboBox.SelectedValuePath = "ID_Tenant";
                TenantsComboBox.SelectedItem = TenantsComboBox.Items[0];
            }
        }

        // Кнопка для генерации Word квитанций
        private void btnReceipt_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли элемент в раскрывающемся списке
            var selectedResident = TenantsComboBox.SelectedItem as Tenant;
            if (selectedResident != null)
            {
                // Получение ID выбранного жильца
                var selectedResidentId = (int)selectedResident.ID_tenant;

                // Создание объекта квитанции
                var receipt = new Receipt()
                {
                    ReceiptTenant = selectedResidentId, // выбранный жилец из выпадающего списка
                    PayLiving = new Random().Next(1000, 5000), // имитация необходимой оплаты за проживание
                    PayData = DateTime.Now // дата выплаты квитанции
                };

                // Создание документа Word
                var wordApp = new Word.Application();
                wordApp.Visible = false;
                var wordDoc = wordApp.Documents.Add();

                // Фиксируем выбранного жильца для дальнйшей работы
                using (var db = new DormitoryManagerBDEntities())
                {
                    var resident = db.Tenants.FirstOrDefault(r => r.ID_tenant == selectedResidentId);
                    if (resident == null)
                    {
                        throw new Exception("Такого жильца нету в базе данных.");
                    }

                    // счётчик даты для более точного определения дня выплаты квитанции
                    DateTime DataPay;
                    int year = DateTime.Now.Year;
                    int month = DateTime.Now.Month;
                    int day = resident.DateChecin.Value.Day;
                    if (day > DateTime.Now.Day)
                    {
                        DataPay = new DateTime(year, month, day);
                    }
                    else
                    {
                        if (month == 12)
                        {
                            year += 1;
                            month = 1;
                        }
                        else
                        {
                            month += 1;
                        }
                        DataPay = new DateTime(year, month, day);
                    }

                    // Добавление текста в документ Word
                    var paragraph = wordDoc.Paragraphs.Add();
                    paragraph.Range.Text = "ФИО жильца: " + resident.TenantFullName + "\n";
                    paragraph.Range.Text += "Номер комнаты: " + resident.Room + "\n";
                    paragraph.Range.Text += "Дата оплаты квитанции: " + receipt.PayData.Value.ToShortDateString() + "\n";
                    paragraph.Range.Text += "Сумма оплаты за проживание: " + receipt.PayLiving.ToString() + "\n";
                    paragraph.Range.Text += "Сумма оплаты доп. услуг: " + new Random().Next(1000, 3000).ToString() + "\n";
                    paragraph.Range.Text += "Итоговая сумма оплаты: " + (receipt.PayLiving + new Random().Next(1000, 3000)).ToString() + "\n";

                    // Установка имени файла
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Word documents|*.docx";
                    saveFileDialog.Title = "Введите имя файла";
                    saveFileDialog.FileName = receipt.PayData.Value.ToShortDateString() + "_" + resident.TenantFullName + ".docx";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        wordDoc.SaveAs2(saveFileDialog.FileName);
                    }
                }

                // Сохранение документа Word
                wordDoc.Close();
                wordApp.Quit();
            }
            else
            {
                // Вывод сообщения об ошибке, если элемент не выбран
                MessageBox.Show("Выберите жильца из выпадающего списка.");
            }
        }


        private void btnBackMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Выводит текст выбранного жильца из выпадающего списка
        private void TenantsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTenant = TenantsComboBox.SelectedItem as Tenant;
            if (selectedTenant != null)
            {
                TenantInfoTextBox.Text = $"Выбран жилец: {selectedTenant.TenantFullName}";
            }
        }
    }
}
