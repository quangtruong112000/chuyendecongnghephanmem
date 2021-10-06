using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    [DataContract]
    public  class ThucDon
    {
        private int MaMon;
        private string TenMon;
       private NhomMon nhomMon =new NhomMon();
        private string dvt;
        private int DonGia;
        private int soluong;

        [DataMember]
        public string tenmon
        {
            get { return TenMon; }
            set { TenMon = value; }
        }

        [DataMember]
        public string DVT
        {
            get { return dvt; }
            set { dvt = value; }
        }
        [DataMember]
        public int MAMON
        {
            get { return MaMon; }
            set { MaMon = value; }
        }
        [DataMember]
        public int DONGIA
        {
            get { return DonGia; }
            set { DonGia = value; }
        }
        [DataMember]
        public NhomMon NhomMon
        {
            get { return nhomMon; }
            set { nhomMon = value; }
        }
        [DataMember]
        public int Soluong { get => soluong; set => soluong = value; }
    }
   
    

}

