using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public  class NhanVien
    {
        [DataMember]
        public string MaNV1 { get; set; }
        [DataMember]
        public string Ten1 { get; set; }
        [DataMember]
        public string SDT1 { get; set; }
        [DataMember]
        public string GioiTinh1 { get; set; }
        [DataMember]
        public string MaKhau1 { get; set; }
        [DataMember]
        public string Chucvu1 { get; set; }
    }
}
