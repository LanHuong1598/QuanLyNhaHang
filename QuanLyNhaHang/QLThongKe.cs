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
    public partial class QLThongke : Form
    {
        public QLThongke()
        {
            InitializeComponent();
            dtp_TuNgay.Format = DateTimePickerFormat.Custom;
            dtp_TuNgay.CustomFormat = " dd / MM / yyyy";
            dtp_DenNgay.Format = DateTimePickerFormat.Custom;
            dtp_DenNgay.CustomFormat = " dd / MM / yyyy";
            dtp_DenNgay.Value = DateTime.Now;
            listView_ThongKe.View = View.Details;
            listView_ThongKe.Columns.Add("STT", 50, HorizontalAlignment.Center);
            listView_ThongKe.Columns.Add("Ngày", 180, HorizontalAlignment.Center);
            listView_ThongKe.Columns.Add("Tên khách hàng", 250, HorizontalAlignment.Center);
            listView_ThongKe.Columns.Add("Thành tiền", 230, HorizontalAlignment.Center);
        }

        
    }
}
