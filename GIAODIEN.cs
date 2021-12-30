using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_SHOPSON
{
    public partial class GIAODIEN : Form
    {
        QL_HD hd = new QL_HD();
        QL_NV nv = new QL_NV();
        QL_SP sp = new QL_SP();
        public GIAODIEN()
        {

            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            sp.Show();
            this.Visible = false;


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            nv.Show();
            this.Visible = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            hd.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DANGNHAP gd = new DANGNHAP();
            gd.Show();
            this.Visible = false;
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            THONGKE gd = new THONGKE();
            gd.Show();
            this.Visible = false;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print pr = new Print();
            pr.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            nv.Show();
            this.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            sp.Show();
            this.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            hd.Show();
            this.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            THONGKE gd = new THONGKE();
            gd.Show();
            this.Visible = false;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Print pr = new Print();
            pr.Show();
            this.Visible = false;
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_KH kh = new QL_KH();
            kh.Show();
            this.Visible = false;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            QL_KH kh = new QL_KH();
            kh.Show();
            this.Visible = false;
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_NCC ncc = new QL_NCC();
            ncc.Show();
            this.Visible = false;
        }

     
        private void label24_Click_1(object sender, EventArgs e)
        {
            QL_NCC ncc = new QL_NCC();
            ncc.Show();
            this.Visible = false;
        }

        private void tạoMãQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateQR ncc = new CreateQR();
            ncc.Show();
            this.Visible = false;
        }

        private void label26_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
            this.Visible = false;
        }
    }
}
