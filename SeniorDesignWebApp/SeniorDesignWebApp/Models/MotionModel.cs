using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class MotionModel
    {
        public int ID { get; set; }
        public int CaseId { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class MotionDbContext: DbContext
    {
        public DbSet<MotionModel> Motions { get; set; }
    }
}