using RestauEntityFWDbAssign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauEntityFWDbAssign.Controllers
{
    public class HomeController : Controller
    {
        WFA3DotNetEntities db = new WFA3DotNetEntities();

        // GET: Home
        public ActionResult Index(string search="")
        {
            ViewBag.Search = search;

           var rest= db.RestTables.Where(r=>r.RestName.Contains(search)).ToList();
            return View(rest);
        }

        public ActionResult Details(int id)
        {
            var res = db.RestTables.Where(r => r.RestId == id).FirstOrDefault();
            return View(res);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestTable restTable)
        {
            db.RestTables.Add(restTable); 
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult Edit(int id)
        {
            var resUpdate = db.RestTables.Where(r => r.RestId == id).FirstOrDefault();

            return View(resUpdate);
        }

        [HttpPost]
        public ActionResult Edit(RestTable restTable)
        {
            var updatedRes = db.RestTables.Where(r => r.RestId == restTable.RestId).FirstOrDefault();
            updatedRes.RestName = restTable.RestName;
            updatedRes.Cusine= restTable.Cusine;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var delRest = db.RestTables.Where(e => e.RestId == id).FirstOrDefault();
            return View(delRest);
        }

        [HttpPost]
        public ActionResult Delete(int id,RestTable restTable)
        {
            var delRes = db.RestTables.Where(r => r.RestId == id).FirstOrDefault();

            db.RestTables.Remove(delRes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}