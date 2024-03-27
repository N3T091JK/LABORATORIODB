using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class EmployeeBL
    {
       
        

            private static EmployeeBL _instance;

            public static EmployeeBL Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new EmployeeBL();

                    return _instance;
                }
            }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = EmployeeDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<Employee> SellecALL()
            {
                List<Employee> result;
                try
                {
                    result = EmployeeDAL.Instance.SellectAll();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                return result;
            }

            public bool Insert(Employee entity)
            {
                bool result = false;
                try
                {
                    result = EmployeeDAL.Instance.Insert(entity);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                return result;
            }

            public bool Update(Employee entity)
            {
                bool result = false;
                try
                {
                    result = EmployeeDAL.Instance.Update(entity);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error. " + ex.Message);
                }
                return result;
            }

        }
    }

