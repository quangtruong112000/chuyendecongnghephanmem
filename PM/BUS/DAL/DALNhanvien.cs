using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
   public class DALNhanvien:DBconect
    { 

        public DataTable Select()
        {
            string SQL = "Select * from NhanVien ";
            SqlDataAdapter sql = new SqlDataAdapter(SQL,sqlConnection());
            DataTable data = new DataTable();
            sql.Fill(data);
            return data;

        }

        public int InsertInto(NhanVien nhanVien)
        {
            string SQL = string.Format("INSERT INTO NHANVIEN (MANV,TEN,GIOITINH,GMAIL,CHUCVU,MATKHAU) VALUES" +
                " ('{0}','{1}','{2}','{3}','{4}','{5}') ", "595107"+nhanVien.MaNV1, nhanVien.Ten1, nhanVien.GioiTinh1,
                nhanVien.SDT1, nhanVien.Chucvu1, nhanVien.MaKhau1);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand command = new SqlCommand(SQL, sqlConnection1);
                command.ExecuteNonQuery();
                return 1;
                /*MessageBox.Show("Thêm Thành Công");*/
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                sqlConnection1.Close();
            }
            return 0;
            

        }
        public int Update(NhanVien nhanVien)
        {
            string SQL = string.Format("UPDATE NHANVIEN Set TEN ='{1}', GIOITINH ='{2}'" +
                " , GMAIL ='{3}' ,CHUCVU = '{4}' ,MATKHAU = '{5}' " +
                "  WHERE MANV = '{0}' ","595107"+nhanVien.MaNV1, nhanVien.Ten1, nhanVien.GioiTinh1,
                nhanVien.SDT1, nhanVien.Chucvu1, nhanVien.MaKhau1);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand command = new SqlCommand(SQL, sqlConnection1);
                command.ExecuteNonQuery();/*
                MessageBox.Show("Cập Nhật Thành Công");*/
                return 1;
            }
            catch (Exception ex)
            {
              


            }
            finally
            {
                sqlConnection1.Close();
            }
            return 0;

        }

        public int Delete(string MANV)
        {
            string SQL = string.Format("DELETE FROM NHANVIEN  WHERE MANV = '{0}'", MANV);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand command = new SqlCommand(SQL, sqlConnection1);
                command.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
               /* MessageBox.Show("Vi Phạm Ràng Buộc");
                Console.WriteLine(ex.Message);*/
            }
            finally
            {
                sqlConnection1.Close();
            }
            return 0;

        }



    }
}
