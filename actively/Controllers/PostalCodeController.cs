using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using actively.Models;

namespace actively.Controllers
{
    public class PostalCodeController : Controller
    {
        private readonly IPostalCodeRepository PostalCodeRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public PostalCodeController()
            : this(new PostalCodeRepository())
        {
        }

        public PostalCodeController(IPostalCodeRepository PostalCodeRepository)
        {
            this.PostalCodeRepository = PostalCodeRepository;
        }

        //
        // GET: /PostalCode/

        public ViewResult Index()
        {
            return View(PostalCodeRepository.All);
        }

        //
        // GET: /PostalCode/Details/5

        public ViewResult Details(string id)
        {
            return View(PostalCodeRepository.All.FirstOrDefault(pCode => pCode.Postal.StartsWith(id)));
        }

        //
        // GET: /PostalCode/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PostalCode/Create

        [HttpPost]
        public ActionResult Create(PostalCode PostalCode)
        {
            if (ModelState.IsValid)
            {
                PostalCodeRepository.InsertOrUpdate(PostalCode);
                PostalCodeRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /PostalCode/Edit/5

        public ActionResult Edit(int id)
        {
            return View(PostalCodeRepository.Find(id));
        }

        //
        // POST: /PostalCode/Edit/5

        [HttpPost]
        public ActionResult Edit(PostalCode PostalCode)
        {
            if (ModelState.IsValid)
            {
                PostalCodeRepository.InsertOrUpdate(PostalCode);
                PostalCodeRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /PostalCode/Delete/5

        public ActionResult Delete(int id)
        {
            return View(PostalCodeRepository.Find(id));
        }

        //
        // POST: /PostalCode/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PostalCodeRepository.Delete(id);
            PostalCodeRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PostalCodeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

