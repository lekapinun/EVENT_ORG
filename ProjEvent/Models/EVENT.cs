//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjEvent.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EVENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EVENT()
        {
            this.TICKETs = new HashSet<TICKET>();
            this.LOCATIONs = new HashSet<LOCATION>();
            this.MEMBERs = new HashSet<MEMBER>();
            this.MEMBERs1 = new HashSet<MEMBER>();
        }
    
        public short EVENT_ID { get; set; }
        public string EVENT_NAME { get; set; }
        public string CATEGORY { get; set; }
        public string DETAIL { get; set; }
        public string PICTURE { get; set; }
        public string VIDEO { get; set; }
        public Nullable<System.DateTime> TIME_START_E { get; set; }
        public Nullable<System.DateTime> TIME_END_E { get; set; }
        public Nullable<byte> CONDITION_MIN_AGE { get; set; }
        public Nullable<byte> CONDITION_MAX_AGE { get; set; }
        public string CONDITION_SEX { get; set; }
        public Nullable<short> SOLD_OUT_SEAT { get; set; }
        public Nullable<short> MAX_SEAT { get; set; }
        public Nullable<short> PRICE { get; set; }
        public Nullable<short> PROMOTE_E_ID { get; set; }

        public string Owner_member { get; set; }
        public string Event_location { get; set; }
        public DateTime S_DATE { get; set; }
        public DateTime E_DATE { get; set; }
        public TimeSpan S_TIME { get; set; }
        public TimeSpan E_TIME { get; set; }


        public virtual PROMOTE_E PROMOTE_E { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKETs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEMBER> MEMBERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEMBER> MEMBERs1 { get; set; }
    }
}
