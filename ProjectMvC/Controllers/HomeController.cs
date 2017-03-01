using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMvC.Models;
using ProjectMvC.DataModels;
using System.Net;


namespace ProjectMvC.Controllers
{
    public class HomeController : Controller
    {
        dbModel model = new dbModel();


        public ActionResult Index(string platform)
        {

            var newModel = model.smsList.ToList();

            return View();
        }

        public ActionResult indexPartial(string platform)
        {
            if (Session["platformKey"] == null)
            {
                platform = "ps4";
            }
            else
            {
                platform = Session["platformKey"].ToString();
            }

            model.makeModel();

            var newModel = model.smsList.ToList().Where(w => w.platform == platform);

            return PartialView("indexPartial",newModel);
        }
   

        public ActionResult Moments()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SetVariable(string key, string value)
        {
            Session[key] = value;

            return new HttpStatusCodeResult(HttpStatusCode.OK); 
        }
     
    }
}
