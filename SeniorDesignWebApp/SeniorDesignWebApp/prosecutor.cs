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
    
    public partial class prosecutor
    {
        public prosecutor()
        {
            this.casetables = new HashSet<casetable>();
        }

        public prosecutor(long pid, string n, bool g, int c)
        {
            this.ProsecutorId = pid;
            this.Name = n;
            this.Gender = g;
            this.Career = c;

            this.casetables = new HashSet<casetable>();
        }
    
        public long ProsecutorId { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int Career { get; set; }
    
        public virtual ICollection<casetable> casetables { get; set; }
    }
}
