using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestPaper.Dal;
using TestPaper.Models;

namespace TestPaper.Controllers
{
    public class AutoCreateTestPaperController : Controller
    {
        private TestPaperContext db = new TestPaperContext();
        // GET: AutoCreateTestPaper
        public ViewResult Index()
        {
            QuestionInfo questioninfo = new QuestionInfo
            {
                CalculateQuestions = db.CalculateQuestion.ToList(),
                CheckQuestions = db.CheckQuestions.ToList(),
                ChoiceQuestions = db.ChoiceQuestions.ToList(),
                FillQuestions = db.FillQuestions.ToList(),
            };
            return View(questioninfo);
        }
        public ActionResult AutoCreate(string Subject ,string diffcult ,string questionNum )
        {
            try
            {
                int num = Convert.ToInt32(questionNum);
                TestPaperInfo testpaperinfo = new TestPaperInfo()
                {
                    Name = "自动生成试卷" + DateTime.Now.ToString(),
                    CalculateQuestions = db.CalculateQuestion.Where(u => u.Subject == Subject && u.Difficulty == diffcult).OrderBy(u => Guid.NewGuid()).Take(num).ToList(),
                    CheckQuestions = db.CheckQuestions.Where(u => u.Subject == Subject && u.Difficulty == diffcult).OrderBy(u => Guid.NewGuid()).Take(num).ToList(),
                    ChoiceQuestions = db.ChoiceQuestions.Where(u => u.Subject == Subject && u.Difficulty == diffcult).OrderBy(u => Guid.NewGuid()).Take(num).ToList(),
                    FillQuestions = db.FillQuestions.Where(u => u.Subject == Subject && u.Difficulty == diffcult).OrderBy(u => Guid.NewGuid()).Take(num).ToList(),
                };
                db.TestPaperInfoes.Add(testpaperinfo);
                db.SaveChanges();
                return RedirectToAction("Index", "TestPaperInfoes");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View("Error");
            }

        }
    }
}