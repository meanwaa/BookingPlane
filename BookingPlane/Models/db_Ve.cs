//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingPlane.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class db_Ve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public db_Ve()
        {
            this.db_Booking = new HashSet<db_Booking>();
        }
    
        public int IDV { get; set; }
        public string LoaiVe { get; set; }
        public string GiaVe { get; set; }
        public Nullable<int> IDCB { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_Booking> db_Booking { get; set; }
        public virtual db_ChuyenBay db_ChuyenBay { get; set; }
    }
}
