using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorio.DataAccess;
using Laboratorio.Entities;

namespace Laboratorio.BussinesLogic
{
    public class BillBL
    {
        private static BillBL _instance;
        public static BillBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BillBL();
                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = BillDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/
        public List<Bill> SellectAll()
        {
            List<Bill> result;
            try
            {
                result = BillDAL.Instance.SellectAll();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }return result;

        }
        public bool Insert (Bill entity)
        {
            bool result = false;
            try
            {
                result = BillDAL.Instance.Insert(entity);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }return result;
        }
        public bool Update(Bill entity)
        {
            bool result = false;
            try
            {
                result = BillDAL.Instance.Update(entity);
            }catch(Exception ex)
            {
                throw new Exception("error."+ex.Message);
            }return result;
        }
    }
}
