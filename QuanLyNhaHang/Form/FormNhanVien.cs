using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace QuanLyNhaHang
{
	public partial class FormNhanVien : Form
	{
        SqlConnection conn = new SqlConnection("Data Source = MSI; Initial Catalog = QuanLyNhaHang; Integrated Security = True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public FormNhanVien()
		{
			InitializeComponent();
            listView1.FullRowSelect = true;
            listView1.AllowColumnReorder = true;
            Show_DS();
		}
        private void ClearData()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtGT.Text = "";
            txtNS.Text = "";
            txtNVL.Text = "";
            txtCV.Text = "";
        }
        public void Show_DS()
        {
            this.listView1.SizeChanged += new EventHandler(ListView_SizeChanged);
            listView1.Items.Clear();
            listView1.View = View.Details;
            var dap = new SqlDataAdapter("SELECT * FROM QL_Nhanvien", conn);
            DataTable data = new DataTable();
            dap.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dt = data.Rows[i];
                ListViewItem lvi = new ListViewItem(dt["ID"].ToString());
                lvi.SubItems.Add(dt["name"].ToString());
                lvi.SubItems.Add(dt["sex"].ToString());
                lvi.SubItems.Add(dt["dateOfBirth"].ToString());
                lvi.SubItems.Add(dt["workDay"].ToString());                
                lvi.SubItems.Add(dt["phone"].ToString());
                lvi.SubItems.Add(dt["position"].ToString());
                lvi.SubItems.Add(dt["address"].ToString());
                listView1.Items.Add(lvi);
            }
            btnThem.Enabled = false;

        }

        private bool Resizing = false;

        private void ListView_SizeChanged(object sender, EventArgs e)
        {
            // Don't allow overlapping of SizeChanged calls
            if (!Resizing)
            {
                // Set the resizing flag
                Resizing = true;

                ListView listView = sender as ListView;
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    // Get the sum of all column tags
                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                    // Calculate the percentage of space each column should 
                    // occupy in reference to the other columns and then set the 
                    // width of the column to that percentage of the visible space.
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }

            // Clear the resizing flag
            Resizing = false;
        }
        
        
        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = txtMaNV.Text.Trim();
            if (txtMaNV.Text.Length == 8)
            {
                var dap = new SqlDataAdapter("SELECT * FROM QL_Nhanvien", conn);
                DataTable data = new DataTable();
                dap.Fill(data);
                bool ok = true;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (txtMaNV.Text.Equals(data.Rows[i]["Id"]))
                    {
                        ok = false;
                    }
                    
                }
                if (ok == true)
                {
                    btnThem.Enabled = true;
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                cmd = new SqlCommand("delete Ql_Nhanvien where ID=@id", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", txtMaNV.Text.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Deleted Successfully!");
                Show_DS();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                   cmd = new SqlCommand("update QL_Nhanvien set name=@name,sex=@sex, dateOfBirth=@dateOfBirth,workDay=@workDay, phone =@phone,position=@position, address=@address where ID=@id", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", txtMaNV.Text.ToString());
                cmd.Parameters.AddWithValue("@name", txtTenNV.Text.ToString());

                cmd.Parameters.AddWithValue("@sex", txtGT.Text.ToString());
                cmd.Parameters.AddWithValue("@dateOfBirth", Convert.ToDateTime(txtNS.Text.ToString()));
                cmd.Parameters.AddWithValue("@workDay", Convert.ToDateTime(txtNVL.Text.ToString()));
                cmd.Parameters.AddWithValue("@phone", txtSDT.Text.ToString());
                cmd.Parameters.AddWithValue("@position", txtCV.Text.ToString());
                cmd.Parameters.AddWithValue("@address", txtDiaChi.Text.ToString());
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                conn.Close();
                Show_DS();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                cmd = new SqlCommand("insert into QL_Nhanvien(Id,name,sex,dateOfBirth,workDay, phone, position, address)" +
                    " values(@Id,@name,@sex,@dateOfBirth,@workDay,@phone,@position,@address)" , conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@name", @txtTenNV.Text);
                cmd.Parameters.AddWithValue("@sex", @txtGT.Text);
                cmd.Parameters.AddWithValue("@dateOfBirth", Convert.ToDateTime(@txtNS.Text));
                cmd.Parameters.AddWithValue("@workDay", Convert.ToDateTime(@txtNVL.Text));
                cmd.Parameters.AddWithValue("@phone", @txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@position", @txtCV.Text);
                cmd.Parameters.AddWithValue("@address", @txtDiaChi.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inserted Successfully");
                ClearData();
                Show_DS();

            }
            else
            {
                btnThem.Enabled = false; 
            }

        }


        private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void FormNhanVien_Load(object sender, EventArgs e)
		{

		}

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach (ListViewItem items in listView1.SelectedItems)
            {
                txtMaNV.Text = items.SubItems[0].Text;
                txtTenNV.Text = items.SubItems[1].Text;
                txtGT.Text = items.SubItems[2].Text;
                txtNS.Text = items.SubItems[3].Text;
                txtNVL.Text = items.SubItems[4].Text;
                txtSDT.Text = items.SubItems[5].Text;
                txtCV.Text = items.SubItems[6].Text;
                txtDiaChi.Text = items.SubItems[7].Text;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
