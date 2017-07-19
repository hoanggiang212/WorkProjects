using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAO
{
    class CustomerDAO
    {
        private static CustomerDAO instance;
        public static CustomerDAO Instance
        {
            get
            {
                if (CustomerDAO.instance == null) instance = new CustomerDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private CustomerDAO() {}

        public DataTable getCustomerList(string sName, string sMst, string sAddress, string sPhoneNo)
        {
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExecuteNonQuery();

        }
            
    }
}
