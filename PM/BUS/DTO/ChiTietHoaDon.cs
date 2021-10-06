using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public  class ChiTietHoaDon
    {
        private string MaHD;
        private ThucDon ThucDon;
        private string MACTHD;
        private int Soluong;
        private HoaDon hoadon;
        [DataMember]
        public string tenNV { get; set; }
        [DataMember]
        public string MAHD
        {
            get { return MaHD; }
            set { MaHD = value; }
        }
        [DataMember]
        public string MaCTHD
        {
            get { return MACTHD; }
            set { MACTHD = value; }
        }
        [DataMember]
        public int SOLUONG
        {
            get { return Soluong; }
            set { Soluong = value; }
        }
        [DataMember]
        public ThucDon Thucdon
        {
            get { return ThucDon; }
            set { ThucDon = value; }
        }
        /*[DataMember]
        public int Gia
        {
            get { return(ThucDon.DONGIA * Soluong); }
            set { Gia = value; }
        }*/
        [DataMember]
        public HoaDon Hoadon { get => hoadon; set => hoadon = value; }
    }
}
