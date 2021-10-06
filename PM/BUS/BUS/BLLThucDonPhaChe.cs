using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    [DataContract]
    public class BLLThucDonPhaChe
    {
        private DALThucDonPhaChe thucDonPhaChe=new DALThucDonPhaChe();
        public DataTable SelectTDPC()
        {
      
          
            return thucDonPhaChe.Select();

        }

        public DataTable SelectTDPC1()
        {
            return thucDonPhaChe.Select1();
        }


        public int InSertTDPC(HoaDon hoaDon, string nv)
        {

            return thucDonPhaChe.InSert(hoaDon, nv);
        }

        public int UpdeteTDPC(string check)
        {
            return thucDonPhaChe.Updete(check);

        }
    }
}
