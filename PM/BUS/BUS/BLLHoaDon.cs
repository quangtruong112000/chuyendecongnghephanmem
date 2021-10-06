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
    public class BLLHoaDon
    {
      private  DALHoaDon dAL = new DALHoaDon();
   
        public DataTable TimKiemHoaDon5()
        {
            return dAL.TimKiemHoaDon5();
        }

        public string ThongkeHD()
        {
            int a = 0, b = 0;

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            time1 = time1.AddMonths(-1);
            DALHoaDon dALHoaDon = new DALHoaDon();

            foreach (DataRow item in dALHoaDon.TimKiemHoaDon1(time1, time2).Rows)
            {

                ; try
                {
                    a = Convert.ToInt32(item["TONGTIEN"].ToString());
                    b = Convert.ToInt32(item["Giamgia"].ToString());
                }
                catch { }

            }

           return (a - b).ToString("N") + " VND ";

        }

        public DataTable GetHD()
        {
          return  dAL.GetHD();

        }


        public int InsetHD(HoaDon hoaDon, string MANV)
        {
            return dAL.InsetHD(hoaDon, MANV);

        }

        public DataTable TimKiemHoaDon1(DateTime time1, DateTime time2)
        {
            return dAL.TimKiemHoaDon1(time1, time2);

        }


        public DataTable TongSoHd(DateTime time1, DateTime time2)
        {
            return dAL.TongSoHd(time1, time2);
        }

        public DataTable TimKiemHoaDon2(DateTime time1, DateTime time2)
        {
            return dAL.TimKiemHoaDon(time1, time2);
        }


        public DataTable TimKiemHoaDon(int maBan)
        {
            return dAL.TimKiemHoaDon(maBan);
        }

        public int InsetHD1(HoaDon hoaDon)
        {
            return dAL.InsetHD1(hoaDon);

        }


        public int UpdateHD(HoaDon hoaDon)
        {
            return dAL.Update(hoaDon);

        }
        public int DeleteHD(int hoaDon)
        {
            return dAL.Delete(hoaDon);
        }

    }
}
