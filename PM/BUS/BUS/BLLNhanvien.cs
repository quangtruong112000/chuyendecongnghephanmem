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
    public class BLLNhanvien
    {
        DALNhanvien dALNhanvien = new DALNhanvien();
        
        public DataTable SelectNV()
        {
            return dALNhanvien.Select();
        }
        public int InsertIntoNV(NhanVien nhanVien)
        {

            return dALNhanvien.InsertInto(nhanVien);
        }
        public int UpdateNV(NhanVien nhanVien)
        {
            return dALNhanvien.Update(nhanVien);
        }

        public int DeleteNV(string MANV)
        {
            return dALNhanvien.Delete(MANV);
        }

    }
}
