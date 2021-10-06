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
    public  class BLLBan
    {
       private DALBan dALBan = new DALBan();
        public DataTable SelectBan()
        {
         return dALBan.SelectBan();
        }
        public DataTable TongSoBan()
        {
         
            return dALBan.TongSoBan();
        }
      

        public int InsertBan(Ban ban)
        {
            return dALBan.InsertBan(ban);
        }
        public int UpdeteBan(Ban ban)
        {
            return dALBan.UpdeteBan(ban);
        }
        public int DeleteBan(Ban ban)
        {
            return dALBan.DeleteBan(ban);
        }

    }

    

}
