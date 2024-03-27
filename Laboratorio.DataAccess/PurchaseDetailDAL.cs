using Laboratorio.Entities.AppContext;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.DataAccess
{
    public class PurchaseDetailDAL 
    {
        private static PurchaseDetailDAL _instance;
        public static PurchaseDetailDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PurchaseDetailDAL();
                }
                return _instance;
            }
        }
        /************delete*********************/
        public bool Delete(int id)
        {
            using (JTDataContext _context = new JTDataContext())
            {
                bool result = false;
                var query = _context.purchaseDetails.FirstOrDefault(x => x.CompraDetalleId == id);
                if (query != null)
                {
                    _context.purchaseDetails.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<PurchaseDetail> SellectAll()
        {
            List<PurchaseDetail> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.purchaseDetails.Include(x => x.Categories).ToList();
                result = _context.purchaseDetails.Include(x => x.Products).ToList();
            }
            return result;
        }
        public PurchaseDetail SellectById(int id)
        {
            PurchaseDetail result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.purchaseDetails
                    .FirstOrDefault(x => x.CompraDetalleId == id);
            }
            return result;
        }
        public bool Insert(PurchaseDetail entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.purchaseDetails.FirstOrDefault(x => x.CompraDetalleId.Equals(entity.CompraDetalleId));
                if (query == null)
                {
                    _context.purchaseDetails.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(PurchaseDetail entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.purchaseDetails.FirstOrDefault(x => x.CompraDetalleId.Equals(entity.CompraDetalleId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(PurchaseDetail entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                result = _context.SaveChanges() > 0;
            }
            return result;
        }
    }
}
