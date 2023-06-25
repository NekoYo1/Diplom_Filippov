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
    /// <summary>
    /// Логика взаимодействия для NedvijListEdit.xaml
    /// </summary>
    public partial class NedvijListEdit : Page
    {
        public NedvijListEdit()
        {
            InitializeComponent();
            ListObserve.ItemsSource = AgenstvNedvezjEntities.GetContext().Nedvezj.ToList();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var nedvezjremoverange = ListObserve.SelectedItems.Cast<Nedvezj>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить данные?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AgenstvNedvezjEntities.GetContext().Nedvezj.RemoveRange(nedvezjremoverange);

                    AgenstvNedvezjEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    ListObserve.ItemsSource = AgenstvNedvezjEntities.GetContext().Nedvezj.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AgenstvNedvezjEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListObserve.ItemsSource = AgenstvNedvezjEntities.GetContext().Nedvezj.ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Nedvezj));
        }
    }
}
