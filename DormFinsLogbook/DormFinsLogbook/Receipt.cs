//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DormFinsLogbook
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receipt
    {
        public int ID_receipt { get; set; }
        public Nullable<int> ReceiptTenant { get; set; }
        public Nullable<decimal> PayLiving { get; set; }
        public Nullable<System.DateTime> PayData { get; set; }
    
        public virtual Tenant Tenant { get; set; }
    }
}