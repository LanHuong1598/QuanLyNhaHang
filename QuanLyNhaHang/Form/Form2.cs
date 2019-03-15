using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            PhucVuKhachHang PhucVuKh = new PhucVuKhachHang();
            PhucVuKh.Show();
        }

		private void label2_Click(object sender, EventArgs e)
		{
			FormNhanVien QLNhanVien = new FormNhanVien();
			QLNhanVien.Show();
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void bunifuCustomLabel1_Click(object sender, EventArgs e)
		{
			FormHoaDon QLHoaDon = new FormHoaDon();
			QLHoaDon.Show();
		}

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            QLThongke qltk = new QLThongke();
            qltk.Show();
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            FormQLThucDon qltd = new FormQLThucDon();
            qltd.Show();

        }
    }

    
}
