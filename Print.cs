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
using Microsoft.Reporting.WinForms;

namespace QL_SHOPSON
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);

            try
            {
                string query1 = "select HD.MAHD,HD.TENHD,CTHD.SOLUONG,CTHD.TENSP, KH.TENKH,HD.NGAYLAP,CTHD.GIATIEN FROM((HOADON HD INNER JOIN KHACHHANG KH ON HD.MAKH = KH.MAKH)INNER JOIN CT_HOADON CTHD ON HD.MAHD = CTHD.MAHD)";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                da.Fill(ds, "HOADON");
                reportViewer1.LocalReport.ReportEmbeddedResource = "QL_SHOPSON.Report1.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables["HOADON"];
                reportViewer1.LocalReport.DataSources.Add(rds);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex);
            }

            this.reportViewer1.RefreshReport();
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
