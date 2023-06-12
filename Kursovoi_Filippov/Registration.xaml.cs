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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }



        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            if (AgenstvNedvezjEntities.GetContext().Users.Count(x => x.Login == txbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с такими данными есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           
            try
            {
                Users userData = new Users()
                {
                    Login = txbLogin.Text, 
                    Password = txbPass.Text, 
                };
                AgenstvNedvezjEntities.GetContext().Users.Add(userData);
                AgenstvNedvezjEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
