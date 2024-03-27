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
    public class LaboratoryWorkerDAL
    {
        private static LaboratoryWorkerDAL _instance;
        public static LaboratoryWorkerDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LaboratoryWorkerDAL();
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
                var query = _context.LaboratoryWorkers.FirstOrDefault(x => x.LaboratoristaId == id);
                if (query != null)
                {
                    _context.LaboratoryWorkers.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<LaboratoryWorker> SellectAll()
        {
            List<LaboratoryWorker> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.LaboratoryWorkers.Include(x => x.Employees).ToList();
            }
            return result;
        }
        public LaboratoryWorker SellectById(int id)
        {
            LaboratoryWorker result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.LaboratoryWorkers
                    .FirstOrDefault(x => x.LaboratoristaId == id);
            }
            return result;
        }
        public bool Insert(LaboratoryWorker entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.LaboratoryWorkers.FirstOrDefault(x => x.LaboratoristaId.Equals(entity.LaboratoristaId));
                if (query == null)
                {
                    _context.LaboratoryWorkers.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        public bool Update(LaboratoryWorker entity)
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
        public bool Update(LaboratoryWorker entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.LaboratoryWorkers.FirstOrDefault(x => x.LaboratoristaId.Equals(entity.LaboratoristaId));
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
