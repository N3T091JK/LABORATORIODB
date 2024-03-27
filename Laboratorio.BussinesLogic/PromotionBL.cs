using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class PromotionBL
    {
        private static PromotionBL _instance;

        public static PromotionBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PromotionBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = PromotionDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<Promotion> SellecALL()
        {
            List<Promotion> result;
            try
            {
                result = PromotionDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Promotion entity)
        {
            bool result = false;
            try
            {
                result = PromotionDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Promotion entity)
        {
            bool result = false;
            try
            {
                result = PromotionDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
