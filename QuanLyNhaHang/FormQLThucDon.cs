using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyNhaHang
{
   
    public partial class FormQLThucDon : Form
	{
        SqlConnection conn = new SqlConnection("Data Source = MSI; Initial Catalog = QuanLyNhaHang; Integrated Security = True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public FormQLThucDon()
		{
			InitializeComponent();
            listView1.FullRowSelect = true;
            listView1.AllowColumnReorder = true;
            Show_DS();
		}
        private void ClearData()
        {
            txt_ID.Text = "";
            txt_name.Text = "";
            txt_onHand.Text = "";
            txt_price.Text = "";
            txt_type.Text = "";
        }
        public void Show_DS()
        {
            this.listView1.SizeChanged += new EventHandler(ListView_SizeChanged);
            listView1.Items.Clear();
            listView1.View = View.Details;
            var dap = new SqlDataAdapter("SELECT * FROM QL_Thucdon", conn);
            DataTable data = new DataTable();
            dap.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dt = data.Rows[i];
                ListViewItem lvi = new ListViewItem(dt["ID"].ToString());
                lvi.SubItems.Add(dt["name"].ToString());
                lvi.SubItems.Add(dt["price"].ToString());
                lvi.SubItems.Add(dt["onHand"].ToString());
                lvi.SubItems.Add(dt["type"].ToString());
                listView1.Items.Add(lvi);
            }
            btn_Them.Enabled = false;
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


        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text != "")
            {
                cmd = new SqlCommand("insert into QL_Thucdon(Id,name,price, onHand, type)" +
                    " values(@Id,@name,@price,@onHand,@type)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", txt_ID.Text);
                cmd.Parameters.AddWithValue("@name", @txt_name.Text);
                cmd.Parameters.AddWithValue("@price", int.Parse(txt_price.Text));
                cmd.Parameters.AddWithValue("@onHand", int.Parse(txt_onHand.Text));
                cmd.Parameters.AddWithValue("@type", @txt_type.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inserted Successfully");
                ClearData();
                Show_DS();

            }
            else
            {
                btn_Them.Enabled = false;
            }

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text != "")
            {
                cmd = new SqlCommand("update QL_Thucdon set name=@name,price=@price,onHand=@onHand, type=@type where ID=@id", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", txt_ID.Text.ToString());
                cmd.Parameters.AddWithValue("@name", txt_name.Text.ToString());

                cmd.Parameters.AddWithValue("@price", txt_price.Text.ToString());
                cmd.Parameters.AddWithValue("@onHand", txt_onHand.Text.ToString());
                cmd.Parameters.AddWithValue("@type", txt_type.Text.ToString());

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

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
        if (txt_ID.Text != "")
        {
            cmd = new SqlCommand("delete QL_Thucdon where ID=@id", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", txt_ID.Text.ToString());
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

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            txt_ID.Text = txt_ID.Text.Trim();
            if (txt_ID.Text.Length == 6)
            {
                var dap = new SqlDataAdapter("SELECT * FROM QL_Thucdon", conn);
                DataTable data = new DataTable();
                dap.Fill(data);
                bool ok = true;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (txt_ID.Text.Equals(data.Rows[i]["Id"]))
                    {
                        ok = false;
                    }

                }
                if (ok == true)
                {
                    btn_Them.Enabled = true;
                }
            }
            else btn_Them.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem items in listView1.SelectedItems)
            {
                txt_ID.Text = items.SubItems[0].Text;
                txt_name.Text = items.SubItems[1].Text;
                txt_price.Text = items.SubItems[2].Text;
                txt_onHand.Text = items.SubItems[3].Text;
                txt_type.Text = items.SubItems[4].Text;

            }
        }
    }
}
