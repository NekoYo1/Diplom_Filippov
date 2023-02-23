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
    
    public partial class Nedvezj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nedvezj()
        {
            this.Sdelki = new HashSet<Sdelki>();
        }
    
        public int IdNedvezj { get; set; }
        public int IdNedvezjType { get; set; }
        public int IdRayon { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public int Price { get; set; }
        public string Opisanie { get; set; }
        public int IdProdavec { get; set; }
        public string Image { get; set; }
        public bool Actual { get; set; }

        public string PriceRub
        {
            get
            {
                return Price.ToString() + this.Price + " рублей";
            }
        }

        public string SquareM
        {
            get
            {
                return Square.ToString() + this.Square + " м²";
            }
        }

        public string TypeNJ
        {
            get
            {
                return NedvezjType.NedvezjTypeName.ToString();
            }
        }

        public string ProdavecName
        {
            get
            {
                return Prodavec.Familia + " " + Prodavec.Name + " " + Prodavec.Otchestvo;
            }
        }

        public string RayonName
        {
            get
            {
                return Rayon.NameRayona.ToString();
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
