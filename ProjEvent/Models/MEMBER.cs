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
    
    public partial class MEMBER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEMBER()
        {
            this.FOLLOWINGs = new HashSet<FOLLOWING>();
            this.FOLLOWINGs1 = new HashSet<FOLLOWING>();
            this.PROMOTE_E = new HashSet<PROMOTE_E>();
            this.PROMOTE_L = new HashSet<PROMOTE_L>();
            this.TICKETs = new HashSet<TICKET>();
            this.EVENTs = new HashSet<EVENT>();
            this.EVENTs1 = new HashSet<EVENT>();
            this.LOCATIONs = new HashSet<LOCATION>();
        }
    
        public short MEMBER_ID { get; set; }
        public long NATIONAL_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string SEX { get; set; }
        public Nullable<System.DateTime> BIRTH_DATE { get; set; }
        public string ADDRESS { get; set; }
        public string E_MAIL { get; set; }
        public string PHONE { get; set; }
        public string CREDIT_CARD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWING> FOLLOWINGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWING> FOLLOWINGs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROMOTE_E> PROMOTE_E { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROMOTE_L> PROMOTE_L { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKETs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENT> EVENTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENT> EVENTs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
    }
}