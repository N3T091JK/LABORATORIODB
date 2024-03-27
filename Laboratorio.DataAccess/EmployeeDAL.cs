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
    public class EmployeeDAL
    {
        private static EmployeeDAL _instance;
        public static EmployeeDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeDAL();
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
                var query = _context.Employees.FirstOrDefault(x => x.EmpleadoId == id);
                if (query != null)
                {
                    _context.Employees.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<Employee> SellectAll()
        {
            List<Employee> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Employees.Include(x => x.States).ToList();
                result = _context.Employees.Include(x => x.Genders).ToList();
            }
            return result;
        }
        public Employee SellectById(int id)
        {
            Employee result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Employees
                    .FirstOrDefault(x => x.EmpleadoId == id);
            }
            return result;
        }
        public bool Insert(Employee entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Employees.FirstOrDefault(x => x.EmpleadoId.Equals(entity.EmpleadoId));
                if (query == null)
                {
                    _context.Employees.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Employee entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Employees.FirstOrDefault(x => x.EmpleadoId.Equals(entity.EmpleadoId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Employee entity)
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
