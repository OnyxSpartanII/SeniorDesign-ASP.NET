//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeniorDesignWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class charge
    {
        public charge(long cid, int t, long acdid, long count, string stat, string det, int p, int d)
        {
            this.ChargeId = cid;
            this.Type = t;
            this.ArrestChargeDetails_Id = acdid;
            this.Counts = count;
            this.Statute = stat;
            this.Details = det;
            this.Plea = p;
            this.Disposition = d;
        }

        public long ChargeId { get; set; }
        public int Type { get; set; }
        public long ArrestChargeDetails_Id { get; set; }
        public long Counts { get; set; }
        public string Statute { get; set; }
        public string Details { get; set; }
        public int Plea { get; set; }
        public int Disposition { get; set; }
    
        public virtual arrestchargedetail arrestchargedetail { get; set; }
    }
}
