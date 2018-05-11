using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TestPaper.Models
{
    public class TestPaperInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="试卷名称")]
        public string Name { get; set; }
        public virtual ICollection<ChoiceQuestion> ChoiceQuestions { get; set; } = new List<ChoiceQuestion>();
        public virtual ICollection<CheckQuestion> CheckQuestions { get; set; } = new List<CheckQuestion>();
        public virtual ICollection<FillQuestion> FillQuestions { get; set; } = new List<FillQuestion>();
        public virtual ICollection<CalculateQuestion> CalculateQuestions { get; set; } = new List<CalculateQuestion>();
    }
    public class TestPaperInfoMap : EntityTypeConfiguration<TestPaperInfo>
    {
        public TestPaperInfoMap()
        {
            ToTable("TestPaperInfo");
            //Property(m => m.ChoiceQuestions).IsRequired();
        }
    }
}