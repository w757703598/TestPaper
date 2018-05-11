using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestPaper.Common;
using TestPaper.Dal;

namespace TestPaper.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(View="~/Views/Shared/Error.cshtml")]
        public ContentResult ImportFile( HttpPostedFileBase file)
        {
            using (TestPaperContext db=new TestPaperContext())
            {
                var m = db.ChoiceQuestions.ToList();
            }


            string sb = null;
            if (file.ContentLength > 0)
            {
                TestPaperHelper.PaperAnalyze(file.InputStream);

            }
            return Content( sb);
        }
    }
}