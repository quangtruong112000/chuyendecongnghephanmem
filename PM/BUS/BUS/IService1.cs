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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //DTO

        [OperationContract]
        Ban DTOBAN(Ban ban);
        [OperationContract]
        ChiTietHoaDon DTOchitiethoadon(ChiTietHoaDon chitiethoadon);
        [OperationContract]
        Gmail DTOGMAIL(Gmail gmail);
        [OperationContract]
        HoaDon DTOHOAODN(HoaDon hoaDon);
        [OperationContract]
        NhanVien DTONHANVIEN(NhanVien nhanVien);
        [OperationContract]
        NhomMon DTONHOMMON(NhomMon Nhommon);
        [OperationContract]
        ThucDon DTOTHUCDON(ThucDon thucDon);
        [OperationContract]
        string[] RGB(NhomMon Nhommon);
        [OperationContract]
        int TONGTIEN(List<ChiTietHoaDon> chitet);
        [OperationContract]
         int TinhTienGiam(int n, List<ChiTietHoaDon> chitet);
        [OperationContract]
        void Send(string Gmail, Gmail sendmail);


        //bUS

        [OperationContract]
        BLLBan BLLBAN(BLLBan N);
        [OperationContract]
        BLLChiTietHD BLLCTHD(BLLChiTietHD N);
        [OperationContract]
        BLLHoaDon BLLHOADON(BLLHoaDon N);
        [OperationContract]
        BLLNhanvien BLLNHANVIEN(BLLNhanvien N);
        [OperationContract]
        BLLNhomMon BLLNHOMMON(BLLNhomMon N);
        [OperationContract]
        BLLThucDon BLLTHUCDON(BLLThucDon N);
        [OperationContract]
        BLLThucDonPhaChe BLLTDPC(BLLThucDonPhaChe N);
        
        //bllban
        [OperationContract]
        List<Ban> SelectBan();
        [OperationContract]
        List<Ban> TongSoBan();
        [OperationContract]
        int InsertBan(Ban ban);
        [OperationContract]
        int UpdeteBan(Ban ban);
        [OperationContract]
        int DeleteBan(Ban ban);

        //bllchitiethd
        [OperationContract]
        List<ChiTietHoaDon> GetChiTietHD();
        [OperationContract]
        List<ChiTietHoaDon> TimKiemCTHD(int timkiem);
        [OperationContract]
        int InsetCTHD(ChiTietHoaDon chiTiet);
        [OperationContract]
        int UpdateCTHD(ChiTietHoaDon chiTiet);
        [OperationContract]
        int UpdateCTHD2(string MaHd);
        [OperationContract]
        int DeleteCTHD(string thucDon);
        //bllhoadon
        [OperationContract]
        List<HoaDon> TimKiemHoaDon5();
        [OperationContract]
        string ThongkeHD();
        [OperationContract]
        List<HoaDon> GetHD();
        [OperationContract]

        int InsetHD(HoaDon hoaDon, string MANV);
        [OperationContract]
        List<HoaDon> TimKiemHoaDon1(DateTime time1, DateTime time2);
        [OperationContract]

        List<HoaDon> TongSoHd(DateTime time1, DateTime time2);
        [OperationContract]
        List<HoaDon> TimKiemHoaDon2(DateTime time1, DateTime time2);
        [OperationContract]

        List<ChiTietHoaDon> TimKiemHoaDon(int maBan);
        [OperationContract]
        int InsetHD1(HoaDon hoaDon);
        [OperationContract]
        int UpdateHD(HoaDon hoaDon);
        [OperationContract]
        int DeleteHD(int hoaDon);

        //bllnhanvien
        [OperationContract]
        List<NhanVien> SelectNV();
        [OperationContract]
        int InsertIntoNV(NhanVien nhanVien);
        [OperationContract]
        int UpdateNV(NhanVien nhanVien);
        [OperationContract]
        int DeleteNV(string MANV);

        //bllnhommon
        [OperationContract]
        List<NhomMon> SelectNhomMon();
        [OperationContract]
        List<NhomMon> TongNhomMon();
        [OperationContract]
        int InsertNhomMon(NhomMon nhom);
        [OperationContract]
        int UpdateNhomMon(NhomMon nhom);
        [OperationContract]
        int DeleteNhomMon(NhomMon nhom);
        [OperationContract]
        List<NhomMon> TimKiemNhomMon(string nhom);
        //bllthucdon
        [OperationContract]
        List<ThucDon> SelectThucDon();
        [OperationContract]
        List<ThucDon> TongSoMon();
        [OperationContract]

        List<ThucDon> SelectThucDon1(DateTime time1, DateTime time2);
        [OperationContract]
        List<ThucDon> SelectThucDon2(DateTime time1, DateTime time2);
        [OperationContract]
        int InsetThucDon(ThucDon thucDon);
        [OperationContract]
        int UpdateThucDon(ThucDon thucDon);
        [OperationContract]
        int DeleteThucDon(ThucDon thucDon);

        [OperationContract]

        List<ThucDon> TimKiemThucDon(string Name);
        [OperationContract]
        List<ThucDon> TimKiemThucDon2(string Name);
        [OperationContract]
        List<ThucDon> TimKiemThucDon1(string ten);


        //bllthucdonphache
        [OperationContract]
        List<ChiTietHoaDon> SelectTDPC();
        [OperationContract]
        List<ChiTietHoaDon> SelectTDPC1();
        [OperationContract]

        int InSertTDPC(HoaDon hoaDon, string nv);
        [OperationContract]
        int UpdeteTDPC(string check);



        // TODO: Add your service operations here
    }



}
