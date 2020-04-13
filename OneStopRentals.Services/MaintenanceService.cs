using OneStopRentals.Data;
using OneStopRentals.Models;
using OneStopRentals.Models.Maintenance;
using OneStopRentals.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Services
{
    public class MaintenanceService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context;
        public MaintenanceService(Guid userId)
        {
            _userId = userId;
            _context = new ApplicationDbContext();
        }

        public async Task<bool> CreateMaintenanceAsync(MaintenanceCreate model)
        {
            var entity =
                new Maintenance()
                {
                    Category = model.Category,
                    Description = model.Description,
                    Active = model.Active,
                    Permission = model.Permission,
                    PropertyID = model.PropertyID,                    /*FK*/
                };
            _context.Maint.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<MaintenanceListItem>> GetAllMaintenanceAsync()
        {
            var entityList = await _context.Maint.ToListAsync();
            var maintList = entityList

                .Select(
                    e =>
                        new MaintenanceListItem
                        {
                            MaintenanceID= e.MaintenanceID,
                            Category = e.Category,
                            Description = e.Description,
                            Active = e.Active,
                            Permission = e.Permission,
                            PropertyID = e.PropertyID,                 /*FK*/
                        }
                        
                );
            return maintList.ToList();
        }

        public async Task<MaintenanceDetail> GetMaintenanceByIdAsync(int id)
        {
            var entity = await _context.Maint.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            var model = new MaintenanceDetail()
            {
                Category = entity.Category,
                Description = entity.Description,
                Active = entity.Active,
                Permission = entity.Permission,
            };
            return model;
        }

        public async Task<bool> EditMaintenanceAsync(MaintenanceEdit model)
        {
            var entity = await
                    _context
                    .Maint
                    .SingleOrDefaultAsync(e => e.MaintenanceID == model.MaintenanceID);

            entity.Category = model.Category;
            entity.Description = model.Description;
            entity.Active = model.Active;
            entity.Permission = model.Permission;
            entity.PropertyID = model.PropertyID;                    /*FK*/

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteMaintenanceAsync(int id)
        {
            var entity = await
                    _context
                    .Maint
                    .SingleOrDefaultAsync(e => e.MaintenanceID == id);
            _context.Maint.Remove(entity);
            return await _context.SaveChangesAsync() == 1;

        }
    }
}
