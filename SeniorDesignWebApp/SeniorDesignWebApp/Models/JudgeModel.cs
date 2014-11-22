using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeniorDesignWebApp.Models
{
    public class JudgeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Career { get; set; }
        public int Race { get; set; }
    }

    public class JudgeDbContext : DbContext
    {
        public DbSet<JudgeModel> Judges { get; set; }
    }
}