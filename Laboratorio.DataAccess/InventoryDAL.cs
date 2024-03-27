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
    public class InventoryDAL
    {
        private static InventoryDAL _instance;
        public static InventoryDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventoryDAL();
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
                var query = _context.Inventorys.FirstOrDefault(x => x.InventoryId == id);
                if (query != null)
                {
                    _context.Inventorys.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<Inventory> SellectAll()
        {
            List<Inventory> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Inventorys.Include(x => x.PurchaseDetails).ToList();
                result = _context.Inventorys.Include(x => x.ProductoId).ToList();
            }
            return result;
        }
        public Inventory SellectById(int id)
        {
            Inventory result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Inventorys
                    .FirstOrDefault(x => x.InventoryId == id);
            }
            return result;
        }
        public bool Insert(Inventory entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Inventorys.FirstOrDefault(x => x.InventoryId.Equals(entity.InventoryId));
                if (query == null)
                {
                    _context.Inventorys.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Inventory entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Inventorys.FirstOrDefault(x => x.InventoryId.Equals(entity.InventoryId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Inventory entity)
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
