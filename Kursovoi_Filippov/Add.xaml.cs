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


        public Add()
        {
            InitializeComponent();
            TypeNed.ItemsSource = AgenstvoNedvezjEntities.GetContext().NedvezjType.ToList();
            RayonN.ItemsSource = AgenstvoNedvezjEntities.GetContext().Rayon.ToList();
            ProdavecC.ItemsSource = AgenstvoNedvezjEntities.GetContext().Prodavec.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //if (string.IsNullOrWhiteSpace(_currentNedvezj.Address))
            //    errors.AppendLine("Укажите адрес");
            //if (string.IsNullOrWhiteSpace(_currentNedvezj.SquareM))
            //    errors.AppendLine("Укажите площадь");
            //if (string.IsNullOrWhiteSpace(_currentNedvezj.PriceRub))
            //    errors.AppendLine("Укажите цену");
            //if (string.IsNullOrWhiteSpace(_currentNedvezj.Opisanie))
            //    errors.AppendLine("Добавьте описание");

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
                MessageBox.Show(errors.ToString());
                return;
            }

            _currentNedvezj.Image= "хуй";

            //if (_currentNedvezj.IdNedvezj == 0)
                AgenstvoNedvezjEntities.GetContext().Nedvezj.Add(_currentNedvezj);

            try
            {

                AgenstvoNedvezjEntities.GetContext().SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                        }
                }
            }

            try
            {
                AgenstvoNedvezjEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
