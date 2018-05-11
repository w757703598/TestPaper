using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TestPaper.Dal;
using TestPaper.Models;

namespace TestPaper.Controllers
{
    public class TestPaperInfoesController : Controller
    {
        private TestPaperContext db = new TestPaperContext();

        // GET: TestPaperInfoes
        public ActionResult Index()
        {
            return View(db.TestPaperInfoes.ToList());
        }

        // GET: TestPaperInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestPaperInfo testPaperInfo = db.TestPaperInfoes.Find(id);
            if (testPaperInfo == null)
            {
                return HttpNotFound();
            }
            return View(testPaperInfo);
        }

        // GET: TestPaperInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestPaperInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TestPaperInfo testPaperInfo)
        {
            if (ModelState.IsValid)
            {
                db.TestPaperInfoes.Add(testPaperInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testPaperInfo);
        }

        // GET: TestPaperInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestPaperInfo testPaperInfo = db.TestPaperInfoes.Find(id);
            if (testPaperInfo == null)
            {
                return HttpNotFound();
            }
            return View(testPaperInfo);
        }

        // POST: TestPaperInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TestPaperInfo testPaperInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testPaperInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testPaperInfo);
        }

        // GET: TestPaperInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestPaperInfo testPaperInfo = db.TestPaperInfoes.Find(id);
            if (testPaperInfo == null)
            {
                return HttpNotFound();
            }
            return View(testPaperInfo);
        }

        // POST: TestPaperInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestPaperInfo testPaperInfo = db.TestPaperInfoes.Find(id);
            db.TestPaperInfoes.Remove(testPaperInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 返回添加试卷页面
        /// </summary>
        /// <param name="id">试卷序号</param>
        /// <param name="testType">跳转前的试卷类型</param>
        /// <param name="subject">跳转前的试题科目</param>
        /// <param name="section">跳转前的试题章节</param>
        /// <param name="diffcult">跳转前的试题难易程度</param>
        /// <returns></returns>
        public ActionResult AddQuestions(int ? id,string  testType , string subject, string section, string diffcult )
        {
            ViewData["testType"] = testType;
            ViewData["subject"] = subject;
            ViewData["section"] = section;
            ViewData["diffcult"] = diffcult;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestPaperInfo testPaperInfo = db.TestPaperInfoes.Find(id);
            if (testPaperInfo == null)
            {
                return HttpNotFound();
            }
            return View(testPaperInfo);
        }
        /// <summary>
        /// 添加试题
        /// </summary>
        /// <param name="id">试题id</param>
        /// <param name="testpaperid">试卷id</param>
        /// <param name="testType">跳转前的试卷类型</param>
        /// <param name="subject">跳转前的试题科目</param>
        /// <param name="section">跳转前的试题章节</param>
        /// <param name="diffcult">跳转前的试题难易程度</param>
        /// <returns></returns>
        public ActionResult Add(Guid? id,int ? testpaperid ,string type,string subject,string section,string diffcult  )
        {
            TestPaperInfo testPaperInfo = db.TestPaperInfoes.Find(testpaperid);

            switch (type)
            {
                case "选择题":
                    ChoiceQuestion choicequestion = db.ChoiceQuestions.Find(id);
                    testPaperInfo.ChoiceQuestions.Add(choicequestion);
                    break;
                case "填空题":
                    FillQuestion fillquestion = db.FillQuestions.Find(id);
                    testPaperInfo.FillQuestions.Add(fillquestion);
                    break;
                case "判断题":
                    CheckQuestion checkquestion = db.CheckQuestions.Find(id);
                    testPaperInfo.CheckQuestions.Add(checkquestion);
                    break;
                case "计算题":
                    CalculateQuestion calculatate = db.CalculateQuestion.Find(id);
                    testPaperInfo.CalculateQuestions.Add(calculatate);
                    break;
            }
            db.SaveChanges();//保存数据
            //返回到添加试题页面
            return RedirectToAction("AddQuestions",new { id = testpaperid ,testType= type, subject =subject, section = section, diffcult = diffcult });
        }
        public ActionResult ChildView(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestPaperInfo testPaperInfo = db.TestPaperInfoes.Find(id);
            if (testPaperInfo == null)
            {
                return HttpNotFound();
            }
            return View(testPaperInfo);
        }
        [ValidateInput(false)]
        [HttpPost]
        public FileResult ExportWord(string html )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(html);
            var byteArray = System.Text.Encoding.Default.GetBytes(sb.ToString());
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            return File(byteArray, "application/ms-word", "TestPaper" + ".doc");
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
