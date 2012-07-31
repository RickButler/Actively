using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using actively.Models;

namespace actively.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlaceRepository PlaceRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public PlacesController()
            : this(new PlaceRepository())
        {
        }

        public PlacesController(IPlaceRepository PlaceRepository)
        {
            this.PlaceRepository = PlaceRepository;
        }

        //
        // GET: /Place/

        public ViewResult Index()
        {
            return View(PlaceRepository.All);
        }

        //
        // GET: /Place/Details/5

        public ViewResult Details(int id)
        {
            return View(PlaceRepository.Find(id));
        }

        //
        // GET: /Place/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Place/Create

        [HttpPost]
        public ActionResult Create(Place Place)
        {
            if (ModelState.IsValid)
            {
                PlaceRepository.InsertOrUpdate(Place);
                PlaceRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Place/Edit/5

        public ActionResult Edit(int id)
        {
            return View(PlaceRepository.Find(id));
        }

        //
        // POST: /Place/Edit/5

        [HttpPost]
        public ActionResult Edit(Place Place)
        {
            if (ModelState.IsValid)
            {
                PlaceRepository.InsertOrUpdate(Place);
                PlaceRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Place/Delete/5

        public ActionResult Delete(int id)
        {
            return View(PlaceRepository.Find(id));
        }

        //
        // POST: /Place/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceRepository.Delete(id);
            PlaceRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PlaceRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

