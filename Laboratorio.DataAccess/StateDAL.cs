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
    public class StateDAL
    {
        private static StateDAL _instance;
        public static StateDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StateDAL();
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
                var query = _context.States.FirstOrDefault(x => x.EstadoId == id);
                if (query != null)
                {
                    _context.States.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<State> SellectAll()
        {
            List<State> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.States.ToList();
            }
            return result;
        }
        public State SellectById(int id)
        {
            State result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.States
                    .FirstOrDefault(x => x.EstadoId == id);
            }
            return result;
        }
        public bool Insert(State entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.States.FirstOrDefault(x => x.EstadoId.Equals(entity.EstadoId));
                if (query == null)
                {
                    _context.States.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(State entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.States.FirstOrDefault(x => x.EstadoId.Equals(entity.EstadoId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(State entity)
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
