using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TestPaper.Models;

namespace TestPaper.Dal
{
    public class TestPaperContext:DbContext
    {
        public TestPaperContext() : base("DefaultConnection")
        {

        }
        public DbSet<ChoiceQuestion> ChoiceQuestions { get; set; }
        public DbSet<CheckQuestion> CheckQuestions { get; set; }
        public DbSet<FillQuestion> FillQuestions { get; set; }
        public DbSet<CalculateQuestion> CalculateQuestion { get; set; }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<TestPaperInfo>().ToTable("TestPaperInfo").HasKey(m => m.Id);//映射到表并设置主键
        }
        public System.Data.Entity.DbSet<TestPaper.Models.TestPaperInfo> TestPaperInfoes { get; set; }
    }
}