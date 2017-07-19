using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAO
{
    class DataProvider
    {
        private string strConnection = @"Data Source=.\Giang-PC;Initial Catalog=LTSS;User ID=sa;  Password=TBS@123456";
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return DataProvider.instance;
            }

            private set
            {
                DataProvider.instance = value;
            }
        }

        private DataProvider()
        {

        }

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            //Table chứa data
            var dataTable = new DataTable();
            using (var connection = new SqlConnection(strConnection))
            {
                connection.Open();

                //Thực thi câu lệnh query
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    var listPara = query.Split(' ');
                    var i = 0;
                    foreach (var  item in listPara)
                    {
                        if (!item.Contains("@")) continue;
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }

                //doi tuong trung gian thuc thi cau lenh SQL Query
                var sqlAdapter = new SqlDataAdapter(command);

                sqlAdapter.Fill(dataTable);

                connection.Close();
            }
            return dataTable;
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (var connection = new SqlConnection(strConnection))
            {
                connection.Open();

                //Thực thi câu lệnh query
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    var listPara = query.Split(' ');
                    var i = 0;
                    foreach (var item in listPara)
                    {
                        if (!item.Contains("@")) continue;
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = 0;
            using (var connection = new SqlConnection(strConnection))
            {
                connection.Open();

                //Thực thi câu lệnh query
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    var listPara = query.Split(' ');
                    var i = 0;
                    foreach (var item in listPara)
                    {
                        if (!item.Contains("@")) continue;
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
