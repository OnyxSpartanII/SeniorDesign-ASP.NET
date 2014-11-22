using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class VictimModel
    {
        public int ID { get; set; }
        public int Total { get; set; }
        public int Minors { get; set; }
        public int Foreigners { get; set; }
        public int Females { get; set; }
    }

    public class VictimDbContext : DbContext
    {
        public DbSet<VictimModel> Victims { get; set; }
    }
}