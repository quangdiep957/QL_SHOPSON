using Microsoft.Reporting.WinForms;
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
    public partial class PrintHD : Form
    {
        
        public PrintHD()
        {
            InitializeComponent();
        }

        private void PrintHD_Load(object sender, EventArgs e)
        {
            string con_str = "Data Source=LAPTOP-IS4TF3VU\\SQLEXPRESS;Initial Catalog=SONTUANHAU;User ID=SA;Password=123456;";
            SqlConnection conn = new SqlConnection(con_str);
            string query2 = "SELECT top(1) MAHD FROM HOADON order by MAHD DESC";

            SqlDataAdapter da1 = new SqlDataAdapter(query2, conn);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            // Hiển thị dữ liệu lên TEXT
            if (dt.Rows.Count > 0)
            {
                string mahd = dt.Rows[0]["MAHD"].ToString().Trim();
                this.reportViewer1.RefreshReport();


                try
                {
                    string query1 = "select HD.MAHD,HD.TENHD,CTHD.SOLUONG, KH.TENKH,HD.NGAYLAP,CTHD.GIATIEN,SP.TENSP ,HD.TONGTIEN FROM((HOADON HD INNER JOIN KHACHHANG KH ON HD.MAKH = KH.MAKH)INNER JOIN CT_HOADON CTHD ON HD.MAHD = CTHD.MAHD INNER JOIN SANPHAM SP ON SP.MASP = CTHD.MASP) where HD.mahd = '"+ mahd+"'";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query1, conn);
                    da.Fill(ds, "hoadon_customer");
                    reportViewer1.LocalReport.ReportEmbeddedResource = "QL_SHOPSON.Report2.rdlc";
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "DataSet1";
                    rds.Value = ds.Tables["hoadon_customer"];
                    reportViewer1.LocalReport.DataSources.Add(rds);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex);
                }

                this.reportViewer1.RefreshReport();

            }
        }
    }
}
