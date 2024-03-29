//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovoi_Filippov
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    public partial class Nedvezj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nedvezj()
        {
            this.Sdelki = new HashSet<Sdelki>();
        }
    
        public int idNedvezj { get; set; }
        public int idNedvezjType { get; set; }
        public int idRayon { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public int Price { get; set; }
        public string Opisanie { get; set; }
        public int idProdavec { get; set; }
        public string Image { get; set; }
        public bool Actual { get; set; }

        public string SquareM
        {
            get
            {
                return Square.ToString() + " M²";
            }
        }

        public string Actuality
        {
            get
            {
                string result;
                if (Actual == true)
                {
                    result = "Актуально";
                }
                else
                {
                    result = "Продано";
                }

                return result;
            }
        }

        public SolidColorBrush colorBrush
        {
            get
            {
                if (Actual == true)
                {
                    return Brushes.Green;
                }
                else
                {
                    return Brushes.Red;
                }
            }
        }
        public string ImagePath
        {
            get
            {
                return "/Resources/" + this.Image + ".jpg";
            }
        }


        public virtual NedvezjType NedvezjType { get; set; }
        public virtual Prodavec Prodavec { get; set; }
        public virtual Rayon Rayon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sdelki> Sdelki { get; set; }
    }
}
