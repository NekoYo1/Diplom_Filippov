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
    public partial class AddEditPageForUser : Page
    {
        private Nedvezj _currentNedvezj = new Nedvezj();

        public AddEditPageForUser(Nedvezj selectedNedvezj)
        {
            InitializeComponent();
            if (selectedNedvezj != null)
                _currentNedvezj = selectedNedvezj;
            DataContext = _currentNedvezj;
            tboxProdavec.Text = Manager.currentProdavec.ProdavecName;

            TypeNed.ItemsSource = AgenstvNedvezjEntities.GetContext().NedvezjType.ToList();
            RayonN.ItemsSource = AgenstvNedvezjEntities.GetContext().Rayon.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentNedvezj.Address))
                errors.AppendLine("Укажите адрес!");
            if (string.IsNullOrEmpty(_currentNedvezj.SquareM))
            {
                errors.AppendLine("Укажите площадь!");
            }
            else
            {
                if (Convert.ToInt16(_currentNedvezj.Square) <= 0)
                    errors.AppendLine("Площадь не может быть меньше или равна 0!");
            }
            if (string.IsNullOrEmpty(_currentNedvezj.Price.ToString()))
            {
                errors.AppendLine("Укажите цену!");
            }
            else
            {
                if (Convert.ToInt32(_currentNedvezj.Price) <= 0)
                    errors.AppendLine("Цена не может быть меньше или равна 0!");
            }
            if (string.IsNullOrWhiteSpace(_currentNedvezj.Opisanie))
                errors.AppendLine("Добавьте описание!");

            if (_currentNedvezj.NedvezjType == null)
                errors.AppendLine("Выбирите тип недвижимости!");

            if (_currentNedvezj.Rayon == null)
                errors.AppendLine("Выбирите район!");


            if (RA.IsChecked == true)
            {
                _currentNedvezj.Actual = true;
            }
            else
            {
                _currentNedvezj.Actual = false;
            }
            if (errors.Length > 0)

            {
                MessageBox.Show(errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _currentNedvezj.idProdavec = Manager.currentProdavec.idProdavec;
            if (_currentNedvezj.idNedvezj == 0)
                AgenstvNedvezjEntities.GetContext().Nedvezj.Add(_currentNedvezj);

            try
            {
                AgenstvNedvezjEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
