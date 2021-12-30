using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QL_SHOPSON
{
    public partial class CreateQR : Form
    {
        public CreateQR()
        {

            InitializeComponent();
            getDatancc();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string add = textBox1.Text + "," + comboBox1.SelectedValue.ToString() +"," +textBox4.Text;
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;   
            pictureBox1.Image = qrcode.Draw(add, 50);
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
            }
        }
        public void getDatancc()
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);

            try
            {
                string query1 = "select TENNCC,MANCC from NHACUNGCAP";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                da.Fill(ds, "NHACUNGCAP");
                comboBox1.DataSource = ds.Tables["NHACUNGCAP"];
                comboBox1.DisplayMember = "TENNCC";
                comboBox1.ValueMember = "MANCC";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = barcode.Draw(textBox1.Text + ", " + comboBox1.SelectedValue.ToString() + "," + textBox4.Text, 50);
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CreateQR_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            GIAODIEN gd = new GIAODIEN();
            gd.Show();
            this.Visible = false;
        }
    }
}
