using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
  public  class DBconect
    {
        public DBconect()
        {
        }

        public SqlConnection sqlConnection()
        {

            /*string sql = ConfigurationManager.ConnectionStrings["QuanLyBanHang"].ConnectionString;*/
            string sql = @"Data Source=SQL5108.site4now.net,1433;Initial Catalog=db_a7a94a_cnpmutc1;User Id=db_a7a94a_cnpmutc1_admin;Password=haupham809;";
/*
            string sql = @"Data Source=.;Initial Catalog=QuanLyNhaHang;Integrated Security=True";*/
            SqlConnection sqlConnection = new SqlConnection(sql);
            return sqlConnection;
        }

    }
}
