using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class UserRoleBL
    {
        private static UserRoleBL _instance;

        public static UserRoleBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserRoleBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = UserRoleDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/
        public List<UserRole> SellecALL()
        {
            List<UserRole> result;
            try
            {
                result = UserRoleDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(UserRole entity)
        {
            bool result = false;
            try
            {
                result = UserRoleDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(UserRole entity)
        {
            bool result = false;
            try
            {
                result = UserRoleDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}

