using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeniorDesignWebApp.Models
{
    public class CaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Status { get; set; }
        public string Summary { get; set; }
        public int GrandJury { get; set; }
        public int CourtId { get; set; }
        public int DefenseId { get; set; }
        public int VictimsId { get; set; }
        public int ADCId { get; set; }
        public int SentenceId { get; set; }
    }

    public class CaseDbContext:DbContext
    {
        public DbSet<CaseModel> Cases { get; set; }
    }
}