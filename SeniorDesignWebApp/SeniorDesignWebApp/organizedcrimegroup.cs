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
    
    public partial class organizedcrimegroup
    {
        public organizedcrimegroup()
        {
            this.casetables = new HashSet<casetable>();
        }
    
        public int OCGId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Scope { get; set; }
        public int Race { get; set; }
    
        public virtual ICollection<casetable> casetables { get; set; }
    }
}
