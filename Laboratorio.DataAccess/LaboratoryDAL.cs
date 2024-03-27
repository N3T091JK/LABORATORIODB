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
    public class LaboratoryDAL
    {
        private static LaboratoryDAL _instance;
        public static LaboratoryDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LaboratoryDAL();
                }
                return _instance;
            }
        }

        public List<Laboratory> SellectAll()
        {
            List<Laboratory> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.laboratories.ToList();
            }
            return result;
        }
        public Laboratory SellectById(int id)
        {
            Laboratory result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.laboratories
                    .FirstOrDefault(x => x.NumRegistro == id);
            }
            return result;
        }
        public bool Insert(Laboratory entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.laboratories.FirstOrDefault(x => x.NumRegistro.Equals(entity.NumRegistro));
                if (query == null)
                {
                    _context.laboratories.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Laboratory entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.laboratories.FirstOrDefault(x => x.NumRegistro.Equals(entity.NumRegistro));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Laboratory entity)
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
