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
    public class MigrationHistoryDAL
    {
        private static MigrationHistoryDAL _instance;
        public static MigrationHistoryDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MigrationHistoryDAL();
                }
                return _instance;
            }
        }
        public List<MigrationHistory> SellectAll()
        {
            List<MigrationHistory> result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.MigrationHistories.ToList();
            }
            return result;
        }
        public MigrationHistory SellectById(int id)
        {
            MigrationHistory result = null;
            using (JTDataContext _context = new JTDataContext())
            {
                result = _context.MigrationHistories
                    .FirstOrDefault(x => x.HistorialMigracionId == id);
            }
            return result;
        }
        public bool Insert(MigrationHistory entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.MigrationHistories.FirstOrDefault(x => x.HistorialMigracionId.Equals(entity.HistorialMigracionId));
                if (query == null)
                {
                    _context.MigrationHistories.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
        public bool Update(MigrationHistory entity)
        {
            bool result = false;
            using (JTDataContext _context = new JTDataContext())
            {
                var query = _context.MigrationHistories.FirstOrDefault(x => x.HistorialMigracionId.Equals(entity.HistorialMigracionId));
                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }
        }
    }
}
