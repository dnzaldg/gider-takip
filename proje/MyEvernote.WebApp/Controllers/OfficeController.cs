 using MyEvernote.BusinessLayer;
using MyEvernote.BusinessLayer.Results;
using MyEvernote.Entities;
using MyEvernote.WebApp.Filters;
using MyEvernote.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace MyEvernote.WebApp.Controllers
    {
        [Exc]
        public class OfficeController : Controller
        {
            OfficeManager officeManager = new OfficeManager();
            PeopleManager peopleManager = new PeopleManager();
            public ActionResult Index()
            {
                return View(officeManager.List());
            }


            public ActionResult Create()
            {
                return View();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
        public ActionResult Create(Office office)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            //ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {

                BusinessLayerResult<Office> res = officeManager.Insert(office);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(office);
                }

                return RedirectToAction("Index");
            }

            return View(office);
        }


        public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Office office = officeManager.Find(x => x.Id == id.Value);

                if (office == null)
                {
                    return HttpNotFound();
                }

                return View(office);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Office office)
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("ModifiedOn");
                //ModelState.Remove("ModifiedUsername");

                if (ModelState.IsValid)
                {
                    Office db_office = officeManager.Find(x => x.Id == office.Id);
                    db_office.Address = office.Address;
                    db_office.OfficeName = office.OfficeName;
                    db_office.FirmaEmail = office.FirmaEmail;
                    db_office.FirmaPhone = office.FirmaPhone;
                    db_office.Website = office.Website;

                    officeManager.Update(office);

                    return RedirectToAction("Index");
                }
                return View(office);
            }


            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Office office = officeManager.Find(x => x.Id == id.Value);

                if (office == null)
                {
                    return HttpNotFound();
                }

                return View(office);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Office office = officeManager.Find(x => x.Id == id);
                officeManager.Delete(office);

                return RedirectToAction("Index");
            }
        }
    }
