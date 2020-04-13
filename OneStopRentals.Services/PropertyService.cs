using OneStopRentals.Data;
using OneStopRentals.Models;
using OneStopRentals.Models.Maintenance;
using OneStopRentals.Models.POS;
using OneStopRentals.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Services
{
    public class PropertyService
    {
        private readonly Guid _userId;
        //private readonly ApplicationDbContext _context;
        public PropertyService(Guid userId)
        {
            _userId = userId;
            //_context = new ApplicationDbContext();
        }


        public bool CreateProperty(PropertyCreate model)
        {
            var entity =
                new Property()
                {
                    //UserId=_userId.ToString(),
                    PropertyID=model.PropertyID,
                    Bedroom = model.Bedroom,
                    Bath = model.Bath,
                    ListedPrice = model.ListedPrice,
                    SquareFeet = model.SquareFeet,
                    AvailableNow = model.AvailableNow

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Prop.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PropertyListItem> GetAllPropertyIterations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Prop
                        //.Where(e=> e.UserId == _userId.ToString())      /*this part will refine search for user specific users*/
                        .Select(e => new PropertyListItem
                        {
                            PropertyID = e.PropertyID,
                            Bedroom = e.Bedroom,
                            Bath = e.Bath,
                            ListedPrice = e.ListedPrice,
                            SquareFeet = e.SquareFeet,
                            AvailableNow = e.AvailableNow

                        }
                        );

                return query.ToArray();
            }
        }


        public PropertyDetail GetPropertyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prop
                        .SingleOrDefault(e => e.PropertyID == id);
                //instantiate a new list of MaintenanceListItems
                //foreach through entity.Tickets and create a new Maintenance ListItem for each Maintenance item
                //add that new MaintenanceListItem to our new list of MaintenanceListItems

                return
                    new PropertyDetail
                    {
                        PropertyID = entity.PropertyID,
                        Bedroom = entity.Bedroom,
                        Bath = entity.Bath,
                        ListedPrice = entity.ListedPrice,
                        SquareFeet = entity.SquareFeet,
                        AvailableNow = entity.AvailableNow,
                        // replace entity.Tickets with the variable name for our new list of MaintenanceListItems from above
                        Tickets = WorkOrderListIteration(entity.MyTickets),
                        Receipts = entity.MyReceipts.Select(abc => new POSListItem
                        {
                            POSID = abc.POSID,
                            CardCarrier = abc.CardCarrier,
                            CardNumber = abc.CardNumber,
                            CardDate = abc.CardDate,
                            CardCV = abc.CardCV,
                            AutoPay = abc.AutoPay,
                        }).ToList()
                    };
            }
        }

        public bool UpdateProperty(PropertyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prop
                        //.SingleOrDefault(e => e.PropertyID == model.PropertyID && e.UserId==_userId.ToString());
                        .SingleOrDefault(e => e.PropertyID == model.PropertyID);

                entity.Bedroom = model.Bedroom;
                entity.Bath = model.Bath;
                entity.ListedPrice = model.ListedPrice;
                entity.SquareFeet = model.SquareFeet;
                entity.AvailableNow = model.AvailableNow;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteProperty(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prop
                        //.Single(e=>e.PropertyID == id && e.UserId == _userId.ToString());
                        .SingleOrDefault(e => e.PropertyID == id);

                ctx.Prop.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }




        // the parameter for this method takes in the Property's property MyTickets that is of type ICollection<Maintenance>
        // this method will need to return the same type that the PropertyDetails property for Tickets is; which is a List<MaintenanceListItem>
        private List<MaintenanceListItem> WorkOrderListIteration(ICollection<Maintenance> allOrders)
        {
            var newList = new List<MaintenanceListItem>();
            foreach (var maintenance in allOrders)
            {
            // instantiate a new MaintenanceListItem, and set the properties using "Object Initilization Syntax"
                var maintenanceListItem = new MaintenanceListItem()
                {
                    MaintenanceID = maintenance.MaintenanceID,
                    Category = maintenance.Category,
                    Description = maintenance.Description,
                    Active = maintenance.Active,
                    Permission = maintenance.Permission,
                };
                newList.Add(maintenanceListItem);
            }
            return newList;

        }
    }
}











