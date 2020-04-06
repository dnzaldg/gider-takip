using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEvernote.Entities;
using MyEvernote.WebApp.Models;
using MyEvernote.BusinessLayer;
using MyEvernote.WebApp.Filters;
using MyEvernote.BusinessLayer.Results;

namespace MyEvernote.WebApp.Controllers
{
    [Exc]
    public class SpendController : Controller
    {
        private SpendManager spendManager = new SpendManager();
        private CategoryManager categoryManager = new CategoryManager();
        private PeopleManager PeopleManager = new PeopleManager();

        [Auth]
        public ActionResult Index()
        {

            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "CategoryType");
            ViewBag.PeopleId = new SelectList(PeopleManager.List(), "Id", "Name");

            return View(spendManager.List());
        }
        

        [Auth]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "CategoryType");
            ViewBag.PeopleId = new SelectList(PeopleManager.List(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Spend spend)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            //ModelState.Remove("ModifiedUsername");
            ModelState.Remove("Result");

            if (ModelState.IsValid)
            {

                BusinessLayerResult<Spend> res = spendManager.Insert(spend);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(spend);
                }

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "CategoryType", spend.CategoryId);
            ViewBag.PeopleId = new SelectList(PeopleManager.List(), "Id", "Name", spend.PeopleId);
            return View(spend);

        }

        [AuthAdmin]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spend note = spendManager.Find(x => x.Id == id);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "CategoryType", note.CategoryId);
            ViewBag.PeopleId = new SelectList(PeopleManager.List(), "Id", "Name");
            return View(note);
        }

        [AuthAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Spend spend)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            //ModelState.Remove("ModifiedUsername");
            ModelState.Remove("Result");
            if (ModelState.IsValid)
            {
                Spend db_spend = spendManager.Find(x => x.Id == spend.Id);
                db_spend.Piece = spend.Piece;
                db_spend.Price = spend.Price;
                db_spend.Product = spend.Product;
                db_spend.Zaman = spend.Zaman;

                spendManager.Update(db_spend);

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "CategoryType", spend.CategoryId);

            ViewBag.PeopleId = new SelectList(PeopleManager.List(), "Id", "Name", spend.PeopleId);
            return View(spend);
        }

        [AuthAdmin]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spend spend = spendManager.Find(x => x.Id == id);
            if (spend == null)
            {
                return HttpNotFound();
            }
            return View(spend);
        }

        [AuthAdmin]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spend note = spendManager.Find(x => x.Id == id);
            spendManager.Delete(note);
            return RedirectToAction("Index");
        }


        //[HttpPost]
        //public ActionResult GetLiked(int[] ids)
        //{
        //    if(CurrentSession.User != null)
        //    {
        //        List<int> likedNoteIds = likedManager.List(
        //            x => x.LikedUser.Id == CurrentSession.User.Id && ids.Contains(x.Note.Id)).Select(
        //            x => x.Note.Id).ToList();

        //        return Json(new { result = likedNoteIds });
        //    }
        //    else
        //    {
        //        return Json(new { result = new List<int>() });
        //    }
        //}

        //[HttpPost]
        //public ActionResult SetLikeState(int noteid, bool liked)
        //{
        //    int res = 0;

        //    if(CurrentSession.User == null)
        //        return Json(new { hasError = true, errorMessage = "Beğenme işlemi için giriş yapmalısınız.", result = 0 });

        //    Liked like =
        //        likedManager.Find(x => x.Note.Id == noteid && x.LikedUser.Id == CurrentSession.User.Id);

        //    Spend note = spendManager.Find(x => x.Id == noteid);

        //    if (like != null && liked == false)
        //    {
        //        res = likedManager.Delete(like);
        //    }
        //    else if (like == null && liked == true)
        //    {
        //        res = likedManager.Insert(new Liked()
        //        {
        //            LikedUser = CurrentSession.User,
        //            Note = note
        //        });
        //    }

        //    if (res > 0)
        //    {
        //        if (liked)
        //        {
        //            note.LikeCount++;
        //        }
        //        else
        //        {
        //            note.LikeCount--;
        //        }

        //        res = noteManager.Update(note);

        //        return Json(new { hasError = false, errorMessage = string.Empty, result = note.LikeCount });
        //    }

        //    return Json(new { hasError = true, errorMessage = "Beğenme işlemi gerçekleştirilemedi.", result = note.LikeCount });
        //}


        //public ActionResult GetNoteText(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Spend note = noteManager.Find(x => x.Id == id);

        //    if (note == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return PartialView("_PartialNoteText", note);
        //}
    }
}
