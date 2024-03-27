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
    public class GenderDAL
    {
        private static GenderDAL _instance;
        public static GenderDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GenderDAL();
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
                var query = _context.Genders.FirstOrDefault(x => x.GeneroId == id);
                if (query != null)
                {
                    _context.Genders.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<Gender> SellectAll()
        {
            List<Gender> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Genders.ToList();
            }
            return result;
        }
        public Gender SellectById(int id)
        {
            Gender result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Genders
                    .FirstOrDefault(x => x.GeneroId == id);
            }
            return result;
        }
        public bool Insert(Gender entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Genders.FirstOrDefault(x => x.NomGenero.Equals(entity.NomGenero));
                if (query == null)
                {
                    _context.Genders.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Gender entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Genders.FirstOrDefault(x => x.NomGenero.Equals(entity.NomGenero));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Gender entity)
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
