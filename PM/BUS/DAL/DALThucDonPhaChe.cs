using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
   public class DALThucDonPhaChe:DBconect
    {
         public DataTable Select()
        {
             DataTable dataTable = new DataTable();
            try
            {
                string Sql = string.Format("Select PC.MaChiTietHD, TD.TenMon ,PC.SoLuong,NV.TEN,Ban.TenBan ,PC.TrangThai  " +
                  "  from Ban, NHANVIEN NV, ThucDon TD, ChiTietHD  PC ,HoaDon  " +
                "   WHERE Ban.MaBan = HoaDon.MaBan AND PC.MaMon = TD.MaMon AND PC.TrangThai='Chua Pha Chê´' " +
                " AND PC.MAHD=HoaDon.MaHD  AND NV.MaNV=HoaDon.MaNV ");
             
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Sql, sqlConnection());
               
                sqlDataAdapter.Fill(dataTable);
            
            }
            catch (Exception e)
            {
                
            }
            return dataTable;

        }

        public DataTable Select1()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string Sql = string.Format("Select PC.MaChiTietHD, TD.TenMon ,PC.SoLuong,NV.TEN,Ban.TenBan ,PC.TrangThai  " +
                  "  from Ban, NHANVIEN NV, ThucDon TD, ChiTietHD  PC ,HoaDon  " +
                "   WHERE Ban.MaBan = HoaDon.MaBan AND PC.MaMon = TD.MaMon AND PC.TrangThai='Ða~ xong'" +
                " AND PC.MAHD=HoaDon.MaHD  AND NV.MaNV=HoaDon.MaNV ");

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Sql, sqlConnection());

                sqlDataAdapter.Fill(dataTable);

            }
            catch (Exception e)
            {
                
            }
            return dataTable;
        }


        public int InSert( HoaDon hoaDon,string nv)
        {
            foreach (ChiTietHoaDon item in hoaDon.ChiTietHoaDons)
            {
                string SQL = string.Format("Insert InTo ThưcDơnPhaChe ( MaMon,MANV,MABAN,SL,TRANGTHAI)" +
              " VALUES ('{0}','{1}' ,'{2}' ,'{3}' ,'Chưa Pha Chế' )",item.Thucdon.MAMON,nv,hoaDon.BAN.MaBan,item.SOLUONG);
                SqlConnection sql = new SqlConnection();
                sql = sqlConnection();
                try
                {
                    sql.Open();
                    SqlCommand sqlCommand = new SqlCommand(SQL, sql);
                    sqlCommand.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                finally
                {
                    sql.Close();
                }

            }
            return 1;
          

        }

        public int Updete(string check)
        {
            string SQL = string.Format("Update ChiTietHD set trangthai='Đã xong' where MaChiTietHD={0}", check);
            SqlConnection sql = new SqlConnection();
            sql = sqlConnection();
            try
            {
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand(SQL, sql);
                sqlCommand.ExecuteNonQuery();
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sql.Close();
            }
            return 0;

        }
    }
}
