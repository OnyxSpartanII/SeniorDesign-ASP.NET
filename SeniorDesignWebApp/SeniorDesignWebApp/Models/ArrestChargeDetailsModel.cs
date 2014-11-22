using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class ArrestChargeDetailsModel
    {
        public int ID { get; set; }
        public DateTime ChargeDate { get; set; }
        public DateTime ArrestDate { get; set; }
        public int Role { get; set; }
        public bool LaborTrafficking { get; set; }
        public bool MinorSexTrafficking { get; set; }
        public bool AdultSexTrafficking { get; set; }
        public int FelonyCounts { get; set; }
        public int MisdemeanorCounts { get; set; }
        public int FelonySentences { get; set; }
        public int MisdemeanorSentences { get; set; }
    }

    public class ACDDbContext:DbContext
    {
        public DbSet<ArrestChargeDetailsModel> ACDs { get; set; }
    }
}