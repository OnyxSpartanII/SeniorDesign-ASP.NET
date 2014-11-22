using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class DefenseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public int Career { get; set; }
        public int Counsel { get; set; }
    }

    public class DefenseDbContext : DbContext
    {
        public DbSet<DefenseModel> Defenses { get; set; }
    }
}