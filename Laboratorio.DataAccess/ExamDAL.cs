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
    public class ExamDAL
    {
        private static ExamDAL _instance;
        public static ExamDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExamDAL();
                }
                return _instance;
            }
        }
        /**************delete************************/
        public bool Delete(int id)
        {
            using (JTDataContext _context = new JTDataContext())
            {
                bool result = false;
                var query = _context.Exams.FirstOrDefault(x => x.ExamenId == id);
                if (query != null)
                {
                    _context.Exams.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        /************************************/
        public List<Exam> SellectAll()
        {
            List<Exam> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Exams.Include(x => x.States).ToList();
                result = _context.Exams.Include(x => x.TypeOfExams).ToList();
            }
            return result;
        }
        public Exam SellectById(int id)
        {
            Exam result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.Exams
                    .FirstOrDefault(x => x.ExamenId == id);
            }
            return result;
        }
        public bool Insert(Exam entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Exams.FirstOrDefault(x => x.ExamenId.Equals(entity.ExamenId));
                if (query == null)
                {
                    _context.Exams.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(Exam entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.Exams.FirstOrDefault(x => x.ExamenId.Equals(entity.ExamenId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(Exam entity)
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
