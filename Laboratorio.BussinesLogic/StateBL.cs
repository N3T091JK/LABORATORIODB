using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class StateBL
    {
        private static StateBL _instance;

        public static StateBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StateBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = StateDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<State> SellecALL()
        {
            List<State> result;
            try
            {
                result = StateDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(State entity)
        {
            bool result = false;
            try
            {
                result = StateDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(State entity)
        {
            bool result = false;
            try
            {
                result = StateDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
