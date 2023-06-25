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
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userData = AgenstvNedvezjEntities.GetContext().Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userData == null)
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txbLogin.Text == "admin" && psbPassword.Password == "admin")
                {
                    MessageBox.Show("Здравствуйте, Администратор" + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Manager.MainFrame.Navigate(new NedvijListEdit());
                }
                else
                {
                    MessageBox.Show("Здравствуйте, " + userData.Prodavec.ProdavecName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Manager.currentProdavec = userData.Prodavec;
                    Manager.currentUser = userData;
                    Manager.MainFrame.Navigate(new NedvijListForUser());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnRegIn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SignUp());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new NedvijList());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }
    }
}
