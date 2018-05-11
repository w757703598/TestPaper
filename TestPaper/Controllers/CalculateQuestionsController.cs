using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestPaper.Dal;
using TestPaper.Models;

namespace TestPaper.Controllers
{
    public class CalculateQuestionsController : Controller
    {
        private TestPaperContext db = new TestPaperContext();

        // GET: CalculateQuestions
        public ActionResult Index()
        {
            return View(db.CalculateQuestion.ToList());
        }

        // GET: CalculateQuestions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculateQuestion calculateQuestion = db.CalculateQuestion.Find(id);
            if (calculateQuestion == null)
            {
                return HttpNotFound();
            }
            return View(calculateQuestion);
        }

        // GET: CalculateQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalculateQuestions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Answer,Score,Subject,Section,Difficulty")] CalculateQuestion calculateQuestion)
        {
            if (ModelState.IsValid)
            {
                calculateQuestion.Id = Guid.NewGuid();
                db.CalculateQuestion.Add(calculateQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calculateQuestion);
        }

        // GET: CalculateQuestions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculateQuestion calculateQuestion = db.CalculateQuestion.Find(id);
            if (calculateQuestion == null)
            {
                return HttpNotFound();
            }
            return View(calculateQuestion);
        }

        // POST: CalculateQuestions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Answer,Score,Subject,Section,Difficulty")] CalculateQuestion calculateQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calculateQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calculateQuestion);
        }

        // GET: CalculateQuestions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculateQuestion calculateQuestion = db.CalculateQuestion.Find(id);
            if (calculateQuestion == null)
            {
                return HttpNotFound();
            }
            return View(calculateQuestion);
        }

        // POST: CalculateQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CalculateQuestion calculateQuestion = db.CalculateQuestion.Find(id);
            db.CalculateQuestion.Remove(calculateQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 根据试卷课题、章节、难易程度进行筛选
        /// </summary>
        /// <param name="testpaperid">试卷序号</param>
        /// <param name="testtype">试卷类型</param>
        /// <param name="subject">课题</param>
        /// <param name="section">章节</param>
        /// <param name="diffcult">难易度</param>
        /// <returns>分布视图</returns>
        public PartialViewResult GetTestQuestionInfoByType( int testpaperid,string testtype, string subject, string section, string diffcult )
        {
            ViewData["testpaperid"] = testpaperid;
            ViewData["TestType"] = testtype;
            ViewData["subject"] = subject;
            ViewData["section"] = section;
            ViewData["diffcult"] = diffcult;
            var calculatequestion = db.CalculateQuestion.Where(u => true);
            if (subject != null)
            {
                calculatequestion = calculatequestion.Where(u => u.Subject.Contains(subject));
            }
            if (section != null)
            {
                calculatequestion = calculatequestion.Where(u => u.Section.Contains(section));
            }
            if (diffcult != null)
            {
                calculatequestion = calculatequestion.Where(u => u.Difficulty.Contains(diffcult));
            }
            return PartialView("ChildAction", calculatequestion.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
