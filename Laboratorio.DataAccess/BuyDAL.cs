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
    public class BuyDAL
    {
        private static BuyDAL _instance;
        public static BuyDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BuyDAL();
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
                var query = _context.Buys.FirstOrDefault(x => x.CompraId == id);
                if (query != null)
                {
                    _context.Buys.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        /**************/
        public List<Buy> SellectAll()
        {
            List<Buy> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Buys.Include(x => x.PurchaseDetails).ToList();
            }
            return result;
        }
        public Buy SellectById(int id)
        {
            Buy result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Buys
                    .FirstOrDefault(x => x.CompraId == id);
            }
            return result;
        }
        public bool Insert(Buy entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Buys.FirstOrDefault(x => x.CompraId.Equals(entity.CompraId));
                if (query == null)
                {
                    _context.Buys.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Buy entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Buys.FirstOrDefault(x => x.CompraId.Equals(entity.CompraId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Buy entity)
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
