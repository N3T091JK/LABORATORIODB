using Laboratorio.DataAccess;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio.BussinesLogic
{
    public class InvoiceDetailBL
    {
        private static InvoiceDetailBL _instance;

        public static InvoiceDetailBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InvoiceDetailBL();

                return _instance;
            }
        }
        /************delete********************/
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = InvoiceDetailDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        /********************************/

        public List<InvoiceDetail> SellecALL()
        {
            List<InvoiceDetail> result;
            try
            {
                result = InvoiceDetailDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(InvoiceDetail entity)
        {
            bool result = false;
            try
            {
                result = InvoiceDetailDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(InvoiceDetail entity)
        {
            bool result = false;
            try
            {
                result = InvoiceDetailDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}

