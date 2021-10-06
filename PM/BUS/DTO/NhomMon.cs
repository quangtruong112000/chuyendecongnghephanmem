using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public  class NhomMon
    {
        private int MaLoai;
        private string TenLoai;
        private string MauSac;
        private int soluong;
        [DataMember]
        public int Maloai
        {
            get
            {
                return MaLoai;
            }
            set
            {
                MaLoai = value;
            }
        }
        [DataMember]
        public string Tenloai
        {
            get
            {
                return TenLoai;
            }
            set
            {
                TenLoai = value;
            }
        }
        [DataMember]

        public string MAU
        {
            get
            {
                return MauSac;
            }
            set
            {
                MauSac = value;
            }
        }
        [DataMember]
        public int Soluong { get => soluong; set => soluong = value; }

        public string [] RGB()
        {
            string[] RGB = MauSac.Split(',');
            return RGB;
          
        }
    }
}
