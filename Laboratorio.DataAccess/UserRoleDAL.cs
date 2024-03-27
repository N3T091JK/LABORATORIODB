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
    public class UserRoleDAL
    {
        private static UserRoleDAL _instance;
        public static UserRoleDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserRoleDAL();
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
                var query = _context.UserRoles.FirstOrDefault(x => x.RolUsuarioId == id);
                if (query != null)
                {
                    _context.UserRoles.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<UserRole> SellectAll()
        {
            List<UserRole> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.UserRoles.Include(x => x.States).ToList();
                result = _context.UserRoles.Include(x => x.UserTypes).ToList();
            }
            return result;
        }
        public UserRole SellectById(int id)
        {
            UserRole result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.UserRoles
                    .FirstOrDefault(x => x.RolUsuarioId == id);
            }
            return result;
        }
        public bool Insert(UserRole entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.UserRoles.FirstOrDefault(x => x.RolUsuarioId.Equals(entity.RolUsuarioId));
                if (query == null)
                {
                    _context.UserRoles.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(UserRole entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.UserRoles.FirstOrDefault(x => x.RolUsuarioId.Equals(entity.RolUsuarioId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(UserRole entity)
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
