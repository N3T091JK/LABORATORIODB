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
    public class ProductDAL
    {
        private static ProductDAL _instance;
        public static ProductDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductDAL();
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
                var query = _context.Products.FirstOrDefault(x => x.ProductoId == id);
                if (query != null)
                {
                    _context.Products.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<Product> SellectAll()
        {
            List<Product> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Products.Include(x => x.States).ToList();
            }
            return result;
        }
        public Product SellectById(int id)
        {
            Product result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Products
                    .FirstOrDefault(x => x.ProductoId == id);
            }
            return result;
        }
        public bool Insert(Product entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Products.FirstOrDefault(x => x.ProductoId.Equals(entity.ProductoId));
                if (query == null)
                {
                    _context.Products.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        public bool Update(Product entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                result = _context.SaveChanges() > 0;
            }
            return result;
        }
        /*
        public bool Update(Product entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Products.FirstOrDefault(x => x.ProductoId.Equals(entity.ProductoId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
    }
}
