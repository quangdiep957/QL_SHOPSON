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
    public partial class THONGKE : Form
    {
        Connect con = new Connect();
        public THONGKE()
        {
            InitializeComponent();
            getData();
        
        }

        public void getData()
        {
            try
            {
                string query = " SELECT  HD.TENHD,HD.NGAYLAP,HD.SOLUONG,SP.TENSP,HD.TONGTIEN,SP.GIABAN,SP.MAMAU,SP.MANCC FROM SANPHAM SP, HOADON HD, CT_HOADON CTHD WHERE SP.MASP = CTHD.MASP AND HD.MAHD=CTHD.MAHD ORDER BY TONGTIEN DESC";
                DataSet ds = con.getData(query, "THONGKE", null);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["THONGKE"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void getDatatop()
        {
            try
            {
                string query = " SELECT top(3)  HD.TENHD,HD.NGAYLAP,HD.SOLUONG,SP.TENSP,HD.TONGTIEN,SP.GIABAN,SP.MAMAU,SP.MANCC FROM SANPHAM SP, HOADON HD, CT_HOADON CTHD WHERE SP.MASP = CTHD.MASP AND HD.MAHD = CTHD.MAHD ORDER BY TONGTIEN desc";
                DataSet ds = con.getData(query, "THONGKE", null);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["THONGKE"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getDatatop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            tinhtong();
            tinhsl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getdate();
        }
        
        public void tinhtong()
        {
            int tien = dataGridView1.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien - 1; i++)
            {
                thanhtien += decimal.Parse(dataGridView1.Rows[i].Cells["TONGTIEN"].Value.ToString());

            }
            textBox2.Text = thanhtien.ToString();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(textBox2.Text, System.Globalization.NumberStyles.AllowThousands);
            textBox2.Text = string.Format(culture, "{0:N0}", value);
            textBox2.Select(textBox2.Text.Length, 0);
        }
        public void tinhsl()
        {
            int sum = dataGridView1.Rows.Count;
            decimal soluong = 0;
            for (int i = 0; i < sum - 1; i++)
            {
                soluong += decimal.Parse(dataGridView1.Rows[i].Cells["SOLUONG"].Value.ToString());
            }
            textBox1.Text = soluong.ToString();
        }
        public void getdate()
        {
            try
            {
                string ngayin = dateTimePicker1.Text;
                string ngayout = dateTimePicker2.Text;
                string query = "SELECT  HD.TENHD,HD.NGAYLAP,HD.SOLUONG,SP.TENSP,HD.TONGTIEN,SP.GIABAN,SP.MAMAU,SP.MANCC FROM SANPHAM SP, HOADON HD, CT_HOADON CTHD WHERE SP.MASP = CTHD.MASP AND HD.MAHD = CTHD.MAHD AND NGAYLAP BETWEEN '"+dateTimePicker1.Text+ "' AND '" + dateTimePicker2.Text + "' ORDER BY HD.TONGTIEN DESC ";
                DataSet ds = con.getData(query, "THONGKE", null);

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = ds.Tables["THONGKE"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }

        private void THONGKE_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";

            dateTimePicker2.Value = DateTime.Now;
        }
    }
}
