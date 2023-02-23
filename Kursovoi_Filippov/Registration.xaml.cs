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
            //проверяем есть ли такой же пользователь
            if (AgenstvoNedvezjEntities2.GetContext().Users.Count(x => x.Login == txbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            //если прошли проверку логина, записываем нового пользователя с ролью 2
            try
            {
                Users userData = new Users()
                {
                    Login = txbLogin.Text, //получаем даные логина
                    Password = txbPass.Text, //получаем парол
                };
                AgenstvoNedvezjEntities2.GetContext().Users.Add(userData);//добавление объекта
                AgenstvoNedvezjEntities2.GetContext().SaveChanges();//сохранение
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
