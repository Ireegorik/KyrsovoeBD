//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rooms
    {
        public int Room_Id { get; set; }
        public string Room_Num { get; set; }
        public string Status { get; set; }
        public string Holder { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
