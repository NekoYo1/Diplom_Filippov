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
    public partial class NedvijList : Page
    {
        public NedvijList()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AgenstvNedvezjEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListObserve.ItemsSource = AgenstvNedvezjEntities.GetContext().Nedvezj.Where(x => x.Actual == true).ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnBtnInfoProdavec_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Продавец: {((sender as Button).DataContext as Nedvezj).Prodavec.ProdavecName}\nКонтакты: {((sender as Button).DataContext as Nedvezj).Prodavec.Tel}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
