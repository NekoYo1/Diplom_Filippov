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
    
    public partial class Sdelki
    {
        public int IdSdelki { get; set; }
        public int IdNedvej { get; set; }
        public int IdProdavec { get; set; }
        public System.DateTime DateSdelki { get; set; }
        public int KomissiaAgenstva { get; set; }
    
        public virtual Nedvezj Nedvezj { get; set; }
        public virtual Prodavec Prodavec { get; set; }
    }
}
