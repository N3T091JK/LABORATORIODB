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
    public class LogDAL
    {
        private static LogDAL _instance;
        public static LogDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogDAL();
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
                var query = _context.Logs.FirstOrDefault(x => x.LogId == id);
                if (query != null)
                {
                    _context.Logs.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }

        public List<Log> SellectAll()
        {
            List<Log> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Logs.Include(x => x.Users).ToList();
            }
            return result;
        }
        public Log SellectById(int id)
        {
            Log result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Logs
                    .FirstOrDefault(x => x.LogId == id);
            }
            return result;
        }
        public bool Insert(Log entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Logs.FirstOrDefault(x => x.LogId.Equals(entity.LogId));
                if (query == null)
                {
                    _context.Logs.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Log entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Logs.FirstOrDefault(x => x.LogId.Equals(entity.LogId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Log entity)
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
