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
    
    public partial class victim
    {
        public victim()
        {
            this.casetables = new HashSet<casetable>();
        }

        public victim(long vid, int t, int m, int fo, int fe)
        {
            this.VictimsId = vid;
            this.Total = t;
            this.Minor = m;
            this.Foreigner = fo;
            this.Female = fe;
            
            this.casetables = new HashSet<casetable>();
        }
    
        public long VictimsId { get; set; }
        public int Total { get; set; }
        public int Minor { get; set; }
        public int Foreigner { get; set; }
        public int Female { get; set; }
    
        public virtual ICollection<casetable> casetables { get; set; }
    }
}
