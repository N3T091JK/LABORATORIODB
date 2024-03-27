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
    public class ExamRegistrationDAL
    {
        private static ExamRegistrationDAL _instance;
        public static ExamRegistrationDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExamRegistrationDAL();
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
                var query = _context.ExamRegistrations.FirstOrDefault(x => x.RegistroExamenId == id);
                if (query != null)
                {
                    _context.ExamRegistrations.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<ExamRegistration> SellectAll()
        {
            List<ExamRegistration> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.ExamRegistrations.Include(x => x.States).ToList();
                result = _context.ExamRegistrations.Include(x => x.TypeOfExams).ToList();
                result = _context.ExamRegistrations.Include(x => x.Patients).ToList();
            }
            return result;
        }
        public ExamRegistration SellectById(int id)
        {
            ExamRegistration result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.ExamRegistrations
                    .FirstOrDefault(x => x.RegistroExamenId == id);
            }
            return result;
        }
        public bool Insert(ExamRegistration entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.ExamRegistrations.FirstOrDefault(x => x.RegistroExamenId.Equals(entity.RegistroExamenId));
                if (query == null)
                {
                    _context.ExamRegistrations.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(ExamRegistration entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.ExamRegistrations.FirstOrDefault(x => x.RegistroExamenId.Equals(entity.RegistroExamenId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(ExamRegistration entity)
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
