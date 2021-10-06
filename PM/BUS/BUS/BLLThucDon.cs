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
    public class BLLThucDon
    {
        DALThucDon ThucDon = new DALThucDon();
        public DataTable SelectThucDon()
        {
            
            return ThucDon.SelectThucDon();
        }
        public DataTable TongSoMon()
        {
            return ThucDon.TongSoMon();
        }


        public DataTable SelectThucDon1(DateTime time1, DateTime time2)
        {
            return ThucDon.SelectThucDon1(time1,time2);
        }

        public DataTable SelectThucDon2(DateTime time1, DateTime time2)
        {
            return ThucDon.SelectThucDon2(time1, time2);
        }

        public int InsetThucDon(ThucDon thucDon)
        {

            return ThucDon.InsetThucDon(thucDon);
        }

        public int UpdateThucDon(ThucDon thucDon)
        {
            return ThucDon.Update(thucDon);
        }

        public int DeleteThucDon(ThucDon thucDon)
        {
            return ThucDon.Delete(thucDon);

        }

  

        public DataTable TimKiemThucDon(string Name)
        {
            return ThucDon.TimKiemThucDon(Name);
        }

        public DataTable TimKiemThucDon2(string Name)
        {
            return ThucDon.TimKiemThucDon2(Name);
        }
        public DataTable TimKiemThucDon1(string ten)
        {
            return ThucDon.TimKiemThucDon1(ten);
        }
    
}
}
