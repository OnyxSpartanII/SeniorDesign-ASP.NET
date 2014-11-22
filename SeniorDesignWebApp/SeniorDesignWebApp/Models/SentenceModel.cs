using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class SentenceModel
    {
        public int ID { get; set; }
        public DateTime DispositionDate { get; set; }
        public DateTime SentenceDate { get; set; }
        public decimal JailTime { get; set; }
        public decimal ProbationTime { get; set;}
        public decimal SuspensionTime { get; set; }
        public decimal Fines { get; set; }
        public decimal CommunityService { get; set; }
        public bool ConditionsOfRelease { get; set; }
    }

    public class SentenceDbContext : DbContext
    {
        public DbSet<SentenceModel> Sentences { get; set; }
    }
}