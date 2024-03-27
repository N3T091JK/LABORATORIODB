using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class InventoryBL
    {
        private static InventoryBL _instance;

        public static InventoryBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InventoryBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = InventoryDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<Inventory> SellecALL()
        {
            List<Inventory> result;
            try
            {
                result = InventoryDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Inventory entity)
        {
            bool result = false;
            try
            {
                result = InventoryDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Inventory entity)
        {
            bool result = false;
            try
            {
                result = InventoryDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}

