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
    
    public partial class TICKET
    {
        public short ID_TICKET { get; set; }
        public Nullable<int> AMOUNT { get; set; }
        public Nullable<short> MEMBER_ID { get; set; }
        public short EVENT_ID { get; set; }
    
        public virtual EVENT EVENT { get; set; }
        public virtual MEMBER MEMBER { get; set; }
    }
}