using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeniorDesignWebApp.Models
{
    public class DefendantModel
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public int Race { get; set; }
    }

    public class DefendantDbContext : DbContext
    {
        public DbSet<DefendantModel> Defendants { get; set; }
    }
}