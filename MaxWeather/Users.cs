//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaxWeather
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> city { get; set; }
        public int role { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
