using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
namespace DAL_QLBanHang
{
    public class DAL_NhanVien:DAL_DBConnect
    {
        public DataTable TimNV (string name)
        {
            _conn.Open();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_timNV";
            cmd.Parameters.AddWithValue("@tennv", name);
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
        }
        public bool XoaNV(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_XoaNV";
                cmd.Parameters.AddWithValue("@emai", email);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
           
        }
        public bool CapNhatNV(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CapnhatNV";
                cmd.Parameters.AddWithValue("@hoten", nv.HoTen);
                cmd.Parameters.AddWithValue("@email", nv.Email);
                cmd.Parameters.AddWithValue("@vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("@diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@tinhtrang", nv.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool NhapNV(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sP_NhapNV";
                cmd.Parameters.AddWithValue("@hoten", nv.HoTen);
                cmd.Parameters.AddWithValue("@email", nv.Email);
                cmd.Parameters.AddWithValue("@vaitro", nv.VaiTro);
                cmd.Parameters.AddWithValue("@diachi", nv.DiaChi);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable DanhSachNV()
        {
            _conn.Open();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DanhSachNV";
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
        }
        public bool DoiMatKhau(string email , string mkcu , string mkmoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TaoMatKhauMoi";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@matkhaucu", mkcu);
                cmd.Parameters.AddWithValue("@matkhaumoi", mkmoi);
                if (cmd.ExecuteNonQuery() > 0)
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
        public bool VaiTro (string email)
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Vaitro";
            cmd.Parameters.AddWithValue("@email", email);
            if(Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                return true;
            }
            _conn.Close();
            return false;
        }
        public bool CheckEmail (string email)
        {

            try
            {
                // mở kết nối sql
                _conn.Open();
                // câu truy vấn email và mật khẩu
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_checkemail";
                // truyền parameter
                cmd.Parameters.AddWithValue("@email",email);
                // kiểm tra email đã tồn tại hay chưa
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
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
