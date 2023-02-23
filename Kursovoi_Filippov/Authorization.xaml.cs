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

namespace Kursovoi_Filippov
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userData = AgenstvoNedvezjEntities2.GetContext().Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userData == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Manager.MainFrame.Navigate(new List());

                    MessageBox.Show("Здравствуйте, " + userData.Login + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnRegIn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Registration());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new List());
        }
    }
}
