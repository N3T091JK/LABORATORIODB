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
    public class CategoryDAL
    {
        private static CategoryDAL _instance;
        public static CategoryDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoryDAL();
                }
                return _instance;
            }
        }
        public List<Category> SellectAll()
        {
            List<Category> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Categories.ToList();
            }
            return result;
        }
        /************delete*********************/
        public bool Delete(int id)
        {
            using (JTDataContext _context = new JTDataContext())
            {
                bool result = false;
                var query = _context.Categories.FirstOrDefault(x => x.CategoriaId == id);
                if (query != null)
                {
                    _context.Categories.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public Category SellectById(int id)
        {
            Category result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Categories
                    .FirstOrDefault(x => x.CategoriaId == id);
            }
            return result;
        }
        public bool Insert(Category entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Categories.FirstOrDefault(x => x.NombreCategoria.Equals(entity.NombreCategoria));
                if (query == null)
                {
                    _context.Categories.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Category entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Categories.FirstOrDefault(x => x.NombreCategoria.Equals(entity.NombreCategoria));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/

        public bool Update(Category entity)
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
