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
        public int idSdelki { get; set; }
        public int idNedvezj { get; set; }
        public int idProdavec { get; set; }
        public int Komissia { get; set; }
        public System.DateTime Data { get; set; }
    
        public virtual Nedvezj Nedvezj { get; set; }
        public virtual Prodavec Prodavec { get; set; }
    }
}
