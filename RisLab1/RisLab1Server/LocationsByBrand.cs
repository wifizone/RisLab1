//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RisLab1Server
{
    using System;
    using System.Collections.Generic;
    
    public partial class LocationsByBrand
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int LocationId { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Location Location { get; set; }
    }
}
