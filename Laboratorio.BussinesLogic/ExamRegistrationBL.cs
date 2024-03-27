using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class ExamRegistrationBL
    {
        private static ExamRegistrationBL _instance;

        public static ExamRegistrationBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ExamRegistrationBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = ExamRegistrationDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<ExamRegistration> SellecALL()
        {
            List<ExamRegistration> result;
            try
            {
                result = ExamRegistrationDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(ExamRegistration entity)
        {
            bool result = false;
            try
            {
                result = ExamRegistrationDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(ExamRegistration entity)
        {
            bool result = false;
            try
            {
                result = ExamRegistrationDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}

