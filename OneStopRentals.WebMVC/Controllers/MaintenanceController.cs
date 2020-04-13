using Microsoft.AspNet.Identity;
using OneStopRentals.Models.Maintenance;
using OneStopRentals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OneStopRentals.WebMVC.Controllers
{
    public class MaintenanceController : Controller
    {

        private MaintenanceService EstablishMaintenanceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintenanceService(userId);
            return service;
        }




        // GET All: Maintenance
        public async Task<ActionResult> Index()
        {
            var service = EstablishMaintenanceService();
            var model = await service.GetAllMaintenanceAsync();
            return View(model);
        }


        //Maintenance Create:  GET View and POST
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MaintenanceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = EstablishMaintenanceService();
            if (await service.CreateMaintenanceAsync(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Request does not meet the maintenance model specifications");
            return View(model);
        }




        //Maintenance Edit: GetByID and PUT
        public async Task<ActionResult> Edit(int id)
        {
            var service = EstablishMaintenanceService();
            var detail = await service.GetMaintenanceByIdAsync(id);
            var model = new MaintenanceEdit
            {
                MaintenanceID = detail.MaintenanceID,
                Category = detail.Category,
                Description = detail.Description,
                Active = detail.Active,
                Permission = detail.Permission,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MaintenanceEdit model)
        {
            var service = EstablishMaintenanceService();
            if (await service.EditMaintenanceAsync(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Request does not meet the maintenance model specifications");
            return View(model);
        }


        //Maintenance Details : GetBy{ID} 
        public async Task<ActionResult> Details(int id)
        {
            var service = EstablishMaintenanceService();
            var model = await service.GetMaintenanceByIdAsync(id);
            return View(model);
        }



        //Maintenance Delete: GetBy{ID} and Delete

        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = EstablishMaintenanceService();
            var model = await service.GetMaintenanceByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePosting(int id)
        {
            var service = EstablishMaintenanceService();
            await service.DeleteMaintenanceAsync(id);
            return RedirectToAction("Index");
        }




    }

}