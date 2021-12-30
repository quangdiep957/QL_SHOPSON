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
    public partial class QL_HD : Form
    {
        List<Class1> list = new List<Class1>();
        Connect con = new Connect();

        public QL_HD()
        {
            InitializeComponent();
            getData();
            getDatacb();
            getDataMSP();
            getimg();
            getDatanv();


        }
        public void getData()
        {
            try
            {
                string Query = "Select * from HOADON";
                DataSet ds = con.getData(Query, "HOADON", null);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["HOADON"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void getDatacb()
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);

            try
            {
                string query1 = "select TENKH,MAKH from KHACHHANG";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                da.Fill(ds,"KHACHHANG");
                comboBox1.DataSource = ds.Tables["KHACHHANG"];
                comboBox1.DisplayMember = "TENKH";
                comboBox1.ValueMember = "MAKH";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi"+ex);
            }
        }
        public void getDatanv()
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);

            try
            {
                string query1 = "select TENNV,MANV from NHANVIEN";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                da.Fill(ds, "NHANVIEN");
                comboBox3.DataSource = ds.Tables["NHANVIEN"];
                comboBox3.DisplayMember = "TENNV";
                comboBox3.ValueMember = "MANV";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }
        public void getDataMSP()
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);

            try
            {
                string query1 = "select MASP,TENSP,GIANHAP from SANPHAM";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                da.Fill(ds, "SANPHAM");
                comboBox2.DataSource = ds.Tables["SANPHAM"];
                comboBox2.DisplayMember = "TENSP";
                comboBox2.ValueMember = "MASP";           
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }

         public void getimg()
         {

             string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
             SqlConnection conn = new SqlConnection(con_str);
             string s = comboBox2.SelectedValue.ToString().Trim();

             string Query = "SELECT ANH FROM SANPHAM WHERE MASP='" + s + "'";


             SqlDataAdapter da = new SqlDataAdapter(Query, conn);
             DataTable dt = new DataTable();
             da.Fill(dt);
             // Hiển thị dữ liệu lên TEXT
             if (dt.Rows.Count > 0)
             {
                 //textBox1.Text = dt.Rows[0]["ANH"].ToString().Trim();
                 var image = (Bitmap)Bitmap.FromFile(dt.Rows[0]["ANH"].ToString().Trim());
                 pictureBox1.Image = image;
                 pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

             }
             else
             {
                 MessageBox.Show("Khoong");
             }


         }
        public void getimg1(PictureBox picname, string s)
        {

            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            //string s = comboBox2.SelectedValue.ToString().Trim();

            string Query = "SELECT ANH FROM SANPHAM WHERE MASP='" + s + "'";


            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Hiển thị dữ liệu lên TEXT
            if (dt.Rows.Count > 0)
            {
                //textBox1.Text = dt.Rows[0]["ANH"].ToString().Trim();
                var image = (Bitmap)Bitmap.FromFile(dt.Rows[0]["ANH"].ToString().Trim());
                picname.Image = image;
                picname.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                MessageBox.Show("Khoong");
            }


        }
        public void clearText()
        {
            txtmhd.Enabled = true;
            txtthd.Enabled = true;
           
            txttt.Enabled = true;
            //txtmsp.Enabled = true;
            //txtmnv.Enabled = true;          
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;



        }
      
       

      

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {
                txtmhd.Enabled = false;

                btnthem.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtmhd.Text = dataGridView1.Rows[idx].Cells["MAHD"].Value.ToString();
                txtthd.Text = dataGridView1.Rows[idx].Cells["TENHD"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[idx].Cells["NGAYLAP"].Value.ToString();
               //  txtmsp.Text = dataGridView1.Rows[idx].Cells["MASP"].Value.ToString();
                txttt.Text = dataGridView1.Rows[idx].Cells["TONGTIEN"].Value.ToString();
               
                comboBox1.Text = dataGridView1.Rows[idx].Cells["MAKH"].Value.ToString();
                txtsl.Text = dataGridView1.Rows[idx].Cells["SOLUONG"].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[idx].Cells["MANV"].Value.ToString();




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintHD pr = new PrintHD();
            pr.Show();
            this.Visible = false;
        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {

            string tenhd = txtthd.Text;
            string ngaylap = dateTimePicker1.Value.ToString();
            int msp = int.Parse(comboBox2.SelectedValue.ToString().Trim());
            // string thanhtien = txttt.Text;
            int mnv = int.Parse(comboBox3.SelectedValue.ToString().Trim());
            int sl = int.Parse(txtsl.Text);
            int mkh = int.Parse(comboBox1.SelectedValue.ToString());
            int tongtien = 0;
            int slsp = 0;
            string Query = "insert into HOADON VaLUES( @thd,@ngaylap,@tongtien,@mkh,@sl,@mnv)";

            List<SqlParameter> _params = new List<SqlParameter>();
            for (int i = 0; i < list.Count; i++)
            {
                tongtien += int.Parse(list[i].tongtien);
                slsp += int.Parse(list[i].soluong);

            }
            
            
                tongtien = tongtien - int.Parse(txtdiem.Text + "000");
                int diemgoc = Giamtien();
                int diem = diemgoc - int.Parse(txtdiem.Text);
                // setdiem(diem);
              
                string updatediem = "update the set diem =@diem where MAKH =@makh";
                List<SqlParameter> _pr = new List<SqlParameter>();
                _pr.Add(new SqlParameter("@makh", mkh));
                _pr.Add(new SqlParameter("@diem", diem));
                con.excute(updatediem, _pr);
            
           
            _params.Add(new SqlParameter("@thd", tenhd));
            _params.Add(new SqlParameter("@ngaylap", ngaylap));
            _params.Add(new SqlParameter("@tongtien", tongtien));
            _params.Add(new SqlParameter("@mkh", mkh));
            _params.Add(new SqlParameter("@sl", slsp));
            _params.Add(new SqlParameter("@mnv", mnv));

            con.excute(Query, _params);
            MessageBox.Show("Thêm mới thành công");
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            string s = comboBox2.SelectedValue.ToString().Trim();

            string query2 = "select mahd from hoadon where ngaylap ='" + ngaylap + "' and makh='" + mkh + "'";
            SqlDataAdapter da = new SqlDataAdapter(query2, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Hiển thị dữ liệu lên TEXT
            if (dt.Rows.Count > 0)
            {
                int mahd = int.Parse(dt.Rows[0]["MAHD"].ToString().Trim());
                for (int i = 0; i < list.Count; i++)
                {
                    tongtien += int.Parse(list[i].tongtien);
                    string Query1 = "insert into CT_HOADON(MAHD,SOLUONG,GIATIEN,MASP) values (@mahd,@sl,@tongtien,@msp)";
                    List<SqlParameter> _params1 = new List<SqlParameter>();
                    _params1.Add(new SqlParameter("@mahd", mahd));
                    _params1.Add(new SqlParameter("@sl", list[i].soluong));
                    _params1.Add(new SqlParameter("@tongtien", list[i].giatien));
                    _params1.Add(new SqlParameter("@msp", list[i].masp));
                    con.excute(Query1, _params1);
                }


                taothe(mkh,mahd);
            }
            getData();


        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            
                string mhd = txtmhd.Text;
                string tenhd = txtthd.Text;
                string ngaylap = dateTimePicker1.Text;
                string msp = comboBox2.SelectedValue.ToString().Trim();
                int thanhtien = int.Parse(txttt.Text);
                string mnv = comboBox3.SelectedValue.ToString().Trim();
                string mkh = comboBox1.SelectedValue.ToString();
                string sl = txtsl.Text;

                    string query = "Update HOADON set TENHD=@thd,NGAYLAP =@ngaylap ,TONGTIEN= @thanhtien  ,MANV=@mnv,MAKH=@mkh,SOLUONG=@sl where MAHD=@mhd";
                    List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@mhd", mhd));
                    _params.Add(new SqlParameter("@thd", tenhd));
                    _params.Add(new SqlParameter("@ngaylap", ngaylap));
      
                    _params.Add(new SqlParameter("@thanhtien", thanhtien));
                    _params.Add(new SqlParameter("@mnv", mnv));
                    _params.Add(new SqlParameter("@mkh", mkh));
                    _params.Add(new SqlParameter("@sl", sl));

                    con.excute(query, _params);

                    MessageBox.Show("Sửa thành công");
              
                    getData();
                
            
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            
                string mhd = txtmhd.Text;
            List<SqlParameter> _params1 = new List<SqlParameter>();
            string kiemtra = "select count (*) from HOADON where MAHD=@tk ";          
                _params1.Add(new SqlParameter("@tk", mhd));
               
                if (con.Kiemtra(kiemtra,_params1) == 1)
                {

                    string Query = "Delete from HOADON where MAHD = @mhd";
                    List<SqlParameter> _params = new List<SqlParameter>();
                    _params.Add(new SqlParameter("@mhd", mhd));
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string TK = textBox1.Text;


                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@TK", textBox1.Text));
                string query = "Select * from HOADON where  TENHD Like '%" + TK + "%' ";
                con.excute(query, _params);
                getData();
                DataSet ds = con.getData(query, "HOADON", null);
                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["HOADON"];

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            string s = comboBox2.SelectedValue.ToString().Trim();

            string Query = "SELECT GIABAN FROM SANPHAM WHERE MASP='" + s + "'";


            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Hiển thị dữ liệu lên TEXT
            if (dt.Rows.Count > 0)
            {
                txtgia.Text = dt.Rows[0]["GIABAN"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Khoong");

            }

            if (txtgia.Text != "" && txtsl.Text != "")
            {
                double i = double.Parse(txtsl.Text);
                double j = double.Parse(txtgia.Text);
                double kq = i * j;
                txttt.Text = kq.ToString();
            }
            else
            {

                MessageBox.Show("vui lòng nhập số lượng");
            }
        }

        private void QL_HD_Load(object sender, EventArgs e)
        {
        
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy,hh:mm:ss";

            dateTimePicker1.Value = DateTime.Now;
            txtdiem.Text = "0";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            getimg();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txttt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void taothe(int makh,int mahd)
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            string query2 = "select tongtien from hoadon where makh='" + makh + "' and mahd ='"+ mahd +"'";

            SqlDataAdapter da = new SqlDataAdapter(query2, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Hiển thị dữ liệu lên TEXT
            if (dt.Rows.Count > 0)
            {
                string tong = dt.Rows[0]["tongtien"].ToString().Trim();
                int diem = int.Parse(tong) / 100000;
                DateTime aDateTime = DateTime.Now;
                DateTime newTime = aDateTime.AddYears(1);
                string ngaykh = dateTimePicker1.Value.ToString();
                string ngayhethan = newTime.ToString();
                int id_loaithe = 2;
                if (diem >= 1000 && diem < 3000)
                {
                    id_loaithe = 3;
                }
                if (diem >= 3000 && diem < 10000)
                {
                    id_loaithe = 4;
                }
                if (diem > 10000)
                {
                    id_loaithe = 5;
                }
                List<SqlParameter> _params1 = new List<SqlParameter>();
                string kiemtra = "select count (*) from the where MAKH=@tk ";
                _params1.Add(new SqlParameter("@tk", makh));
                string query = " ";
                if (con.Kiemtra(kiemtra, _params1) == 1)
                {
                    int diemdau = Giamtien();
                    diem = diemdau + diem;
                    query = "update the set id_loaithe=@loaithe,diem=@diem where makh=@makh";

                }
                else
                {
                    query = "insert into the(trangthai,ngayhethan,id_loaithe,makh,ngaykichhoat,diem) values(1,@ngayhethan,@loaithe,@makh,@ngaykh,@diem)";
                }
                List<SqlParameter> _params = new List<SqlParameter>();
                _params.Add(new SqlParameter("@ngaykh", ngaykh));
                _params.Add(new SqlParameter("ngayhethan", ngayhethan));
                _params.Add(new SqlParameter("@loaithe", id_loaithe));
                _params.Add(new SqlParameter("@makh", makh));
                _params.Add(new SqlParameter("@diem", diem));
                con.excute(query, _params);



            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           txtdiem.Text=Giamtien().ToString();
        }
        int Giamtien()
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);

            string s = comboBox1.SelectedValue.ToString().Trim();

            string Query = "SELECT diem FROM the WHERE MAKH='" + s + "'";


            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Hiển thị dữ liệu lên TEXT
            if (dt.Rows.Count > 0)
            {
                return  int.Parse(dt.Rows[0]["diem"].ToString().Trim());
            }
            else
            {
                MessageBox.Show("Khoong");
                return 0;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {

               
                if (this.panel1.Controls["pichd0"] == null)
                {
                    PictureBox pic = new PictureBox();
                    pic.Location = new System.Drawing.Point(7, 80);
                    pic.Margin = new System.Windows.Forms.Padding(10, 10, 3, 2);
                    pic.Size = new System.Drawing.Size(100, 100);
                    pic.TabIndex = 27;
                    pic.TabStop = false;

                    pic.Name = "pichd0";

                    pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pic.TabStop = false;
                    // pic.Text = files[i];

                    this.panel1.Controls.Add(pic);
                    getimg1(pic, list[i].masp);
                }
                else if (this.Controls["pichd" + i] == null)

                    TaopicBenDuoi((PictureBox)this.panel1.Controls["pichd" + (i - 1)], "pichd" + i);
                else if (i > list.Count)
                    this.Controls["pichd" + i].Dispose();
                if (this.panel1.Controls["texthda0"] == null)
                {
                    TextBox tx = new TextBox();
                    tx.Location = new System.Drawing.Point(150,120);
                    tx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);

                    tx.Size = new System.Drawing.Size(57, 26);
                    tx.TabIndex = 4;
                    tx.Name = "texthda0";

                    this.panel1.Controls.Add(tx);
                    tx.Text = list[i].soluong;
                }
                else if (this.Controls["texthda" + i] == null)
                {
                    TaoTextBoxBenDuoi((TextBox)this.panel1.Controls["texthda" + (i - 1)], "texthda" + i);
                    this.panel1.Controls["texthda" + i].Text = list[i].soluong;
                }
                if (this.panel1.Controls["texthdb0"] == null)
                {
                    TextBox tx = new TextBox();

                    tx.Location = new System.Drawing.Point(250,120);
                    tx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);

                    tx.Size = new System.Drawing.Size(100, 26);
                    tx.TabIndex = 6; tx.Name = "texthdb0";

                    this.panel1.Controls.Add(tx);
                    tx.Text = list[i].giatien;
                }
                else if (this.Controls["texthdb" + i] == null)
                {
                    TaoTextBoxBenDuoi((TextBox)this.panel1.Controls["texthdb" + (i - 1)], "texthdb" + i);
                    this.panel1.Controls["texthdb" + i].Text = list[i].giatien;
                }
                void TaopicBenDuoi(PictureBox TextBoxBenTren, string picName)
                    {

                        PictureBox tbx = new PictureBox();

                        tbx.Top = TextBoxBenTren.Bottom + 1;
                        tbx.Left = TextBoxBenTren.Left;
                        tbx.Width = TextBoxBenTren.Width;
                        tbx.Height = TextBoxBenTren.Height;
                        tbx.Name = picName;
                        getimg1(tbx, list[i].masp);
                        TextBoxBenTren.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.panel1.Controls.Add(tbx);


                    }
                   
                   


                   

                    void TaoTextBoxBenDuoi(TextBox TextBoxBenTren, String TextBoxName)
                    {

                        TextBox tbx = new TextBox();
                        tbx.Top = TextBoxBenTren.Bottom + 90;
                        tbx.Left = TextBoxBenTren.Left;
                        tbx.Width = TextBoxBenTren.Width;
                        tbx.Name = TextBoxName;
                        tbx.ScrollBars = TextBoxBenTren.ScrollBars;


                        this.panel1.Controls.Add(tbx);
                    }
                
 
            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string msp = comboBox2.SelectedValue.ToString().Trim();
            string thanhtien = txttt.Text;
            string mnv = comboBox3.SelectedValue.ToString().Trim();
            string sl = txtsl.Text;
            string mkh = comboBox1.SelectedValue.ToString();
            if (msp != "" && thanhtien != "" && mnv != "")
            {
                DialogResult result = MessageBox.Show("Bạn có xác nhận lưu sản phẩm này không Mã Sản Phẩm :" +msp +"Số lượng : " +sl +"Giá tiền :"+thanhtien, "caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {


                    var item = new Class1();
                    item.masp = msp;
                    item.soluong = sl;
                    item.giatien = thanhtien;
                    item.tongtien = txttt.Text;
                    list.Add(item);


                }
                else
                {
                    MessageBox.Show("Đóng");

                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm");
            }
              
            
        }
       
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       
          

       
    }
}
