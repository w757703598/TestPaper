using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestPaper.Controllers
{
    public class PartialViewController : Controller
    {
        //无关代码
        // GET: PartialView
        public ActionResult Index()
        {
            return View();
        }  
        public PartialViewResult ChildAction(DateTime time )
        {
            string greetings = string.Empty;
            if (time.Hour > 18)
            {
                greetings = "Good Eventing .NOW is " + time.ToString("HH:mm:ss");
            }else if (time.Hour > 12)
            {
                greetings = "Good afternoon. Now is " + time.ToString("HH:mm:ss");
            }
            else
            {
                greetings = "Good morning. Now is " + time.ToString("HH:mm:ss");
            }
            return PartialView("ChildAction", greetings);
        }
    }
}