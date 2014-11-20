using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeniorDesignWebApp.Models
{
    public class IDatabaseModel
    {
        public int ID { get; set; }
    }

    public class IDbContext : DbContext
    {
        public DbSet<IDatabaseModel> IDatabaseModels { get; set; }
    }
}