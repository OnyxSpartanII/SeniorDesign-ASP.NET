using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class OrganizedCrimeGroupModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Race { get; set; }
        public int Scope { get; set; }
    }

    public class OCGDbContext : DbContext
    {
        public DbSet<OrganizedCrimeGroupModel> OCGs { get; set; }
    }
}