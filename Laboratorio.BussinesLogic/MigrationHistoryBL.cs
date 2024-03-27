using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class MigrationHistoryBL
    {
        private static MigrationHistoryBL _instance;

        public static MigrationHistoryBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MigrationHistoryBL();

                return _instance;
            }
        }

        public List<MigrationHistory> SellecALL()
        {
            List<MigrationHistory> result;
            try
            {
                result = MigrationHistoryDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(MigrationHistory entity)
        {
            bool result = false;
            try
            {
                result = MigrationHistoryDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(MigrationHistory entity)
        {
            bool result = false;
            try
            {
                result = MigrationHistoryDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
