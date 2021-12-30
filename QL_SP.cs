using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace QL_SHOPSON
{
    public partial class QL_SP : Form
    {
        Connect con = new Connect();
        public QL_SP()
        {

            InitializeComponent();
            getData();
            getDatasp();
        }
        public void getDatasp()
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);

            try
            {
                string query1 = "select TENSP,MASP from SANPHAM";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                da.Fill(ds, "SANPHAM");
                comboBox1.DataSource = ds.Tables["SANPHAM"];
                comboBox1.DisplayMember = "TENSP";
                comboBox1.ValueMember = "MASP";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }
        public void getData()
        {
            try
            {
                string Query = "Select * from SANPHAM";
                DataSet ds = con.getData(Query, "SANPHAM", null);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["SANPHAM"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void clearText()
        {
            txtmsp.Enabled = true;
            txttsp.Enabled = true;
            txtgia.Enabled = true;
           
            txtsl.Enabled = true;
            txtmncc.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;



        }


        private void QL_SP_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom; dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Custom; dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Value = DateTime.Today;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                //string msp = txtmsp.Text;
                string tensp = txttsp.Text;
                string gia = txtgia.Text;
                string hsd = dateTimePicker1.Value.ToString();
                string nsx = dateTimePicker2.Value.ToString(); 
                string mncc = txtmncc.Text;
                string mau = txtmam.Text;
                string sl = txtsl.Text;
                string anh = txtanh.Text;
                string gb = txtgiaban.Text;
               
               
                
                    string Query = "insert into SANPHAM VaLUES( @tsp,@gia, @hsd, @nsx, @mncc,@mau,@sl,@anh,@giaban)";


                List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@tsp", tensp));
                _params.Add(new SqlParameter("@gia", gia));
                _params.Add(new SqlParameter("@hsd", hsd));
                _params.Add(new SqlParameter("@nsx", nsx));
                _params.Add(new SqlParameter("@mncc", mncc));
                _params.Add(new SqlParameter("@mau", mau));
                _params.Add(new SqlParameter("@sl", sl));
                _params.Add(new SqlParameter("@anh", anh));
                _params.Add(new SqlParameter("@giaban", gb));


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
            
                string msp = txtmsp.Text;
                string tensp = txttsp.Text;
                string gia = txtgia.Text;
                string hsd = dateTimePicker1.Value.ToString();
                string nsx = dateTimePicker2.Value.ToString();
                string mncc = txtmncc.Text;
                string mau = txtmam.Text;
                string sl = txtsl.Text;
                string anh = txtsl.Text;
                string gb = txtgiaban.Text;
                string kiemtra = "select count (*) from SANPHAM where MaSP=@tk ";
            List<SqlParameter> _params1 = new List<SqlParameter>();
                _params1.Add(new SqlParameter("@tk", msp));

                if (con.Kiemtra(kiemtra,_params1) == 1)
                {

                    string query = "Update SANPHAM set TENSP='" + tensp + "',GIABAN ='" + gia + "',HSD='" + hsd + "',NSX='" + nsx + "',MANCC='" + mncc + "',MAMAU='" + mau + "',SOLUONG='" + sl + "' where MASP='" + msp + "'";
                    List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@msp", msp));
                    _params.Add(new SqlParameter("@tsp", tensp));
                    _params.Add(new SqlParameter("@gia", gia));
                    _params.Add(new SqlParameter("@hsd", hsd));
                    _params.Add(new SqlParameter("@nsx", nsx));
                    _params.Add(new SqlParameter("@mncc", mncc));
                    _params.Add(new SqlParameter("@mau", mau));
                    _params.Add(new SqlParameter("@sl", sl));
                    con.excute(query, _params);

                    MessageBox.Show("Sửa thành công");
                    getData();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công");
                }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TK = textBox1.Text;


                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@TK", textBox1.Text));
                string query = "Select * from SANPHAM where  TENSP Like '%" + TK + "%' ";
                con.excute(query, _params);
                getData();
                DataSet ds = con.getData(query, "SANPHAM", null);
                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["SANPHAM"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
           
                string msp = txtmsp.Text;

                string kiemtra = "select count (*) from SANPHAM where MASP=@tk ";
            List<SqlParameter> _params1 = new List<SqlParameter>();
                _params1.Add(new SqlParameter("@tk", msp));
                
                if (con.Kiemtra(kiemtra,_params1) == 1)
                {

                    string Query = "Delete from SANPHAM where MASP = @msp";
                    List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@msp", msp));
                    con.excute(Query, _params);
                    MessageBox.Show("Xóa thành công");
                    clearText();
                    getData();

                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {
                txtmsp.Enabled = false;

                btnthem.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtmsp.Text = dataGridView1.Rows[idx].Cells["MASP"].Value.ToString();
                txttsp.Text = dataGridView1.Rows[idx].Cells["TENSP"].Value.ToString();
                txtgia.Text = dataGridView1.Rows[idx].Cells["GIANHAP"].Value.ToString();
               dateTimePicker1.Text = dataGridView1.Rows[idx].Cells["HSD"].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[idx].Cells["NSX"].Value.ToString();
                txtmncc.Text = dataGridView1.Rows[idx].Cells["MANCC"].Value.ToString();
                txtmam.Text = dataGridView1.Rows[idx].Cells["MAMAU"].Value.ToString();
                txtsl.Text = dataGridView1.Rows[idx].Cells["SOLUONG"].Value.ToString();


            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ColorDialog dlg = new ColorDialog(); //Khởi tạo đối tượng ColorDialog 
            dlg.ShowDialog(); //Hiển thị hộp thoại

            if (dlg.ShowDialog() == DialogResult.OK) //Nếu nhấp vào nút OK trên hộp thoại
            {

                string str = dlg.Color.Name; //Trả lại tên của màu đã lựa chọn
                txtmam.Text = str;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            try
            {
                string masp = comboBox1.SelectedValue.ToString();
                string tongsl = "SELECT SUM(CTHD.SOLUONG) as sl FROM HOADON,CT_HOADON CTHD where CTHD.MASP='"+masp+"' ";
                SqlDataAdapter da = new SqlDataAdapter(tongsl, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);     
               int tong=int.Parse(dt.Rows[0]["sl"].ToString());
               
             
                string tongsp = "SELECT SUM(SOLUONG) as'sl' FROM SANPHAM where MASP='" + masp + "' ";
                SqlDataAdapter da1 = new SqlDataAdapter(tongsp, conn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                
                int tong1 = int.Parse(dt1.Rows[0]["sl"].ToString());
                int kq = tong1 - tong;

                string kiemtra = "select count(*) from SANPHAM ,HOADON,CT_HOADON where SANPHAM.SOLUONG < '"+tong+"' AND SANPHAM.MASP=CT_HOADON.MASP AND HOADON.MAHD=CT_HOADON.MAHD AND ct_hoadon.MASP='"+masp+"'";
                List<SqlParameter> _prams = new List<SqlParameter>();

                _prams.Add(new SqlParameter("@tk", masp));
                
                if (con.Kiemtra(kiemtra,_prams)==0)
                {

                    MessageBox.Show("Sản phẩm còn hàng :"+kq +"sản phẩm");
                }


                else
                {
                    MessageBox.Show("Sản phẩm hết hàng");
                    string query = "Update SANPHAM set SOLUONG='0' where MASP='" + masp + "'";
                    List<SqlParameter> _params = new List<SqlParameter>();
                   
                    con.excute(query, _params);

                  
                    getData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            using (var openDlg = new OpenFileDialog())
            {
                openDlg.Multiselect = false;
                if (openDlg.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = openDlg.FileName;
                    if (!File.Exists(fileName))
                    {
                        return;
                    }

                    var image = (Bitmap)Bitmap.FromFile(fileName);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    BarcodeReader ba = new BarcodeReader();
                    var result = ba.Decode(image);


                    if (result == null)
                    {
                        MessageBox.Show("Không nhận diện được mã QR Code",
                        "QR Code Generator");
                    }
                    else
                    {
                        textBox1.Text = result.Text;
                        string[] arrListStr = result.Text.Split(',');
                        if (arrListStr.Length == 3)
                        {
                            txttsp.Text = arrListStr[0];
                            txtmncc.Text = arrListStr[1];
                            txtgia.Text = arrListStr[2];
                        }
                        else
                        {
                            MessageBox.Show("Mã QR chưa đủ thông tin");
                        }
                    }
                }
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            using (var openDlg = new OpenFileDialog())
            {
                openDlg.Multiselect = false;
                if (openDlg.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = openDlg.FileName;
                    if (!File.Exists(fileName))
                    {
                        return;
                    }

                    var image = (Bitmap)Bitmap.FromFile(fileName);
                    pictureBox2.Image = image;
                    
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtanh.Text = fileName;

                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }
    }
}
