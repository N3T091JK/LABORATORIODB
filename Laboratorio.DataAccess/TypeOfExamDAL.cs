using Laboratorio.Entities;
using Laboratorio.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.DataAccess
{
    public class TypeOfExamDAL
    {
        private static TypeOfExamDAL _instance;
        public static TypeOfExamDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TypeOfExamDAL();
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
                var query = _context.typeOfExams.FirstOrDefault(x => x.TipoDeExamenId == id);
                if (query != null)
                {
                    _context.typeOfExams.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<TypeOfExam> SellectAll()
        {
            List<TypeOfExam> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.typeOfExams.Include(x => x.States).ToList();
            }
            return result;
        }
        public TypeOfExam SellectById(int id)
        {
            TypeOfExam result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.typeOfExams
                    .FirstOrDefault(x => x.TipoDeExamenId == id);
            }
            return result;
        }
        public bool Insert(TypeOfExam entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.typeOfExams.FirstOrDefault(x => x.TipoDeExamenId.Equals(entity.TipoDeExamenId));
                if (query == null)
                {
                    _context.typeOfExams.Add(entity);
                    result = _context.SaveChanges() > 0;

                }
                return result;
            }
        }
        /*
        public bool Update(TypeOfExam entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.typeOfExams.FirstOrDefault(x => x.TipoDeExamenId.Equals(entity.TipoDeExamenId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;

                }
                return result;
            }
        }*/
        public bool Update(TypeOfExam entity)
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
