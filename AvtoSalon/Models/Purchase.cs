//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AvtoSalon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> CarID { get; set; }
        public Nullable<int> AccessoryID { get; set; }
        public Nullable<int> StaffID { get; set; }
    
        public virtual Accessory Accessory { get; set; }
        public virtual Client Client { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
