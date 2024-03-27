using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class LaboratoryBL
    {
        private static LaboratoryBL _instance;

        public static LaboratoryBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LaboratoryBL();

                return _instance;
            }
        }
        /************delete********************/
        //public bool Delete(int id)
        //{
        //    bool result = false;
        //    try
        //    {
        //        result = LaboratoryDAL.Instance.Delete(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error. " + ex.Message);
        //    }
        //    return result;
        //}
        /********************************/

        public List<Laboratory> SellecALL()
        {
            List<Laboratory> result;
            try
            {
                result = LaboratoryDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Laboratory entity)
        {
            bool result = false;
            try
            {
                result = LaboratoryDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Laboratory entity)
        {
            bool result = false;
            try
            {
                result = LaboratoryDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
