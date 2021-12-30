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
    public partial class QL_NCC : Form
    {
        Connect con = new Connect();
        public QL_NCC()
        {
            
            InitializeComponent();
            getData();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }
        public void getData()
        {
            string query = "select *from NHACUNGCAP";
            DataSet ds = con.getData(query, "NHACUNGCAP", null);
            // Hiển thị dữ liệu lên DataGridView
            dataGridView1.DataSource = ds.Tables["NHACUNGCAP"];
        }
        public void clearText()
        {
            txtmancc.Enabled = true;
            txtten.Enabled = true;
            txtloaisp.Enabled = true;

            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;

        }

        private void QL_NCC_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {

                txtten.Enabled = false;
                btnthem.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtmancc.Text = dataGridView1.Rows[idx].Cells["MANCC"].Value.ToString();
                txtten.Text = dataGridView1.Rows[idx].Cells["TENNCC"].Value.ToString();
                txtloaisp.Text = dataGridView1.Rows[idx].Cells["LOAISP"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            try
            {

                string ten = txtten.Text;
                string loaisp = txtloaisp.Text;

                string Query = "insert into NHACUNGCAP VaLUES( @ten, @loaisp)";

                List<SqlParameter> _params = new List<SqlParameter>();

                _params.Add(new SqlParameter("@ten", ten));
                _params.Add(new SqlParameter("@loaisp", loaisp));

                con.excute(Query, _params);
                MessageBox.Show("Thêm mới thành công");
                getData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            // string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            //  SqlConnection conn = new SqlConnection(con_str);
            try
            {
                string mancc = txtmancc.Text;
                string ten = txtten.Text;
                string loaisp = txtloaisp.Text;

                {

                    string query = "Update NHACUNGCAP set TENNCC='" + ten + "',LOAISP ='" + loaisp + "' where MaNCC='" + mancc + "'";
                    List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@mancc", mancc));
                    _params.Add(new SqlParameter("@ten", ten));
                    _params.Add(new SqlParameter("@loaisp", loaisp));


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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            try
            {
                string mancc = txtmancc.Text;

                string kiemtra = "select count (*) from NHACUNGCAP where MaNCC=@tk ";
                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@tk", mancc));
                if (con.Kiemtra(kiemtra, _params) == 1)
                {

                    string Query = "Delete from NHACUNGCAP where MaNCC = @mancc";
                    List<SqlParameter> _params1 = new List<SqlParameter>();
                    _params1.Add(new SqlParameter("@mancc", mancc));
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

        private void button3_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect con = new Connect();
            try
            {
                string TK = textBox1.Text;


                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@TK", textBox1.Text));
                string query = "Select * from NHACUNGCAP where  TENNCC Like '%" + TK + "%' ";
                con.excute(query, _params);
                getData();
                DataSet ds = con.getData(query, "NHACUNGCAP", null);
                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["NHACUNGCAP"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
