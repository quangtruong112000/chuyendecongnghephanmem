using GUI.BUS;
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
    public partial class Formdangnhap : Form
    {
        public GUI.BUS.NhanVien nhanVien;
        private BUS.BLLNhanvien NhanvienDAL;

        GUI.BUS.Service1Client BLL = new GUI.BUS.Service1Client();
        public int Check { get; set; }
        private List<GUI.BUS.NhanVien> ListNhanVien;
        public Formdangnhap()
        {
            InitializeComponent();
            Check = 0;
            txbmatkhau.UseSystemPasswordChar = true;
            LoadData();
        }
        private void LoadData()
        {

            NhanvienDAL = new BLLNhanvien();
            ListNhanVien = new List<GUI.BUS.NhanVien>();
            foreach (var i in BLL.SelectNV())
            {
                ListNhanVien.Add(i);
            }
            /*foreach (DataRow item in BLL.SelectNV().Rows)
            {
                nhanVien = new GUI.BUS.NhanVien();
                nhanVien.MaNV1 = item["Manv"].ToString();
                nhanVien.Ten1 = item["Ten"].ToString();
                nhanVien.Chucvu1 = item["Chucvu"].ToString();
                nhanVien.MaKhau1 = item["Matkhau"].ToString();
                nhanVien.SDT1 = item["Gmail"].ToString();
                nhanVien.GioiTinh1 = item["Gioitinh"].ToString();
                ListNhanVien.Add(nhanVien);
            }*/
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0;
            if (txbtaikhoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn Vui Lòng Nhập Tên Đăng Nhập ");
                txbtaikhoan.Focus();
            }
            else if (txbmatkhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn Vui Lòng Nhập Mật Khẩu ");
                txbmatkhau.Focus();
            }
            if (txbtaikhoan.Text.Length > 0 && txbmatkhau.Text.Length > 0)
            {
                foreach (GUI.BUS.NhanVien item in ListNhanVien)
                {
                    if (txbtaikhoan.Text.Equals(item.MaNV1))
                    {
                        a++;
                        if (txbmatkhau.Text.Equals(item.MaKhau1))
                        {
                            b++;
                            TrangChu formtrangchu = new TrangChu(this,item);
                            formtrangchu.Show();   
                            a = 0;
                            b = 0;
                            LoadData();
                            this.Visible = false;
                            break;
                        }
                    }
                }
                if (a == 0)
                {
                   label3.Text = "Tên Đăng Nhập Không Đúng";
                    txbtaikhoan.Focus();
                }
                else if (b == 0)
                {
                    label3.Text = "Mật Khẩu Đăng Nhập Không Đúng";
                    txbmatkhau.Focus();

                }

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
