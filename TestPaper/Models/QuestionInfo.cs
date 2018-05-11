using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestPaper.Models
{
    public class QuestionInfo
    {
        public virtual ICollection<ChoiceQuestion> ChoiceQuestions { get; set; } = new List<ChoiceQuestion>();
        public virtual ICollection<CheckQuestion> CheckQuestions { get; set; } = new List<CheckQuestion>();
        public virtual ICollection<FillQuestion> FillQuestions { get; set; } = new List<FillQuestion>();
        public virtual ICollection<CalculateQuestion> CalculateQuestions { get; set; } = new List<CalculateQuestion>();
    }
}