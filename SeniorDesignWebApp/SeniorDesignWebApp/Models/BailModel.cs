using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class BailModel
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public bool Detained { get; set; }
        public decimal Amount { get; set; }
        public int ACD_Id { get; set; }
    }

    public class BailDbContext : DbContext
    {
        public DbSet<BailModel> Bails { get; set; }
    }
}