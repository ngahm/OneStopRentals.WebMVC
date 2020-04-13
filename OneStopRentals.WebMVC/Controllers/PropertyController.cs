using Microsoft.AspNet.Identity;
using OneStopRentals.Data;
using OneStopRentals.Models;
using OneStopRentals.Services;
using OneStopRentals.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneStopRentals.WebMVC.Controllers
{
    public class PropertyController : Controller
    {

        private PropertyService EstablishPropertyService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userID);
            return service;
        }



        // GET ALL: Property
        public ActionResult Index()
        {
            var service = EstablishPropertyService();
            var model = service.GetAllPropertyIterations();
            return View(model); 
        }


        // Property Create: Get View and POST
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = EstablishPropertyService();
            if (service.CreateProperty(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }




        //Property Edit: GetBY{ID} and PUT

        public ActionResult Edit(int id)
        {
            var service = EstablishPropertyService();
            var detail = service.GetPropertyById(id);
            var model =
                new PropertyEdit
                {
                    PropertyID=detail.PropertyID,
                    Bedroom = detail.Bedroom,
                    Bath = detail.Bath,
                    ListedPrice = detail.ListedPrice,
                    SquareFeet = detail.SquareFeet,
                    AvailableNow = detail.AvailableNow
                };
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PropertyEdit model)
        {
            var service = EstablishPropertyService();

            if (service.UpdateProperty(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }


        // Property Details: GETBy{ID} 
        public ActionResult Details(int id)
        {
            var svc = EstablishPropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }


        //Property Delete: GetBy{ID} and Delete
        public ActionResult Delete(int id)
        {
            var svc = EstablishPropertyService();
            var model = svc.GetPropertyById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePosting(int id)
        {
            var service = EstablishPropertyService();
            service.DeleteProperty(id);
            return RedirectToAction("Index");
        }


    }

}