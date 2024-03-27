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
    public class PatientDAL
    {
        private static PatientDAL _instance;
        public static PatientDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PatientDAL();
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
                var query = _context.Patients.FirstOrDefault(x => x.PacienteId == id);
                if (query != null)
                {
                    _context.Patients.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<Patient> SellectAll()
        {
            List<Patient> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Patients.Include(x => x.States).ToList();
                result = _context.Patients.Include(x => x.Genders).ToList();
            }
            return result;
        }
        public Patient SellectById(int id)
        {
            Patient result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Patients
                    .FirstOrDefault(x => x.PacienteId == id);
            }
            return result;
        }
        public bool Insert(Patient entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Patients.FirstOrDefault(x => x.PacienteId.Equals(entity.PacienteId));
                if (query == null)
                {
                    _context.Patients.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Patient entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Patients.FirstOrDefault(x => x.PacienteId.Equals(entity.PacienteId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Patient entity)
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
