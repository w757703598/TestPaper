using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestPaper.Models
{
    public class Question
    {
        [Display(Name = "分数")]
        public int Score { get; set; }
        [Display(Name ="学科")]
        public string Subject { get; set; }
        [Display(Name ="章节")]
        public string Section { get; set; }
        [Display(Name = "难易程度")]
        public string Difficulty { get; set; }
    }
}