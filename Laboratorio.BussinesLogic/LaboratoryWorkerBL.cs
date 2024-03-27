using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class LaboratoryWorkerBL
    {
        private static LaboratoryWorkerBL _instance;

        public static LaboratoryWorkerBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LaboratoryWorkerBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = LaboratoryWorkerDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<LaboratoryWorker> SellecALL()
        {
            List<LaboratoryWorker> result;
            try
            {
                result = LaboratoryWorkerDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(LaboratoryWorker entity)
        {
            bool result = false;
            try
            {
                result = LaboratoryWorkerDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(LaboratoryWorker entity)
        {
            bool result = false;
            try
            {
                result = LaboratoryWorkerDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
