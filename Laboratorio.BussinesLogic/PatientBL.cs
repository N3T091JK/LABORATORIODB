using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
        public class PatientBL
    {
        private static PatientBL _instance;

        public static PatientBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PatientBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = PatientDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<Patient> SellecALL()
        {
            List<Patient> result;
            try
            {
                result = PatientDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Patient entity)
        {
            bool result = false;
            try
            {
                result = PatientDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Patient entity)
        {
            bool result = false;
            try
            {
                result = PatientDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
