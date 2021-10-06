using GUI.Data;
using Nhanvien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QuanLy
{
    public partial class LapPhieu : Form
    {
        List<Data.HangHoa> hangs;
        int n1 = 0;
        Kho kho1;
        public LapPhieu(int n ,Kho kho)
        {
            InitializeComponent();
            //panel1.Visible = false;
            hangs = new List<Data.HangHoa>();
            LoadDaTa();
            n1 = n;
            kho1= kho;
           
        }
     int   Check = -1;
     bool KiemTra =true;
        private void LoadDaTa()
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
            guna2DataGridView1.DataSource = quanLy.HangHoas.Select(X => X).ToList();
            guna2DataGridView1.Show();
            Check = -1;
            guna2DataGridView3.DataSource = hangs.ToList();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int ma = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                DatHang datHang = new DatHang(this, ma);
                datHang.ShowDialog();

            }
          
            //panel1.Visible = true;
        }

        internal void ShowPhieu(Data.HangHoa hangHoa, string text)
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
            if (n1 == 0)
            {
                if (KiemTra == true)
                {
                    try
                    {
                        label1.Text = "Thông Tin Phiếu Nhập ";
                        PhieuNhap phieuNhap = new PhieuNhap();
                        phieuNhap.Ma_PN = quanLy.PhieuNhaps.Select(x => x).ToList().Count + 1;
                        phieuNhap.NgayNhap = DateTime.Now;
                        phieuNhap.MaNV = kho1.trangChu1.nhanVien.MaNV1;
                        quanLy.PhieuNhaps.Add(phieuNhap);
                        quanLy.SaveChanges();
                        KiemTra = false;
                    }
                    catch 
                    {
                      
                    }

                }
                CT_PhieuNhap cT_PhieuNhap = new CT_PhieuNhap();
                try
                {
                    quanLy = new QuanLyBanHang();

                    cT_PhieuNhap.Ma_PN = quanLy.PhieuNhaps.Select(x => x).ToList()[quanLy.PhieuNhaps.Select(x => x).ToList().Count - 1].Ma_PN;
                    cT_PhieuNhap.MaHang = hangHoa.MaHang;
                    cT_PhieuNhap.SoLuong = int.Parse(text);
                    quanLy.CT_PhieuNhap.Add(cT_PhieuNhap);
                    quanLy.SaveChanges();
                    hangHoa.SOLUONG = text;
                    hangs.Add(hangHoa);

                }
                catch 
                {
                    UpdateCTHN1(hangHoa, text, cT_PhieuNhap);
                }
                LoadDaTa();

            }

            if (n1 == 1)
            {
                if (KiemTra == true)
                {
                    try
                    {
                        label1.Text = "Thông Tin Phiếu Xuất ";
                        PhieuXuat phieuNhap = new PhieuXuat();
                        phieuNhap.Ma_Phieu = quanLy.PhieuXuats.Select(x => x).ToList().Count + 1;
                        phieuNhap.NgayXuat = DateTime.Now;
                        phieuNhap.MaNV = kho1.trangChu1.nhanVien.MaNV1;
                        quanLy.PhieuXuats.Add(phieuNhap);
                        quanLy.SaveChanges();
                        KiemTra = false;
                    }
                    catch 
                    {
                       
                    }

                }
                CT_PhieuXuat cT_PhieuNhap = new CT_PhieuXuat();
                try
                {
                    quanLy = new QuanLyBanHang();

                    cT_PhieuNhap.Ma_PX = quanLy.PhieuXuats.Select(x => x).ToList()[quanLy.PhieuXuats.Select(x => x).ToList().Count - 1].Ma_Phieu;
                    cT_PhieuNhap.MaHang = hangHoa.MaHang;
                    cT_PhieuNhap.SoLuong = int.Parse(text);
                    quanLy.CT_PhieuXuat.Add(cT_PhieuNhap);
                    quanLy.SaveChanges();
                    hangHoa.SOLUONG = text;
                    hangs.Add(hangHoa);

                }
                catch 
                {
                    
                    UpdateCTHN(hangHoa,text, cT_PhieuNhap);
                }
                LoadDaTa();

            }

        }

        internal void UpdateCTPX(Data.HangHoa hangHoa, string text, CT_PhieuXuat ct1)
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
            var ct = quanLy.CT_PhieuXuat.SingleOrDefault(y => y.Ma_PX == ct1.Ma_PX && y.MaHang == hangHoa.MaHang);

            ct.SoLuong = ct1.SoLuong;
            quanLy.SaveChanges();
            for (int i = 0; i < hangs.Count; i++)
            {
                if (hangs[i].MaHang == (hangHoa.MaHang))
                {
                    hangs[i].SOLUONG = "" + ct.SoLuong;
                    break;
                }

            }
            LoadDaTa();

        }

        public void UpdateCTHN(Data.HangHoa hangHoa, string text, CT_PhieuXuat ct1)
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
            var ct = quanLy.CT_PhieuXuat.SingleOrDefault(y => y.Ma_PX == ct1.Ma_PX && y.MaHang == hangHoa.MaHang);

            ct.SoLuong = ct.SoLuong + ct1.SoLuong;
            quanLy.SaveChanges();
            for (int i = 0; i < hangs.Count; i++)
            {
                if (hangs[i].MaHang == (hangHoa.MaHang))
                {
                    hangs[i].SOLUONG = "" + ct.SoLuong;
                    break;
                }

            }
            LoadDaTa();
        }

        public void UpdateCTHN1(Data.HangHoa hangHoa, string text,CT_PhieuNhap ct1)
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
            var ct = quanLy.CT_PhieuNhap.SingleOrDefault(y => y.Ma_PN == ct1.Ma_PN && y.MaHang == hangHoa.MaHang);
             
            ct.SoLuong = ct.SoLuong + ct1.SoLuong;
            quanLy.SaveChanges();
            for (int i = 0; i < hangs.Count; i++)
            {
                if (hangs[i].MaHang==(hangHoa.MaHang))
                {
                    hangs[i].SOLUONG = ""+ct.SoLuong;
                    break;
                }

            }
            LoadDaTa();
        }

        public void UpdateCTPN(Data.HangHoa hangHoa, string text, CT_PhieuNhap ct1)
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
            var ct = quanLy.CT_PhieuNhap.SingleOrDefault(y => y.Ma_PN == ct1.Ma_PN && y.MaHang == hangHoa.MaHang);

            ct.SoLuong = ct1.SoLuong;
            quanLy.SaveChanges();
            for (int i = 0; i < hangs.Count; i++)
            {
                if (hangs[i].MaHang == (hangHoa.MaHang))
                {
                    hangs[i].SOLUONG = "" + ct.SoLuong;
                    break;
                }

            }
            LoadDaTa();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
       
            QuanLyBanHang quanLy = new QuanLyBanHang();

            if (n1 == 0)
            {
                var phieu = quanLy.PhieuNhaps.Select(x => x).ToList()[quanLy.PhieuNhaps.Select(x => x).ToList().Count - 1];

                var ct = quanLy.CT_PhieuNhap.Where(y => y.Ma_PN == phieu.Ma_PN).ToList();
                foreach (var item in ct)
                {
                    quanLy.CT_PhieuNhap.Remove(item);
                    quanLy.SaveChanges();

                }
                quanLy.PhieuNhaps.Remove(phieu);
                quanLy.SaveChanges();

            }
            if (n1 == 1)
            {
                var phieu = quanLy.PhieuXuats.Select(x => x).ToList()[quanLy.PhieuXuats.Select(x => x).ToList().Count - 1];

                var ct = quanLy.CT_PhieuXuat.Where(y => y.Ma_PX == phieu.Ma_Phieu).ToList();
                foreach (var item in ct)
                {
                    quanLy.CT_PhieuXuat.Remove(item);
                    quanLy.SaveChanges();

                }
                quanLy.PhieuXuats.Remove(phieu);
                quanLy.SaveChanges();

            }
            Kho kho = new Kho(kho1.trangChu1);
           kho1.trangChu1.AddForm(kho);

            this.Dispose();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            QuanLyBanHang quanLy = new QuanLyBanHang();
            if (n1 == 0)
            {
                var phieu = quanLy.PhieuNhaps.Select(x => x).ToList()[quanLy.PhieuNhaps.Select(x => x).ToList().Count - 1];
                Form1 phieu1 = new Form1(hangs, ""+phieu.Ma_PN,kho1.trangChu1.nhanVien,"Phiếu Nhập");
                phieu1.Show();
                UpdateHang();
            }
            if (n1 == 1)
            {
                var phieu = quanLy.PhieuXuats.Select(x => x).ToList()[quanLy.PhieuXuats.Select(x => x).ToList().Count - 1];
                Form1 phieu1 = new Form1(hangs, "" + phieu.Ma_Phieu, kho1.trangChu1.nhanVien, "Phiếu Xuất");
                phieu1.Show();
                UpdateHang1();

            }
        
        

            Kho kho = new Kho(kho1.trangChu1);
            kho1.trangChu1.AddForm(kho);


            Dispose();
        }

        private void UpdateHang1()
        {
            QuanLyBanHang quan = new QuanLyBanHang();
            foreach (var item in hangs)
            {
                var hangHoa = quan.HangHoas.Find(item.MaHang);
                hangHoa.SOLUONG = "" + (int.Parse(hangHoa.SOLUONG) - int.Parse(item.SOLUONG));
                quan.SaveChanges();
                Dispose();
            }
        }

        private void UpdateHang()
        {
            QuanLyBanHang quan = new QuanLyBanHang();
            foreach (var item in hangs)
            {
                var hangHoa = quan.HangHoas.Find(item.MaHang);
                hangHoa.SOLUONG = ""+(int.Parse(hangHoa.SOLUONG) + int.Parse(item.SOLUONG));
                quan.SaveChanges();
                Dispose();
            }
           
        }


        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (n1 == 0)
                {
                    QuanLyBanHang quanLy = new QuanLyBanHang();
                    var phieu = quanLy.PhieuNhaps.Select(x => x).ToList()[quanLy.PhieuNhaps.Select(x => x).ToList().Count - 1];
                    int ma = int.Parse(guna2DataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var ct = quanLy.CT_PhieuNhap.SingleOrDefault(y => y.Ma_PN == phieu.Ma_PN && y.MaHang == ma);
                    DatHang datHang = new DatHang(this, ct, n1);
                    datHang.ShowDialog();
                }
                else
                {
                    QuanLyBanHang quanLy = new QuanLyBanHang();
                    var phieu = quanLy.PhieuXuats.Select(x => x).ToList()[quanLy.PhieuXuats.Select(x => x).ToList().Count - 1];
                    int ma = int.Parse(guna2DataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var ct = quanLy.CT_PhieuXuat.SingleOrDefault(y => y.Ma_PX == phieu.Ma_Phieu && y.MaHang == ma);
                    DatHang datHang = new DatHang(this, ct, n1);
                    datHang.ShowDialog();

                }
            }

        }
    }
}
