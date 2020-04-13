using Microsoft.AspNet.Identity;
using OneStopRentals.Models.POS;
using OneStopRentals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneStopRentals.WebMVC.Controllers
{
    public class POSController : Controller
    {
        private POSService EstablishPOSService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new POSService(userID);
            return service;
        }



        // GET ALL: POS
        public ActionResult Index()
        {
            var service = EstablishPOSService();
            var model = service.GetAllPOS();
            return View(model);
        }


        // POS Create: GET View and POST
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POSCreate model)
        {
            //model.PropertyID = 1;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = EstablishPOSService();
            if (service.CreatePOS(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "POS receipt could not be created.");
            return View(model);
        }




        //POS Edit: GetByID and PUT

        public ActionResult Edit(int id)
        {
            var service = EstablishPOSService();
            var detail = service.GetPOSById(id);
            var model =
                new POSEdit
                {
                    POSID = detail.POSID,
                    CardCarrier = detail.CardCarrier,
                    CardNumber = detail.CardNumber,
                    CardDate = detail.CardDate,
                    CardCV = detail.CardCV,
                    AutoPay=detail.AutoPay,
                    
                };
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POSEdit model)
        {
            var service = EstablishPOSService();

            if (service.UpdatePOS(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your POS receipt could not be updated.");
            return View(model);
        }


        // POS Details : GetByID
        public ActionResult Details(int id)
        {
            var svc = EstablishPOSService();
            var model = svc.GetPOSById(id);

            return View(model);
        }


        //POS Delete: GetByID and Delete
        public ActionResult Delete(int id)
        {
            var svc = EstablishPOSService();
            var model = svc.GetPOSById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePosting(int id)
        {
            var service = EstablishPOSService();
            service.DeletePOS(id);
            return RedirectToAction("Index");
        }

    }

}