using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfgit
{
     public class Dataprovider
    {
        private static Dataprovider instance;
        public static Dataprovider Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Dataprovider();
                }
                return instance;
            }
        }
        private Dataprovider() { }
        string connectionstring = @"Data Source=.\SQLExpress;Initial Catalog=Student_DB;Integrated Security=True";
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] temp = query.Split(' ');
                    List<string> listpara = new List<string>();
                    foreach (string item in temp)
                    {
                        if (item[0] == '@')
                            listpara.Add(item);
                    }
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.AddWithValue(listpara[i], parameter[i]);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
    }
}
