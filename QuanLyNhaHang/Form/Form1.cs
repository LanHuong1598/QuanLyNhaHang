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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=MSI;Initial Catalog=QuanLyNhaHang;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
		/*	var dap = new SqlDataAdapter("SELECT * FROM QuanLy", conn);
            DataTable data = new DataTable();
            dap.Fill(data);
            if(txt_user.Text=="" || txt_password.Text=="")
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (txt_user.Text == data.Rows[i]["user"].ToString() && txt_password.Text == data.Rows[i]["password"].ToString())
                {

					MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Hide();
                    Form2 fr2 = new Form2();
                    fr2.Show();
                  
                }
            }*/
            //MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
            
			/*SqlConnection conn = new SqlConnection("Data Source=DESKTOP-42NHODK;Initial Catalog=QuanLyNhaHang;Integrated Security=True");
			try
			{
				conn.Open();
				string tk = txt_user.Text;
				string mk = txt_password.Text;
				string sql = "select 'from QuanLyNhaHang where user= '" + tk + "and password='" + mk + "'";
				SqlCommand cmd = new SqlCommand(sql, conn);
				SqlDataReader data = cmd.ExecuteReader();
				if (data.Read() == true)// dọc 1 hang trong bang ghi
				{
					MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Form2 fr2 = new Form2();
					fr2.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi kết nối");
			}*/
		
		Form2 fr2 = new Form2();
            fr2.Show();
           // this.Hide();
        }

		private void txt_user_OnValueChanged(object sender, EventArgs e)
		{

		}

		private void txt_password_OnValueChanged(object sender, EventArgs e)
		{

		}
	}
}
