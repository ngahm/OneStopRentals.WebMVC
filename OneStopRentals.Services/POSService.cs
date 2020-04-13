using OneStopRentals.Data;
using OneStopRentals.Models.POS;
using OneStopRentals.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopRentals.Services
{
    public class POSService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context;
        public POSService(Guid userId)
        {
            _userId = userId;
            _context = new ApplicationDbContext();
        }


        public bool CreatePOS(POSCreate model)
        {
            POS entity = new POS()
            {
                CardCarrier = model.CardCarrier,
                CardNumber = model.CardNumber,
                CardDate = model.CardDate,
                CardCV = model.CardCV,
                AutoPay = model.AutoPay,
                PropertyID = model.PropertyID,             /*FK; requires space provided in data and model otherwise virtual default is nullable*/

            };

            _context.PointOfSale.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public List<POSListItem> GetAllPOS()
        {
            var entity = _context.PointOfSale.ToList();
            var allReceipts = entity.Select(e => new POSListItem
            {
                POSID = e.POSID,
                CardCarrier = e.CardCarrier,
                CardNumber = e.CardNumber,
                CardDate = e.CardDate,
                CardCV = e.CardCV,
                AutoPay = e.AutoPay,
                PropertyID = e.PropertyID                   /*FK*/
            }).ToList();
            return allReceipts;
        }


        public POSDetail GetPOSById(int id)
        {
            var entity = _context.PointOfSale.Find(id);
            if (entity == null)
            {
                return null;
            }
            var model = new POSDetail()
            {
                POSID = entity.POSID,
                CardCarrier = entity.CardCarrier,
                CardNumber = entity.CardNumber,
                CardDate = entity.CardDate,
                CardCV = entity.CardCV,
                AutoPay = entity.AutoPay
            };
            return model;
        }

        public bool UpdatePOS(POSEdit model)
        {
            var entity = _context.PointOfSale.SingleOrDefault(e => e.POSID == model.POSID);

            entity.CardCarrier = model.CardCarrier;
            entity.CardNumber = model.CardNumber;
            entity.CardDate = model.CardDate;
            entity.CardCV = model.CardCV;
            entity.AutoPay = model.AutoPay;
            entity.PropertyID = model.PropertyID;              /*FK*/

            return _context.SaveChanges() == 1;

        }

        public bool DeletePOS(int posId)
        {
            var entity = _context.PointOfSale.SingleOrDefault(e => e.POSID == posId);
            _context.PointOfSale.Remove(entity);
            return _context.SaveChanges() == 1;
        }
    }
}

