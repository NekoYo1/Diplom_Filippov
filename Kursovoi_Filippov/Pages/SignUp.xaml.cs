using Kursovoi_Filippov.Utils;
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

namespace Kursovoi_Filippov.Pages
{
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(txbFamilya.Text))
            errors.AppendLine("Укажите фамлию!");
            if (string.IsNullOrEmpty(txbName.Text))
                errors.AppendLine("Укажите имя!");
            if (string.IsNullOrEmpty(txbOtchestvo.Text))
                errors.AppendLine("Укажите отчество!");
            if (string.IsNullOrEmpty(txbPhone.Text))
                errors.AppendLine("Укажите номер телефона!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (AgenstvNedvezjEntities.GetContext().Users.Count(x => x.Login == txbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Prodavec prodavecData = new Prodavec()
                {
                    Familia = txbFamilya.Text,
                    Name = txbName.Text,
                    Otchestvo = txbOtchestvo.Text,
                    Tel = txbPhone.Text,
                };

                Users userData = new Users()
                {
                    Login = txbLogin.Text,
                    Password = txbPass.Password,
                    idProdavec = prodavecData.idProdavec,
                };
                AgenstvNedvezjEntities.GetContext().Prodavec.Add(prodavecData);
                AgenstvNedvezjEntities.GetContext().Users.Add(userData);
                AgenstvNedvezjEntities.GetContext().SaveChanges();
                MessageBox.Show("Вы успешно зарегестрированы!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.Navigate(new SignIn());
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
