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
    public partial class QL_KH : Form
    {
        Connect con = new Connect();
        public QL_KH()
        {
            InitializeComponent();
            getData();
        }
        public void getData()
        {
            try
            {
                string Query = "Select * from KHACHHANG";
                DataSet ds = con.getData(Query, "KHACHHANG", null);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["KHACHHANG"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void clearText()
        {
      
            txtten.Enabled = true;
            txtdchi.Enabled = true;
            txtsdt.Enabled = true;
            txtemail.Enabled = true;
            

            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void label6_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {

                string ten = txtten.Text;
                string diachi = txtdchi.Text;
                string sdt = txtsdt.Text;
                string email = txtemail.Text;

                string Query = "insert into KHACHHANG VaLUES( @ten, @diachi, @sdt, @email)";

                List<SqlParameter> _params = new List<SqlParameter>();

                _params.Add(new SqlParameter("@ten", ten));
                _params.Add(new SqlParameter("@diachi", diachi));
                _params.Add(new SqlParameter("@email", email));
                _params.Add(new SqlParameter("@sdt", sdt));

                con.excute(Query, _params);
                MessageBox.Show("Thêm mới thành công");
                getData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            //  SqlConnection conn = new SqlConnection(con_str);
            try
            {
                string mkh = txtmakh.Text;
                string ten = txtten.Text;
                string diachi = txtdchi.Text;
                string sdt = txtsdt.Text;
                string email = txtemail.Text;
                /*  string kiemtra = "select count (*) from NHANVIEN where MaNV=@tk ";
                  conn.Open();
                  SqlCommand cmd1 = new SqlCommand(kiemtra, conn);
                  cmd1.Parameters.Add(new SqlParameter("@tk", mnv));
                  int soluong = (int)cmd1.ExecuteScalar();
                  conn.Close();
                  if (soluong == 1)*/
                {

                    string query = "Update KHACHHANG set TENKH='" + ten + "',DIACHI ='" + diachi + "',SDT='" + sdt + "', EMAIL='" + email + "' where MaKH='" + mkh + "'";
                    List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@mkh", mkh));
                    _params.Add(new SqlParameter("@ten", ten));
                    _params.Add(new SqlParameter("@diachi", diachi));
                    _params.Add(new SqlParameter("@email", email));
                    _params.Add(new SqlParameter("@sdt", sdt));

                    con.excute(query, _params);

                    MessageBox.Show("Sửa thành công");
                    getData();
                }
                /* else
                 {
                     MessageBox.Show("Sửa không thành công");
                 }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtdchi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            try
            {
                string mkh = txtmakh.Text;

                string kiemtra = "select count (*) from KHACHHANG where MaKH=@tk ";
                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@tk", mkh));
                if (con.Kiemtra(kiemtra, _params) == 1)
                {

                    string Query = "Delete from KHACHHANG where MaKH = @mkh";
                    List<SqlParameter> _params1 = new List<SqlParameter>();
                    _params1.Add(new SqlParameter("@mkh", mkh));
                    con.excute(Query, _params1);
                    MessageBox.Show("Xóa thành công");
                    clearText();
                    getData();

                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {

                txtten.Enabled = false;
                btnthem.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtmakh.Text = dataGridView1.Rows[idx].Cells["MAKH"].Value.ToString();
                txtten.Text = dataGridView1.Rows[idx].Cells["TENKH"].Value.ToString();
                txtdchi.Text = dataGridView1.Rows[idx].Cells["DIACHI"].Value.ToString();
                txtsdt.Text = dataGridView1.Rows[idx].Cells["SDT"].Value.ToString();
                txtemail.Text = dataGridView1.Rows[idx].Cells["EMAIL"].Value.ToString();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }
    }
    
    
}
