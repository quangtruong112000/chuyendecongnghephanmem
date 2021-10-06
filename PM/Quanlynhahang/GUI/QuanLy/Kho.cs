using GUI.Data;
using QuanLyCafe.Gul;
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
    public partial class Kho : Form
    {
      public  TrangChu trangChu1;
        public Kho( TrangChu trangChu)
        {
            InitializeComponent();
            LoadDaTa();
            trangChu1 = trangChu;
        }

        public void LoadDaTa()
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
           guna2DataGridView1.DataSource= quanLy.HangHoas.Select(X => X).ToList();
            guna2DataGridView1.Show();
            Check = -1;
        }

        int Check = -1;
        private void guna2Button21_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            HangHoa hangHoa = new HangHoa(this);
            hangHoa.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
              
                HangHoa hangHoa = new HangHoa(this, guna2DataGridView1.Rows[Check].Cells[0].Value.ToString());
                hangHoa.Show();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (Check > -1)
            {
                try
                {
                    int ma = int.Parse(guna2DataGridView1.Rows[Check].Cells[0].Value.ToString());
                    QuanLyBanHang quanLy = new QuanLyBanHang();
                    var hang = quanLy.HangHoas.Find(ma);
                    quanLy.HangHoas.Remove(hang);
                    quanLy.SaveChanges();
                    LoadDaTa();
                }catch
                {
                    MessageBox.Show("Sảy Ra lôi");
                }
               
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            LapPhieu lapPhieu = new LapPhieu(0,this);
            this.trangChu1.AddForm(lapPhieu);
          
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LapPhieu lapPhieu = new LapPhieu(1,this);
            this.trangChu1.AddForm(lapPhieu);

        }
    }
}
