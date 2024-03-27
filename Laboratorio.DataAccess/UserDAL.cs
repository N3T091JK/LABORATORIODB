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
    public class UserDAL
    {
        private static UserDAL _instance;
        public static UserDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDAL();
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
                var query = _context.Users.FirstOrDefault(x => x.UsuarioId == id);
                if (query != null)
                {
                    _context.Users.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<User> SellectAll()
        {
            List<User> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Users.Include(x => x.States).ToList();
                result = _context.Users.Include(x => x.UserTypes).ToList();
                result = _context.Users.Include(x => x.Employees).ToList();
            }
            return result;
        }
        public User SellectById(int id)
        {
            User result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Users
                    .FirstOrDefault(x => x.UsuarioId == id);
            }
            return result;
        }
        public bool Insert(User entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Users.FirstOrDefault(x => x.UsuarioId.Equals(entity.UsuarioId));
                if (query == null)
                {
                    _context.Users.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(User entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Users.FirstOrDefault(x => x.UsuarioId.Equals(entity.UsuarioId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(User entity)
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
