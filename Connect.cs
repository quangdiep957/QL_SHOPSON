using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_SHOPSON
{
    class Connect
    {
        string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=sa;Password=123456;";
      
       
        SqlConnection conn = null;


        public Connect()
        {
            conn = new SqlConnection(con_str);
        }
        public DataSet getData(string query, string table_name, List<SqlParameter> _params)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (_params != null)
                    da.SelectCommand.Parameters.AddRange(_params.ToArray());
                da.Fill(ds, table_name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
            return ds;
        }

      

            public void excute(string query, List<SqlParameter> _params)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (_params != null)
                    cmd.Parameters.AddRange(_params.ToArray());
                cmd.ExecuteNonQuery();
                
                //SqlDataReader rd = cmd.ExecuteReader();
                
               
                conn.Close();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
        }
        public int Kiemtra (string query, List<SqlParameter> _params)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (_params != null)
                    cmd.Parameters.AddRange(_params.ToArray());
                int i= (int)cmd.ExecuteScalar();
                conn.Close();
                if (i == 1)
                {
                    return 1;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message);
            }
            return 0;
        }

    }
}
