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
    public class UserTypeDAL
    {
        private static UserTypeDAL _instance;
        public static UserTypeDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserTypeDAL();
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
                var query = _context.UserTypes.FirstOrDefault(x => x.TipoUsuarioId == id);
                if (query != null)
                {
                    _context.UserTypes.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<UserType> SellectAll()
        {
            List<UserType> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.UserTypes.Include(x => x.States).ToList();
            }
            return result;
        }
        public UserType SellectById(int id)
        {
            UserType result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.UserTypes
                    .FirstOrDefault(x => x.TipoUsuarioId == id);
            }
            return result;
        }
        public bool Insert(UserType entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.UserTypes.FirstOrDefault(x => x.TipoUsuarioId.Equals(entity.TipoUsuarioId));
                if (query == null)
                {
                    _context.UserTypes.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(UserType entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.UserTypes.FirstOrDefault(x => x.TipoUsuarioId.Equals(entity.TipoUsuarioId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(UserType entity)
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
