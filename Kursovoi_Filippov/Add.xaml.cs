using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Nedvezj _currentNedvezj = new Nedvezj();


        public Add(Nedvezj selectedNedvezj)
        {
            InitializeComponent();
            if (selectedNedvezj != null)
                _currentNedvezj = selectedNedvezj;

            DataContext = _currentNedvezj;

            TypeNed.ItemsSource = AgenstvNedvezjEntities.GetContext().NedvezjType.ToList();
            RayonN.ItemsSource = AgenstvNedvezjEntities.GetContext().Rayon.ToList();
            ProdavecC.ItemsSource = AgenstvNedvezjEntities.GetContext().Prodavec.ToList();
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
            if (string.IsNullOrEmpty(_currentNedvezj.PriceRub))
            {
                errors.AppendLine("Укажите цену!");
            }
            else
            {
                if (Convert.ToInt16(_currentNedvezj.Price) <= 0)
                    errors.AppendLine("Цена не может быть меньше или равна 0!");
            }
            if (string.IsNullOrWhiteSpace(_currentNedvezj.Opisanie))
                errors.AppendLine("Добавьте описание!");

            if (_currentNedvezj.NedvezjType == null)
                errors.AppendLine("Выбирите тип недвижимости!");

            if (_currentNedvezj.Rayon == null)
                errors.AppendLine("Выбирите район!");

            if (_currentNedvezj.Prodavec == null)
                errors.AppendLine("Выбирите продавца!");



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
                MessageBox.Show(errors.ToString(),"Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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
                    MessageBox.Show(ex.Message.ToString());
            }
        }
    }

    }

