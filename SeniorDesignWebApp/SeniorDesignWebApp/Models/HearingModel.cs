using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class HearingModel
    {
        public int ID { get; set; }
        public int CaseId { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class HearingDbContext : DbContext
    {
        public DbSet<HearingModel> Hearings { get; set; }
    }
}