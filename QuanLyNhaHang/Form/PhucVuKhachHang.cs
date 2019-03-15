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
    public partial class PhucVuKhachHang : Form
    {
        public void makeList_HoaDon()
        {
           // list_Hoadon.View = View.Details;
          //  list_Hoadon.Columns.Add("STT", 35, HorizontalAlignment.Center);
          //  list_Hoadon.Columns.Add("Tên món ăn",100, HorizontalAlignment.Center);
          //  list_Hoadon.Columns.Add("Số lượng", 100, HorizontalAlignment.Center);
          //  list_Hoadon.Columns.Add("Đơn giá", 100, HorizontalAlignment.Center);
          //  list_Hoadon.Columns.Add("Thành tiền", 100, HorizontalAlignment.Center);

        }
        public PhucVuKhachHang()
        {
            InitializeComponent();
            makeList_HoaDon(); 
        }

        private void list_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection table = this.list_table.SelectedItems;  
            foreach (ListViewItem item in table)
            {
                int x = item.Index;

            }
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

		private void PhucVuKhachHang_Load(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
