using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeniorDesignWebApp.Models
{
    public class ProsecutorModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Career { get; set; }
    }

    public class ProsecutorDbContext : DbContext
    {
        public DbSet<ProsecutorModel> Prosecutors { get; set; }
    }
}