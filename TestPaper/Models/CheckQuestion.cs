﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestPaper.Models
{
    public class CheckQuestion : Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Display(Name = "题目")]
        public string Title { get; set; }
        [Display(Name = "选项")]
        public string  Options { get; set; }
        [Display(Name = "答案")]
        public bool Answer { get; set; }
        public virtual ICollection<TestPaperInfo> CalculateQuestions { get; set; } = new List<TestPaperInfo>();
    }
}