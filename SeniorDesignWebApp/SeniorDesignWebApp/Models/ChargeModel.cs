using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class ChargeModel
    {
        public int ID { get; set; }
        public int ACD_Id { get; set; }
        public int Counts { get; set; }
        public string Statute { get; set; }
        public string Details { get; set; }
        public int Plea { get; set; }
        public int Disposition { get; set; }
        public int Sentence { get; set; }
        public int Suspension { get; set; }
        public int Probation { get; set; }
    }

    public class ChargeDbContext : DbContext
    {
        public DbSet<ChargeModel> Charges { get; set; }
    }
}