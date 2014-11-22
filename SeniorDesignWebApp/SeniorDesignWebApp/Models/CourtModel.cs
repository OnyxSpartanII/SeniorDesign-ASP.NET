using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class CourtModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class CourtDbContext : DbContext
    {
        public DbSet<CourtModel> Courts { get; set; }
    }
}