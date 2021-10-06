using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class HoaDon
    {
        private string MaHD;
        private DateTime dateTime;
        private int TongTien;
        private int GiamGia;
        private Ban Ban;
        private List<ChiTietHoaDon> chiTietHoaDons= new List<ChiTietHoaDon>();
        private int soluong1;

        
        [DataMember]
        public string MAHD
        {
            get { return MaHD; }
            set { MaHD = value; }
        }
        public int TONGTIEN(List<ChiTietHoaDon> chitet)
        {
        
            return (TinhTongTien(chitet) -((GiamGia)));
        }
        public int TinhTongTien(List<ChiTietHoaDon> chitet)
        {
            TongTien = 0;
            foreach (ChiTietHoaDon item in chitet)
            {
                TongTien += item.Thucdon.DONGIA;
             
            }
            return TongTien;
        }

        [DataMember]
        public int GIAMGIA
        {
            get { return GiamGia; }

            set { GiamGia = value; }
        }
        
        public int TinhTienGiam( int n, List<ChiTietHoaDon>  chitet)
        {
       
            int a = n % 100;
            int b = n / 100;
            float t = float.Parse(b + "," + a);
            double w = TONGTIEN(chitet)* double.Parse(b + "." + a);
            GIAMGIA = (int)w;
            return GIAMGIA;

        }
        [DataMember]
        public DateTime NgayDen
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        [DataMember]
        public Ban BAN
        {
            get { return Ban; }
            set { Ban = value; }
        }
        [DataMember]
       public List<ChiTietHoaDon> ChiTietHoaDons { get => chiTietHoaDons; set => chiTietHoaDons = value; }
        [DataMember]
        public int TongTien1 { get => TongTien; set => TongTien = value; }
        [DataMember]
        public int Soluong { get => soluong1; set => soluong1 = value; }
        
    }
}
