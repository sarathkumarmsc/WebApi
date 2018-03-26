using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models.DAL;
using System.Data;
namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        Models.DAL.db dblayer = new Models.DAL.db();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public JsonResult getrecord()
        {
            DataSet d = dblayer.getrecord();
            Student s = new Student();
            List<Student> L = new List<Student>();
            foreach (DataRow dr in d.Tables[0].Rows)
            {
                L.Add(new Student
                {
                    StudentID = Convert.ToInt32(dr["StudentID"]),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Address = dr["Address"].ToString()
                });
            }

            return Json(L, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StudentRecord()
        {
            List<SelectListItem> L = new List<SelectListItem>();
            {
                L.Add(new SelectListItem { Text = "Aradhana", Value = "1" });
                L.Add(new SelectListItem { Text = "sarath", Value = "2" });
                L.Add(new SelectListItem { Text = "karthi", Value = "3" });
                L.Add(new SelectListItem { Text = "Sarvesh", Value = "4" });
            }
            ViewBag.Location = L;
            return View();
        }
    }
}
