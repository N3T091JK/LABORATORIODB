using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class TypeOfExamBL
    {
        private static TypeOfExamBL _instance;

        public static TypeOfExamBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TypeOfExamBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = TypeOfExamDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<TypeOfExam> SellecALL()
        {
            List<TypeOfExam> result;
            try
            {
                result = TypeOfExamDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(TypeOfExam entity)
        {
            bool result = false;
            try
            {
                result = TypeOfExamDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(TypeOfExam entity)
        {
            bool result = false;
            try
            {
                result = TypeOfExamDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
