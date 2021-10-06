using GUI.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.QuanLy
{
    public partial class Formtrangchu : Form
    {

     private  BLLHoaDon bLLHoaDon = new BLLHoaDon();
        GUI.BUS.Service1Client BLL = new GUI.BUS.Service1Client();
        public Formtrangchu(QuanLyCafe.Gul.TrangChu trangChu)
        {
            InitializeComponent();
            LoadData();
            label7.Text = BLL.ThongkeHD();
            label2.Text += " " + trangChu.nhanVien.Ten1;
        }

        private void LoadData()
        {
            BLLNhanvien BLLNhanvien = new BLLNhanvien();
            /* label6.Text=""+ BLL.SelectNV().Rows.Count;*/
            label6.Text = "" + BLL.SelectNV().Length;


            BLLBan BLLBan = new BLLBan();
            label13.Text = "" + BLL.SelectBan().Length;
            label15.Text = "" + BLL.TongSoBan().Length;
       
          chart1.DataSource = BLL.TimKiemHoaDon5();
            chart1.Series["Salary"].XValueMember = " Ngày";
            chart1.Series["Salary"].YValueMembers = "doanhthu";
            chart1.Titles.Add("Bảng Doanh Thu Hàng");
            //Chuyển kiểu biểu đồ hình tròn
           // chart1.Series[0].ChartType = SeriesChartType.Pie;
       
        }

 

        private void guna2CustomGradientPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
