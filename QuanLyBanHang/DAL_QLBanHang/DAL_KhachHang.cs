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
    public class DAL_KhachHang : DAL_DBConnect
    {
        public DataTable TimKH(string sdt)
        {
            _conn.Open();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_timkh";
            cmd.Parameters.AddWithValue("@sdt", sdt);
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
        }
        public bool Xoakh(string sdt)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_XoaKH";
                cmd.Parameters.AddWithValue("@dienthoai", sdt);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;

        }
        public bool CapNhatkh(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Capnhatkh";
                cmd.Parameters.AddWithValue("@dienthoai", kh.DienTHoai);
                cmd.Parameters.AddWithValue("@phai", kh.Phai);
                cmd.Parameters.AddWithValue("@hoten", kh.HoTen);
                cmd.Parameters.AddWithValue("@diachi", kh.DiaChi);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool NhapKH(DTO_KhachHang kh,string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sP_NhapKH";
                cmd.Parameters.AddWithValue("@dienthoai",kh.DienTHoai);
                cmd.Parameters.AddWithValue("@hoten", kh.HoTen);
                cmd.Parameters.AddWithValue("@diachi", kh.DiaChi);
                cmd.Parameters.AddWithValue("@phai", kh.Phai);
                cmd.Parameters.AddWithValue("@email",email);    
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable DanhSachKH()
        {
            _conn.Open();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DanhsachKH";
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
        }
    }
}
