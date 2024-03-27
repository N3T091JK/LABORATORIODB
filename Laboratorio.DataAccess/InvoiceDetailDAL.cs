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
    public class InvoiceDetailDAL
    {
        private static InvoiceDetailDAL _instance;
        public static InvoiceDetailDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InvoiceDetailDAL();
                }
                return _instance;
            }
        }  /************delete*********************/
        public bool Delete(int id)
        {
            using (JTDataContext _context = new JTDataContext())
            {
                bool result = false;
                var query = _context.InvoiceDetails.FirstOrDefault(x => x.DetalleFacturaId == id);
                if (query != null)
                {
                    _context.InvoiceDetails.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
        public List<InvoiceDetail> SellectAll()
        {
            List<InvoiceDetail> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.InvoiceDetails.Include(x => x.Patients).ToList();
                result = _context.InvoiceDetails.Include(x => x.Exams).ToList();
            }
            return result;
        }
        public InvoiceDetail SellectById(int id)
        {
            InvoiceDetail result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.InvoiceDetails
                    .FirstOrDefault(x => x.DetalleFacturaId == id);
            }
            return result;
        }
        public bool Insert(InvoiceDetail entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.InvoiceDetails.FirstOrDefault(x => x.DetalleFacturaId.Equals(entity.DetalleFacturaId));
                if (query == null)
                {
                    _context.InvoiceDetails.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        /*
        public bool Update(InvoiceDetail entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.InvoiceDetails.FirstOrDefault(x => x.DetalleFacturaId.Equals(entity.DetalleFacturaId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }*/
        public bool Update(InvoiceDetail entity)
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
