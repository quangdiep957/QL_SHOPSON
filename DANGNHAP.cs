using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_SHOPSON
{
    public partial class DANGNHAP : Form
    {
         GIAODIEN gd = new GIAODIEN();
        public DANGNHAP()
        {
            InitializeComponent();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
                SqlConnection conn = new SqlConnection(con_str);

                conn.Open();

                string tk = txttk.Text;
                string mk = txtmk.Text;
                string query = "select Count(*) from TAIKHOAN where USERNAME = @tk and PASSWORD = @mk";
               

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add(new SqlParameter("@tk", tk));
                cmd.Parameters.Add(new SqlParameter("@mk", mk));

                int soluong = (int)cmd.ExecuteScalar();
                // Bước 5: Đóng kết nối
                conn.Close();

                // Kiểm tra dữ liệu trả về
                if (soluong == 1)
                {
                    //MessageBox.Show("Đăng nhập thành công!");
                  //  this.DialogResult = DialogResult.OK;
                  //  this.Close();

                    gd.Show();
                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void txtmk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
