//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtelMvcProje.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblDurum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblDurum()
        {
            this.TblMisafir = new HashSet<TblMisafir>();
        }
    
        public int DurumID { get; set; }
        public string DurumAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblMisafir> TblMisafir { get; set; }
    }
}
