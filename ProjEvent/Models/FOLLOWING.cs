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
    
    public partial class FOLLOWING
    {
        public short MEMBER_ID { get; set; }
        public short FOLLOWING_ID { get; set; }
        public Nullable<System.DateTime> HISTORY { get; set; }
    
        public virtual MEMBER MEMBER { get; set; }
        public virtual MEMBER MEMBER1 { get; set; }
    }
}
