using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BUS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        //DTO

        public Ban DTOBAN(Ban ban)
        {
            throw new NotImplementedException();
        }

        public ChiTietHoaDon DTOchitiethoadon(ChiTietHoaDon chitiethoadon)
        {
            throw new NotImplementedException();
        }

        public Gmail DTOGMAIL(Gmail gmail)
        {
            throw new NotImplementedException();
        }

        public HoaDon DTOHOAODN(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }

        public NhanVien DTONHANVIEN(NhanVien nhanVien)
        {
            throw new NotImplementedException();
        }

        public NhomMon DTONHOMMON(NhomMon Nhommon)
        {
            throw new NotImplementedException();
        }

        public ThucDon DTOTHUCDON(ThucDon thucDon)
        {
            throw new NotImplementedException();
        }


        public string[] RGB(NhomMon Nhommon)
        {
            
            return Nhommon.RGB();

        }

        public int TinhTienGiam(int n, List<ChiTietHoaDon> chitet)
        {
            HoaDon hoaDon = new HoaDon(); ;
            return hoaDon.TinhTienGiam(n, chitet);
        }

        public int TONGTIEN(List<ChiTietHoaDon> chitet )
        {
            HoaDon hoaDon = new HoaDon(); ;
            return hoaDon.TONGTIEN(chitet);
        }
        public void Send(string Gmail,Gmail sendmail)
        {
            sendmail.Send(Gmail);
        }


        //BUS

        public BLLBan BLLBAN(BLLBan N)
        {
            throw new NotImplementedException();
        }

        public BLLChiTietHD BLLCTHD(BLLChiTietHD N)
        {
            throw new NotImplementedException();
        }

        public BLLHoaDon BLLHOADON(BLLHoaDon N)
        {
            throw new NotImplementedException();
        }

        public BLLNhanvien BLLNHANVIEN(BLLNhanvien N)
        {
            throw new NotImplementedException();
        }

        public BLLNhomMon BLLNHOMMON(BLLNhomMon N)
        {
            throw new NotImplementedException();
        }

        public BLLThucDon BLLTHUCDON(BLLThucDon N)
        {
            throw new NotImplementedException();
        }

        public BLLThucDonPhaChe BLLTDPC(BLLThucDonPhaChe N)
        {
            throw new NotImplementedException();
        }

        //bllban
        public List<Ban> SelectBan()
        {
            BLLBan ban=new BLLBan();
            /*return ban.SelectBan();*/
            List<Ban> listban=new List<Ban>();
            foreach (DataRow item in ban.SelectBan().Rows)
            {
                Ban ban1 = new Ban();
                ban1.MaBan =Convert.ToInt32( item["MaBan"].ToString());
                ban1.TenBan = item["TenBan"].ToString();
                ban1.TrangThai = item["TrangThai"].ToString();
                listban.Add(ban1);
            }
            return listban;
        }

        public List<Ban> TongSoBan()
        {
            BLLBan ban = new BLLBan();
            /* return ban.TongSoBan();*/
            List<Ban> listban = new List<Ban>();
            foreach (DataRow item in ban.TongSoBan().Rows)
            {
                Ban ban1 = new Ban();
                ban1.MaBan = Convert.ToInt32(item["MaBan"].ToString());
                ban1.TenBan = item["TenBan"].ToString();
                ban1.TrangThai = item["TrangThai"].ToString();
                listban.Add(ban1);
            }
            return listban;
        }

        public int InsertBan(Ban ban)
        {
            BLLBan balban = new BLLBan();
             return balban.InsertBan(ban);
        }

        public int UpdeteBan(Ban ban)
        {
            BLLBan balban = new BLLBan();
            return balban.UpdeteBan(ban);
        }
        public int DeleteBan(Ban ban)
        {
            BLLBan balban = new BLLBan();
            return balban.DeleteBan(ban);
        }
        //bllchitiethd


        public List<ChiTietHoaDon> GetChiTietHD()
        {
            BLLChiTietHD chiTietHD=new BLLChiTietHD();
            /*return chiTietHD.GetChiTietHD();*/
            List<ChiTietHoaDon> listchitiet = new List<ChiTietHoaDon>();
           
                foreach (DataRow item in chiTietHD.GetChiTietHD().Rows)
                {
                    ChiTietHoaDon ChiTietHoaDon = new ChiTietHoaDon();
                    ChiTietHoaDon.MaCTHD = item["MaChiTietHD"].ToString();
                    ChiTietHoaDon.MAHD = item["MaHD"].ToString();
                    ChiTietHoaDon.SOLUONG = Convert.ToInt32(item["SoLuong"].ToString());
                    listchitiet.Add(ChiTietHoaDon);
                }
            
            
            
            return listchitiet;

        }

        public List<ChiTietHoaDon> TimKiemCTHD(int timkiem)
        {
            BLLChiTietHD chiTietHD = new BLLChiTietHD();
            /*return chiTietHD.TimKiemCTHD(timkiem);*/
            List<ChiTietHoaDon> listchitiet = new List<ChiTietHoaDon>();
            foreach (DataRow item in chiTietHD.TimKiemCTHD(timkiem).Rows)
            {
                ChiTietHoaDon ChiTietHoaDon = new ChiTietHoaDon();
                ChiTietHoaDon.MaCTHD = item["MaChiTietHD"].ToString();
                ChiTietHoaDon.MAHD = item["MaHD"].ToString();
                ChiTietHoaDon.SOLUONG = Convert.ToInt32(item["SoLuong"].ToString());
                listchitiet.Add(ChiTietHoaDon);
            }
            return listchitiet;

        }



        public int InsetCTHD(ChiTietHoaDon chiTiet)
        {
            BLLChiTietHD chiTietHD = new BLLChiTietHD();
            return chiTietHD.InsetCTHD(chiTiet);

        }
        public int UpdateCTHD(ChiTietHoaDon chiTiet)
        {
            BLLChiTietHD chiTietHD = new BLLChiTietHD();
            return chiTietHD.UpdateCTHD(chiTiet);

        }
        public int UpdateCTHD2(string MaHd)
        {
            BLLChiTietHD chiTietHD = new BLLChiTietHD();
            return chiTietHD.UpdateCTHD2(MaHd);


        }


        public int DeleteCTHD(string thucDon)
        {
            BLLChiTietHD chiTietHD = new BLLChiTietHD();
            return chiTietHD.DeleteCTHD(thucDon);

        }

        //bllhoadon


        public List<HoaDon> TimKiemHoaDon5()
        {
              BLLHoaDon hoason = new BLLHoaDon();
           /* return hoason.TimKiemHoaDon5();*/
            List<HoaDon> listhoadon = new List<HoaDon>();
            foreach (DataRow item in hoason.TimKiemHoaDon5().Rows)
            {
                HoaDon HoaDon = new HoaDon();
                
                HoaDon.TongTien1 = Convert.ToInt32(item["doanhthu"].ToString());
                HoaDon.NgayDen = Convert.ToDateTime(item["Ngày"].ToString());
                listhoadon.Add(HoaDon);
            }
            return listhoadon;





        }

        public string ThongkeHD()
        {
            BLLHoaDon hoason = new BLLHoaDon();
            return hoason.ThongkeHD();

        }

        public List<HoaDon> GetHD()
        {
            BLLHoaDon hoason = new BLLHoaDon();
            /*return hoason.GetHD();*/

            List<HoaDon> listhoadon = new List<HoaDon>();
            foreach (DataRow item in hoason.GetHD().Rows)
            {
                HoaDon HoaDon = new HoaDon();
                HoaDon.MAHD = item["MaHD"].ToString();
                HoaDon.GIAMGIA = Convert.ToInt32(item["GiamGia"].ToString());
                HoaDon.NgayDen = Convert.ToDateTime(item["GioDen"].ToString());
                listhoadon.Add(HoaDon);
            }
            return listhoadon;

        }


        public int InsetHD(HoaDon hoaDon, string MANV)
        {
            BLLHoaDon hoason = new BLLHoaDon();
            return hoason.InsetHD(hoaDon, MANV);




        }

        public List<HoaDon> TimKiemHoaDon1(DateTime time1, DateTime time2)
        {
            BLLHoaDon hoason = new BLLHoaDon();
           /* return hoason.TimKiemHoaDon1(time1, time2);*/


            List<HoaDon> listhoadon = new List<HoaDon>();
            foreach (DataRow item in hoason.TimKiemHoaDon1(time1, time2).Rows)
            {
                HoaDon HoaDon = new HoaDon();
                /*if(item["Tongtien"].ToString().Replace(" ", "") == "")
                {
                    HoaDon.TongTien1 = 0;
                }
                else
                {
                    HoaDon.TongTien1 = Convert.ToInt32(item["Tongtien"].ToString());
                }
                if (item["GiamGia"].ToString().Replace(" ", "") == "")
                {
                    HoaDon.GIAMGIA = 0;
                }
                else
                {
                    HoaDon.GIAMGIA = Convert.ToInt32(item["GiamGia"].ToString());
                }*/
                try
                {
                HoaDon.TongTien1 = Convert.ToInt32(item["Tongtien"].ToString());
                HoaDon.GIAMGIA = Convert.ToInt32(item["GiamGia"].ToString());
                }
                catch (Exception)
                {

                }
                

                listhoadon.Add(HoaDon);
            }
            return listhoadon;


        }


        public List<HoaDon> TongSoHd(DateTime time1, DateTime time2)
        {
            BLLHoaDon hoason = new BLLHoaDon();
            /*return hoason.TongSoHd(time1, time2);*/

            List<HoaDon> listhoadon = new List<HoaDon>();
            foreach (DataRow item in hoason.TongSoHd(time1, time2).Rows)
            {
                HoaDon HoaDon = new HoaDon();
                HoaDon.Soluong = Convert.ToInt32(item["SOLUONG"].ToString());
                listhoadon.Add(HoaDon);
            }
            return listhoadon;
        }

        public List<HoaDon> TimKiemHoaDon2(DateTime time1, DateTime time2)
        {
            BLLHoaDon hoason = new BLLHoaDon();
           /* return hoason.TimKiemHoaDon2(time1, time2);*/

            List<HoaDon> listhoadon = new List<HoaDon>();
            foreach (DataRow item in hoason.TimKiemHoaDon2(time1, time2).Rows)
            {
                HoaDon HoaDon = new HoaDon();
                HoaDon.MAHD = item["MaHD"].ToString();
                HoaDon.GIAMGIA = Convert.ToInt32(item["GiamGia"].ToString());
                /*HoaDon.BAN.MaBan = Convert.ToInt32(item["MaBan"].ToString());*/
                HoaDon.NgayDen = Convert.ToDateTime(item["GioDen"].ToString());
                HoaDon.TongTien1 = Convert.ToInt32(item["TongTien"].ToString());
                /*HoaDon.BAN.TrangThai = item["TrangThai"].ToString();*/
                listhoadon.Add(HoaDon);
            }
            return listhoadon;


        }


        public List<ChiTietHoaDon> TimKiemHoaDon(int maBan)
        {
            BLLHoaDon hoason = new BLLHoaDon();
            /*return hoason.TimKiemHoaDon(maBan);*/
            List<ChiTietHoaDon> listchitiet = new List<ChiTietHoaDon>();
            foreach (DataRow item in hoason.TimKiemHoaDon(maBan).Rows)
            {
                ChiTietHoaDon HoaDon = new ChiTietHoaDon();
                HoaDon = new ChiTietHoaDon();
                HoaDon.MaCTHD = item["MachitietHD"].ToString();
                HoaDon.MAHD = item["MaHD"].ToString();
                HoaDon.Thucdon = new ThucDon();
                HoaDon.Thucdon.MAMON = Convert.ToInt32(item["MaMON"].ToString());
                HoaDon.SOLUONG = Convert.ToInt32(item["SOLUONG"].ToString());
                HoaDon.Thucdon.DONGIA = Convert.ToInt32(item["DONGIA"].ToString());
                HoaDon.Thucdon.tenmon = item["TENMON"].ToString();
                HoaDon.Thucdon.DVT = item["DVT"].ToString();/*
                HoaDon.Hoadon.NgayDen= Convert.ToDateTime(item["GIODEN"].ToString());*/
                /*HoaDon.Hoadon.MAHD. = HoaDon.MAHD;*/
                listchitiet.Add(HoaDon);
                
            }
            return listchitiet;


        }

        public int InsetHD1(HoaDon hoaDon)
        {
            BLLHoaDon hoason = new BLLHoaDon();
            return hoason.InsetHD1(hoaDon);

        }


        public int UpdateHD(HoaDon hoaDon)
        {
            BLLHoaDon hoason = new BLLHoaDon();
            return hoason.UpdateHD(hoaDon);

        }
        public int DeleteHD(int hoaDon)
        {
            BLLHoaDon hoason = new BLLHoaDon();
            return hoason.DeleteHD(hoaDon);
        }

        //bllnhanvien
        public List<NhanVien> SelectNV()
        {
            BLLNhanvien nhanvien=new BLLNhanvien();
            /* return nhanvien.SelectNV();*/


            List<NhanVien> nv = new List<NhanVien>();
            foreach (DataRow item in nhanvien.SelectNV().Rows)
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.MaNV1 = item["Manv"].ToString();
                nhanVien.Ten1 = item["Ten"].ToString();
                nhanVien.Chucvu1 = item["Chucvu"].ToString();
                nhanVien.MaKhau1 = item["Matkhau"].ToString();
                nhanVien.SDT1 = item["Gmail"].ToString();
                nhanVien.GioiTinh1 = item["Gioitinh"].ToString();
                nv.Add(nhanVien);
            }
            return nv;





        }
        public int InsertIntoNV(NhanVien nhanVien)
        {
            BLLNhanvien nhanvien = new BLLNhanvien();
            return nhanvien.InsertIntoNV(nhanVien);
        }
        public int UpdateNV(NhanVien nhanVien)
        {
            BLLNhanvien nhanvien = new BLLNhanvien();
            return  nhanvien.UpdateNV(nhanVien);
        }

        public int DeleteNV(string MANV)
        {
            BLLNhanvien nhanvien = new BLLNhanvien();
            return  nhanvien.DeleteNV(MANV);
        }

        //bllnhommon
        public List<NhomMon> SelectNhomMon()
        {
            BLLNhomMon nhommon=new BLLNhomMon();
            /*return nhommon.SelectNhomMon();*/
            List<NhomMon> listnhommon=new List<NhomMon>();
            foreach(DataRow item in nhommon.SelectNhomMon().Rows)
            {
                NhomMon nhom=new NhomMon();
                nhom.Maloai = Convert.ToInt32(item["MaLoai"].ToString());
                nhom.Tenloai = item["TenLoai"].ToString();
                nhom.MAU = item["MauSac"].ToString();
                listnhommon.Add(nhom);
            }
            
            return listnhommon;


        }
        public List<NhomMon> TongNhomMon()
        {
            BLLNhomMon nhommon = new BLLNhomMon();
            /*return nhommon.TongNhomMon();*/
            List<NhomMon>  listnhom=new List<NhomMon>();
            foreach (DataRow item in nhommon.TongNhomMon().Rows)
            {
                NhomMon nhom=new NhomMon();
                nhom.Soluong = Convert.ToInt32( item["SOLUONG"].ToString());
                listnhom.Add(nhom);
            }
            return listnhom;
        }
        public int InsertNhomMon(NhomMon nhom)
        {
            BLLNhomMon nhommon = new BLLNhomMon();
            return nhommon.InsertNhomMon(nhom);
        }
        public int UpdateNhomMon(NhomMon nhom)
        {
            BLLNhomMon nhommon = new BLLNhomMon();
            return nhommon.UpdateNhomMon(nhom);
        }
        public int DeleteNhomMon(NhomMon nhom)
        {
            BLLNhomMon nhommon = new BLLNhomMon();
            return nhommon.DeleteNhomMon(nhom);

        }

        public List<NhomMon> TimKiemNhomMon(string nhom)
        {
            BLLNhomMon nhommon = new BLLNhomMon();
            /*return nhommon.TimKiemNhomMon(nhom);*/
            List<NhomMon> listnhommon = new List<NhomMon>();
            foreach (DataRow item in nhommon.TimKiemNhomMon(nhom).Rows)
            {
                NhomMon nhom1 = new NhomMon();
                nhom1.Maloai = Convert.ToInt32(item["MaLoai"].ToString());
                nhom1.Tenloai = item["TenLoai"].ToString();
                nhom1.MAU = item["MauSac"].ToString();
                listnhommon.Add(nhom1);
            }

            return listnhommon;
        }

        //bllthucdon

        public List<ThucDon> SelectThucDon()
        {
            BLLThucDon thucdon=new BLLThucDon();
            /*return thucdon.SelectThucDon();*/

            List < ThucDon > listthucdon=new List<ThucDon>();

            foreach (DataRow item in thucdon.SelectThucDon().Rows)
            {
                ThucDon thucDon = new ThucDon();
                thucDon.MAMON = (Convert.ToInt32(item["MaMon"].ToString()));
                thucDon.NhomMon.Maloai = (Convert.ToInt32(item["MaLoai"].ToString()));
                thucDon.tenmon = item["TenMon"].ToString();
                thucDon.DONGIA = (Convert.ToInt32(item["DonGia"].ToString()));
                thucDon.DVT = item["DVT"].ToString();
                listthucdon.Add(thucDon);
            }
            return listthucdon;
        }
        public List<ThucDon> TongSoMon()
        {
            BLLThucDon thucdon = new BLLThucDon();
            /* return thucdon.TongSoMon();*/
            List<ThucDon> listthucdon = new List<ThucDon>();
            foreach (DataRow item in thucdon.TongSoMon().Rows)
            {
                ThucDon thucDon = new ThucDon();
                thucDon.Soluong = (Convert.ToInt32(item["SOLUONG"].ToString()));
               
                listthucdon.Add(thucDon);

            }
            return listthucdon;

        }


        public List<ThucDon> SelectThucDon1(DateTime time1, DateTime time2)
        {
            BLLThucDon thucdon = new BLLThucDon();
            /*return thucdon.SelectThucDon1(time1, time2);*/
            List<ThucDon> listthucdon = new List<ThucDon>();
            foreach (DataRow item in thucdon.SelectThucDon1(time1, time2).Rows)
            {
                ThucDon thucDon= new ThucDon();
                 thucDon.MAMON= (Convert.ToInt32(item["MaMon"].ToString()));
                thucDon.tenmon = item["TenMon"].ToString();
                thucDon.NhomMon.Maloai = (Convert.ToInt32(item["Maloai"].ToString()));
                thucDon.Soluong = (Convert.ToInt32(item["SOLUONG"].ToString()));
                listthucdon.Add(thucDon);
            }
            return listthucdon;



        }

        public List<ThucDon> SelectThucDon2(DateTime time1, DateTime time2)
        {
            BLLThucDon thucdon = new BLLThucDon();
            /* return thucdon.SelectThucDon2(time1, time2);*/

            List<ThucDon> listthucdon = new List<ThucDon>();
            foreach (DataRow item in thucdon.SelectThucDon2(time1, time2).Rows)
            {
                ThucDon thucDon = new ThucDon();
                try
                {

                
                thucDon.Soluong = (Convert.ToInt32(item["SOLUONG"].ToString()));}
                catch (Exception) {   }
                listthucdon.Add(thucDon);
            }
            return listthucdon;
        }

        public int InsetThucDon(ThucDon thucDon)
        {
            BLLThucDon thucdon = new BLLThucDon();

            return  thucdon.InsetThucDon(thucDon);
        }

        public int UpdateThucDon(ThucDon thucDon)
        {
            BLLThucDon thucdon = new BLLThucDon();
            return  thucdon.UpdateThucDon(thucDon);
        }

        public int DeleteThucDon(ThucDon thucDon)
        {
            BLLThucDon thucdon = new BLLThucDon();
            return  thucdon.DeleteThucDon(thucDon);

        }



        public List<ThucDon> TimKiemThucDon(string Name)
        {
            BLLThucDon thucdon = new BLLThucDon();
            /*return thucdon.TimKiemThucDon(Name);*/

            List<ThucDon> list = new List<ThucDon>();
            foreach (DataRow item in thucdon.TimKiemThucDon(Name).Rows)
            {
                ThucDon thucDon = new ThucDon();

                thucDon.MAMON = Convert.ToInt32(item["MaMon"].ToString());
                thucDon.DONGIA = Convert.ToInt32(item["DonGia"].ToString());
                thucDon.tenmon = item["TenMon"].ToString();
                thucDon.DVT = item["DVT"].ToString();
                thucDon.NhomMon.Maloai = Convert.ToInt32(item["MaLoai"]);
                list.Add(thucDon);
            }
            return list;
        }

        public List<ThucDon> TimKiemThucDon2(string Name)
        {
            BLLThucDon thucdon = new BLLThucDon();
            /*return thucdon.TimKiemThucDon2(Name);*/

            List<ThucDon> list = new List<ThucDon>();
            foreach (DataRow item in thucdon.TimKiemThucDon2(Name).Rows)
            {
                ThucDon thucDon = new ThucDon();

                thucDon.MAMON = Convert.ToInt32(item["MAMON"].ToString());
                thucDon.DONGIA = Convert.ToInt32(item["DONGIA"].ToString());
                thucDon.tenmon = item["TENMON"].ToString();
                thucDon.DVT = item["DVT"].ToString();
                list.Add(thucDon);
            }
            return list;
        }
        public List<ThucDon> TimKiemThucDon1(string ten)
        {
            BLLThucDon thucdon = new BLLThucDon();
            /*return thucdon.TimKiemThucDon1(ten);*/
            List<ThucDon> list = new List<ThucDon>();
            foreach (DataRow item in thucdon.TimKiemThucDon1(ten).Rows)
            {
                ThucDon thucDon = new ThucDon();

                thucDon.MAMON = Convert.ToInt32(item["MaMon"].ToString());
                thucDon.DONGIA = Convert.ToInt32(item["DonGia"].ToString());
                thucDon.tenmon = item["TenMon"].ToString();
                thucDon.DVT = item["DVT"].ToString();
                thucDon.NhomMon.Maloai = Convert.ToInt32(item["MaLoai"]);
                list.Add(thucDon);
            }
            return list;
        }


        //bllthucdonphache
        public List<ChiTietHoaDon> SelectTDPC()
        {
           
            BLLThucDonPhaChe thucDonPhaChe=new BLLThucDonPhaChe();
            /*return thucDonPhaChe.SelectTDPC();*/
            List<ChiTietHoaDon> chitiet = new List<ChiTietHoaDon>();
            foreach (DataRow i in thucDonPhaChe.SelectTDPC().Rows)
            {
                ChiTietHoaDon chiTietHoaDon= new ChiTietHoaDon();
                chiTietHoaDon.MaCTHD= i["MaChiTietHD"].ToString();
                chiTietHoaDon.Thucdon.tenmon = i["TenMon"].ToString();
                chiTietHoaDon.Thucdon.Soluong = Convert.ToInt32(i["SoLuong"].ToString());
                chiTietHoaDon.tenNV = i["TEN"].ToString();
                chiTietHoaDon.Hoadon.BAN.TenBan = i["TenBan"].ToString();
                chiTietHoaDon.Hoadon.BAN.TrangThai = i["TrangThai"].ToString();
                chitiet.Add(chiTietHoaDon);

            }


            return chitiet;

        }

        public List<ChiTietHoaDon> SelectTDPC1()
        {
            BLLThucDonPhaChe thucDonPhaChe = new BLLThucDonPhaChe();
            /*return thucDonPhaChe.SelectTDPC1();*/
            List<ChiTietHoaDon> chitiet = new List<ChiTietHoaDon>();
            foreach (DataRow i in thucDonPhaChe.SelectTDPC1().Rows)
            {
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
                chiTietHoaDon.MaCTHD = i["MaChiTietHD"].ToString();
                chiTietHoaDon.Thucdon.tenmon = i["TenMon"].ToString();
                chiTietHoaDon.Thucdon.Soluong = Convert.ToInt32(i["SoLuong"].ToString());
                chiTietHoaDon.tenNV = i["TEN"].ToString();
                chiTietHoaDon.Hoadon.BAN.TenBan = i["TenBan"].ToString();
                chiTietHoaDon.Hoadon.BAN.TrangThai = i["TrangThai"].ToString();
                chitiet.Add(chiTietHoaDon);

            }


            return chitiet;
        }


        public int InSertTDPC(HoaDon hoaDon, string nv)
        {
            BLLThucDonPhaChe thucDonPhaChe = new BLLThucDonPhaChe();
            return thucDonPhaChe.InSertTDPC(hoaDon, nv);
        }

        public int UpdeteTDPC(string check)
        {
            BLLThucDonPhaChe thucDonPhaChe = new BLLThucDonPhaChe();
            return thucDonPhaChe.UpdeteTDPC(check);

        }

        
    }
}
