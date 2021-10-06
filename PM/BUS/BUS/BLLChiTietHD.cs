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
    public class BLLChiTietHD
    {
        private DALChiTietHD chiTietHD=new DALChiTietHD();
        public DataTable GetChiTietHD()
        {
          
            return chiTietHD.GetChiTietHD();

        }

        public DataTable TimKiemCTHD(int timkiem)
        {
          return chiTietHD.TimKiem(timkiem);

        }



        public int InsetCTHD(ChiTietHoaDon chiTiet)
        {

            return chiTietHD.Inset(chiTiet);

        }
        public int UpdateCTHD(ChiTietHoaDon chiTiet)
        {
            return chiTietHD.Update(chiTiet);

        }
        public int UpdateCTHD2(string MaHd)
        {
           return  chiTietHD.Update2(MaHd);


        }


        public int DeleteCTHD(string thucDon)
        {
           return  chiTietHD.Delete(thucDon);

        }
    }
}
