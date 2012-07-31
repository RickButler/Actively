using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using actively.Models;

namespace actively.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationRepository locationRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public LocationsController()
            : this(new LocationRepository())
        {
        }

        public LocationsController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        //
        // GET: /Location/

        public ViewResult Index()
        {
            return View(locationRepository.All);
        }

        //
        // GET: /Location/Details/5

        public ViewResult Details(int id)
        {
            return View(locationRepository.Find(id));
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                locationRepository.InsertOrUpdate(location);
                locationRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Location/Edit/5

        public ActionResult Edit(int id)
        {
            return View(locationRepository.Find(id));
        }

        //
        // POST: /Location/Edit/5

        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                locationRepository.InsertOrUpdate(location);
                locationRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Location/Delete/5

        public ActionResult Delete(int id)
        {
            return View(locationRepository.Find(id));
        }

        //
        // POST: /Location/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            locationRepository.Delete(id);
            locationRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                locationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

