using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO_QLBanHang;
using System.Data;
namespace DAL_QLBanHang
{
  
    public class DAL_DBConnect 
    {
        // kết nối sql

        protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-O21RMHC;Initial Catalog=DUAN_QLBH;Integrated Security=True");

       
    }

}
