using DevComponents.DotNetBar;
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
    public partial class HangHoa : Form
    {
        Kho kho1;
        Data.HangHoa hang;
        QuanLyBanHang quan;
        public HangHoa(Kho kho)
        {
            InitializeComponent();
            kho1 = kho;
            hang = new Data.HangHoa();
            quan = new QuanLyBanHang();
        }
        public HangHoa(Kho kho, string v)
        {
            InitializeComponent();
            kho1 = kho;
            quan = new QuanLyBanHang();
            hang = new Data.HangHoa ();
            hang.MaHang = int.Parse(v);
            hang = quan.HangHoas.Find(hang.MaHang);
            textBox1.Text=""+ hang.TenHang;
           textBox2.Text = "" + hang.DVT;
            button3.Text = "Sữa";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
          
           
        
        }

        private void button3_Click(object sender, EventArgs e)
        {

            hang.TenHang = textBox1.Text;
            hang.DVT = textBox2.Text;

            if (button3.Text.Equals("Thêm"))
            {
                hang.SOLUONG = "" + 0;
                hang.MaHang = quan.HangHoas.Select(x => x).ToList().Count + 1;
                quan.HangHoas.Add(hang);
                quan.SaveChanges();
                kho1.LoadDaTa();
                Dispose();

            }
            else
            {
                var hangHoa = quan.HangHoas.Find(hang.MaHang);
                hangHoa.TenHang = textBox1.Text;
                hangHoa.DVT = textBox2.Text;
                quan.SaveChanges();
                kho1.LoadDaTa();
                Dispose();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
