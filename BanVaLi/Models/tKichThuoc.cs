//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanVaLi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tKichThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tKichThuoc()
        {
            this.tDanhMucSP = new HashSet<tDanhMucSP>();
        }
    
        public string MaKichThuoc { get; set; }
        public string KichThuoc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tDanhMucSP> tDanhMucSP { get; set; }
    }
}
