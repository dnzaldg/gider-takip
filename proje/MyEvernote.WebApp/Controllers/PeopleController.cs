using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEvernote.Entities;
using MyEvernote.BusinessLayer;
using MyEvernote.BusinessLayer.Results;
using MyEvernote.WebApp.Filters;

namespace MyEvernote.WebApp.Controllers
{
    [Auth]
    [AuthAdmin]
    [Exc]
    public class PeopleController : Controller
    {
        private PeopleManager peopleManager = new PeopleManager();
        private OfficeManager officeManager = new OfficeManager();

        public ActionResult Index()
        {
            ViewBag.OfficeId = new SelectList(officeManager.List(), "Id", "OfficeName");
            return View(peopleManager.List());
        }

     
        public ActionResult Create()
        {
            ViewBag.OfficeId = new SelectList(officeManager.List(), "Id", "OfficeName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(People people)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            //ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<People> res = peopleManager.Insert(people);


                return RedirectToAction("Index");
            }
            ViewBag.OfficeId = new SelectList(officeManager.List(), "Id", "OfficeName", people.OfficeId);

            return View(people);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            People evernoteUser = peopleManager.Find(x => x.Id == id.Value);

            if (evernoteUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeId = new SelectList(officeManager.List(), "Id", "OfficeName");

            return View(evernoteUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(People people)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            //ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<People> res = peopleManager.Update(people);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(people);
                }

                return RedirectToAction("Index");
            }
            ViewBag.OfficeId = new SelectList(officeManager.List(), "Id", "OfficeName", people.OfficeId);
            return View(people);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People evernoteUser = peopleManager.Find(x => x.Id == id.Value);

            if (evernoteUser == null)
            {
                return HttpNotFound();
            }

            return View(evernoteUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            People people = peopleManager.Find(x => x.Id == id);
            peopleManager.Delete(people);

            return RedirectToAction("Index");
        }
    }
}
