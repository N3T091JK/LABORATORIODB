using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class PurchaseDetailBL
    {
        private static PurchaseDetailBL _instance;

        public static PurchaseDetailBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PurchaseDetailBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = PurchaseDetailDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<PurchaseDetail> SellecALL()
        {
            List<PurchaseDetail> result;
            try
            {
                result = PurchaseDetailDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(PurchaseDetail entity)
        {
            bool result = false;
            try
            {
                result = PurchaseDetailDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(PurchaseDetail entity)
        {
            bool result = false;
            try
            {
                result = PurchaseDetailDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
