using GUI.BUS;
using Nhanvien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QuanLy
{
    public partial class BanHang : Form
    {

        private Button[] buttona = new Button[200];
        private BLLBan BLLBan;
        public GUI.BUS.NhanVien nhanVien;
        GUI.BUS.Service1Client BLL = new GUI.BUS.Service1Client();
        public BanHang(GUI.BUS.NhanVien nhanvien )
        {
            InitializeComponent();
            TaoBan();
            this.nhanVien = nhanvien;
        }


        public void TaoBan()
        {
            int i = 0;
            flowLayoutPanel1.Controls.Clear();
            BLLBan = new BLLBan();
            /*DataTable table = BLL.SelectBan();*/
            foreach (var item in BLL.SelectBan())
            {
                Button button = new Button();
                button.Text = string.Format("" + item.TenBan.ToString());
                button.Name = string.Format("" + item.MaBan.ToString());
                button.Tag = string.Format("" + item.TrangThai.ToString());
                button.Size = new Size(60,50);
                flowLayoutPanel1.Controls.Add(button);
                button.Click += new EventHandler(SuLySuKien);
                buttona[i] = button;
                i++;
                string TinhTrang = item.TrangThai.ToString();
                if (TinhTrang.Contains("Tr"))
                {
                    button.BackColor = Color.FromArgb(0, 118, 212); 
                }
                else if (TinhTrang.Contains("Đang P"))
                {
                    button.BackColor = Color.Red;
                }
                else
                {
                    button.BackColor = Color.FromArgb(22, 152, 126);
                }
            }

        }

        private void SuLySuKien(object sender, EventArgs e)
        {
            int i = 0;
            GUI.BUS.Ban ban1 = new GUI.BUS.Ban();
            ban1.MaBan = Convert.ToInt32(((Button)sender).Name);
            ban1.TenBan = "" + ((Button)sender).Text;
            ban1.TrangThai = "" + ((Button)sender).Tag;
            panel1.Controls.Clear();
            BLLHoaDon hoaDon = new BLLHoaDon();
            /*DataTable dataTable = BLL.TimKiemHoaDon(ban1.MaBan);*/
            foreach (var item in BLL.TimKiemHoaDon(ban1.MaBan))
            {
                DatMon damon = new DatMon(ban1, this, 2, nhanVien);
                damon.TopLevel = false;
                panel1.Controls.Add(damon);
                damon.Show(); i++;
                break;
            }
            if (i == 0)
            {
                DatMon damon = new DatMon(ban1, this, 0, nhanVien);
                damon.TopLevel = false;
                panel1.Controls.Add(damon);
                damon.Show();
            }
        }
        private void UpDateBan(GUI.BUS.Ban ban1)
        {
            if (ban1.TrangThai.Contains("Tr"))
            {
                ban1.TrangThai = "Đang Đặt";
                BLL.UpdeteBan(ban1);
                TaoBan();
            }
            else if (ban1.TrangThai.Contains("Đang Đ"))
            {
                ban1.TrangThai = " Đang Trống ";
                BLL.UpdeteBan(ban1);
                TaoBan();
            }
            else
            {
                BLL.UpdeteBan(ban1);
                TaoBan();
            }
        }

        internal void refresh()
        {
            TaoBan();
        }
    }
}
