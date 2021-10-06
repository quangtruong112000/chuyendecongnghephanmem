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
    public class BLLNhomMon
    {
        private DALNhomMon DALNhomMon = new DALNhomMon();
        public DataTable SelectNhomMon()
        {
           
            return DALNhomMon.SelectNhomMon();
        }
        public DataTable TongNhomMon()
        {
            return DALNhomMon.TongNhomMon();
        }
        public int InsertNhomMon(NhomMon nhom)
        {

            return DALNhomMon.Insert(nhom);
        }
        public int UpdateNhomMon(NhomMon nhom)
        {
            return DALNhomMon.Update(nhom);
        }
        public int DeleteNhomMon(NhomMon nhom)
        {
            return DALNhomMon.Delete(nhom);

        }

        public DataTable TimKiemNhomMon(string nhom)
        {

            return DALNhomMon.TimKiem(nhom) ;
        }


    }
}
