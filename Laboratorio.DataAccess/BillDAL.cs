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
    public class BillDAL
    {
        private static BillDAL _instance;
        public static BillDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BillDAL();
                }
                return _instance;
            }
        }
        /******************delete********************/
        public bool Delete(int id)
        {
            using (JTDataContext _context = new JTDataContext())
            {
                bool result = false;
                var query = _context.Bills.FirstOrDefault(x => x.FacturaId == id);
                if (query != null)
                {
                    _context.Bills.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        /************************************/
        public List<Bill> SellectAll()
        {
            List<Bill> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Bills.Include(x => x.Employees).ToList();
                result = _context.Bills.Include(x => x.InvoiceDetails).ToList();
            }
            return result;
        }
        public Bill SellectById(int id)
        {
            Bill result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Bills
                    .FirstOrDefault(x => x.FacturaId == id);
            }
            return result;
        }
        public bool Insert(Bill entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Bills.FirstOrDefault(x => x.FacturaId.Equals(entity.FacturaId));
                if (query == null)
                {
                    _context.Bills.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /************************************
        public bool Update(Bill entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Bills.FirstOrDefault(x => x.FacturaId.Equals(entity.FacturaId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        */
        public bool Update(Bill entity)
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
