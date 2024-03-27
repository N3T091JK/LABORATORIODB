using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class GenderBL
    {
        private static GenderBL _instance;

        public static GenderBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GenderBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = GenderDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<Gender> SellecALL()
        {
            List<Gender> result;
            try
            {
                result = GenderDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Gender entity)
        {
            bool result = false;
            try
            {
                result = GenderDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Gender entity)
        {
            bool result = false;
            try
            {
                result = GenderDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
