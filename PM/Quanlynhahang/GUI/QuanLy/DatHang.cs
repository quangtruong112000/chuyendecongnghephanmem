using DevComponents.DotNetBar.SuperGrid;
using GUI.Data;
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
    public partial class DatHang : Form
    {
        int b = 1;
        private Data.HangHoa hangHoa;
        QuanLyBanHang quan;
        LapPhieu lapPhieu1;
        CT_PhieuNhap cT_PhieuNhap;
        CT_PhieuXuat CT_PhieuXuat;
        int n1 = 0;
        public DatHang(LapPhieu lapPhieu,int MaHang)
        {
            InitializeComponent();
            LoadData(MaHang);
            lapPhieu1 = lapPhieu;
            textBox1.Text = "" + hangHoa.TenHang;
            textBox2.Text = "" + b;
        }


        public DatHang(LapPhieu lapPhieu, CT_PhieuNhap cT_Phieu ,int n )
        {
            InitializeComponent();
            LoadData(cT_Phieu.MaHang);
            lapPhieu1 = lapPhieu;
            b =(int) cT_Phieu.SoLuong;
            button3.Text = "Lưu";
            textBox2.Text = "" + b;
            cT_PhieuNhap = cT_Phieu;
            n1 = n;

        }
        public DatHang(LapPhieu lapPhieu, CT_PhieuXuat cT_Phieu, int n)
        {
            InitializeComponent();
            LoadData(cT_Phieu.MaHang);
            lapPhieu1 = lapPhieu;
            b = (int)cT_Phieu.SoLuong;
            button3.Text = "Lưu";
            textBox2.Text = "" + b;
            CT_PhieuXuat = cT_Phieu;
            n1 = n;

        }
        private void LoadData(int v)
        {
            quan = new QuanLyBanHang();
            hangHoa = quan.HangHoas.Find(v);
            textBox1.Text = "" + hangHoa.TenHang;
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
           
            if (button3.Text.Equals("Thêm")){
                lapPhieu1.ShowPhieu(hangHoa,textBox2.Text);
            }
            else
            {
                if (n1 == 0)
                {

                    cT_PhieuNhap.SoLuong = int.Parse(textBox2.Text);
                    lapPhieu1.UpdateCTPN(hangHoa, textBox2.Text, cT_PhieuNhap);
                }
                else
                {
                    CT_PhieuXuat.SoLuong = int.Parse(textBox2.Text);
                    lapPhieu1.UpdateCTPX(hangHoa, textBox2.Text, CT_PhieuXuat);
                }
                
            }
            this.Dispose();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (b > 0)
            {
                b++;
              
            }
            else
            {
                b = 1;
            }
            textBox2.Text = "" + b;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (b > 0)
            {
                b--;
            }
            else
            {
                b = 1;
            }
            textBox2.Text = "" + b;
        }
    }
}
