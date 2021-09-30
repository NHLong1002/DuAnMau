using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
namespace DAL_QLBanHang
{
    public class DAL_NhanVien:DAL_DBConnect
    {
        // hello world

        public bool NVQuenMatKhau(string email)
        {
            try
            {
                // kết nối
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_QuenMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                // Query và kiểm tra
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch 
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool TaoMatKhauMoi (string email , string matkhaumoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_taomatkhaumoi";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@matkhau", matkhaumoi);
                if ((cmd.ExecuteNonQuery()) > 0)
                    return true;
                
            }
            catch (Exception)
            {
              
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool DangNhap(DTO_NhanVien nv)
        {

            try
            {
                // mở kết nối sql
                _conn.Open();
                // câu truy vấn email và mật khẩu
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_DangNhap";
                // truyền parameter
                cmd.Parameters.AddWithValue("@email", nv.Email);
                cmd.Parameters.AddWithValue("@matkhau", nv.MatKhau);
                // kiểm tra email và mật khẩu truyền vào có tồn tại hay không
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch (Exception)
            {
            }
            finally
            {
                // đóng kết nối
                _conn.Close();
            }
            return false;

        }
    }
}
