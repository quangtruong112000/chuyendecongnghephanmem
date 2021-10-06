            using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public  class Ban
    {
        private int MABAN=1;
        private string TENBAN;
        private string TRANGTHAI;
        [DataMember]
        public int MaBan
        {
            get { return MABAN; }
            set { MABAN = value; }
        }
        [DataMember]
        public string TenBan
        {
            get { return TENBAN; }
            set { TENBAN = value; }
        }
        [DataMember]
        public string TrangThai
        {
            get { return TRANGTHAI; }
            set { TRANGTHAI = value; }
        }

    }
}
