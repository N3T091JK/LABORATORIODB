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
    public class PromotionDAL
    {
        private static PromotionDAL _instance;
        public static PromotionDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PromotionDAL();
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
                var query = _context.Promotions.FirstOrDefault(x => x.PromocionId == id);
                if (query != null)
                {
                    _context.Promotions.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<Promotion> SellectAll()
        {
            List<Promotion> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Promotions.Include(x => x.States).ToList();
                result = _context.Promotions.Include(x => x.TypeOfExams).ToList();
            }
            return result;
        }
        public Promotion SellectById(int id)
        {
            Promotion result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Promotions
                    .FirstOrDefault(x => x.PromocionId == id);
            }
            return result;
        }
        public bool Insert(Promotion entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Promotions.FirstOrDefault(x => x.PromocionId.Equals(entity.PromocionId));
                if (query == null)
                {
                    _context.Promotions.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Promotion entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Promotions.FirstOrDefault(x => x.PromocionId.Equals(entity.PromocionId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Promotion entity)
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
