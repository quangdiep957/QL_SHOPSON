using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_SHOPSON
{
    public partial class QL_NV : Form
    {

       
        Connect con = new Connect();
       
        public QL_NV()
        {
            
            InitializeComponent();
            getData();
        }
        
        public void getData()
        {
            try
            {
                string Query = "Select * from NHANVIEN";
                DataSet ds = con.getData(Query, "NHANVIEN", null);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["NHANVIEN"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void clearText()
        {

            txtten.Enabled = true;
            txtcmnd.Enabled = true;
            txtsdt.Enabled = true;
            txtcv.Enabled = true;
            
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;



        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {
                txtmnv.Enabled = false;
                txtten.Enabled = false;
                btnthem.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtmnv.Text = dataGridView1.Rows[idx].Cells["MANV"].Value.ToString();
                txtten.Text = dataGridView1.Rows[idx].Cells["TENNV"].Value.ToString();
                txtcmnd.Text = dataGridView1.Rows[idx].Cells["CMND"].Value.ToString();
                txtcv.Text = dataGridView1.Rows[idx].Cells["CHUCVU"].Value.ToString();
                txtsdt.Text = dataGridView1.Rows[idx].Cells["SDT"].Value.ToString();
                

            }
        }

        private void txtmnv_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtmnv_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
          
            try
            {
               
                string ten = txtten.Text;
                string cmnd = txtcmnd.Text;
                string sdt = txtsdt.Text;
                string cv = txtcv.Text;
               
                string Query = "insert into NHANVIEN VaLUES( @ten, @cmnd, @cv, @sdt)";

                List<SqlParameter> _params = new List<SqlParameter>();

                    _params.Add(new SqlParameter("@ten", ten));
                    _params.Add(new SqlParameter("@cmnd", cmnd));
                    _params.Add(new SqlParameter("@cv", cv));
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

        private void btnsua_Click_1(object sender, EventArgs e)
        {
           // string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
          //  SqlConnection conn = new SqlConnection(con_str);
            try
            {
                string mnv = txtmnv.Text;
                string ten = txtten.Text;
                string cmnd = txtcmnd.Text;
                string sdt = txtsdt.Text;
                string cv = txtcv.Text;
              /*  string kiemtra = "select count (*) from NHANVIEN where MaNV=@tk ";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(kiemtra, conn);
                cmd1.Parameters.Add(new SqlParameter("@tk", mnv));
                int soluong = (int)cmd1.ExecuteScalar();
                conn.Close();
                if (soluong == 1)*/
                {

                    string query = "Update NHANVIEN set TENNV='" + ten + "',CMND ='" + cmnd + "',CHUCVU='" + cv + "',SDT='" + sdt + "' where MaNV='" + mnv + "'";
                    List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@mnv", mnv));
                    _params.Add(new SqlParameter("@ten", ten));
                    _params.Add(new SqlParameter("@cmnd", cmnd));
                    _params.Add(new SqlParameter("@cv", cv));
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

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            try
            {
                string mnv = txtmnv.Text;

                string kiemtra = "select count (*) from NHANVIEN where MaNV=@tk ";
                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@tk", mnv));
                if (con.Kiemtra(kiemtra,_params) == 1)
                {

                    string Query = "Delete from NHANVIEN where MaNV = @mnv";
                    List<SqlParameter> _params1 = new List<SqlParameter>();
                    _params1.Add(new SqlParameter("@mnv", mnv));
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string TK = textBox1.Text;


                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@TK", textBox1.Text));
                string query = "Select * from NHANVIEN where  TENNV Like '%" + TK + "%' ";
                con.excute(query, _params);
                getData();
                DataSet ds = con.getData(query, "NHANVIEN", null);
                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["NHANVIEN"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
    
}
