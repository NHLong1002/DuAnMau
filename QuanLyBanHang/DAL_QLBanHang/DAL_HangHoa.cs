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
    public class DAL_HangHoa : DAL_DBConnect
    {
        // danh sách hàng hóa
        public DataTable danhsachHang()
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_danhsachhanghoa";
            DataTable tb = new DataTable();
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
            
        }
        // Nhập hàng hóa
        public bool NhapHangHoa(DTO_Hang hang , string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_themhanghoa";
                cmd.Parameters.AddWithValue("@tenhang",hang.TenHang);
                cmd.Parameters.AddWithValue("@soluong", hang.SoLuong);
                cmd.Parameters.AddWithValue("@dongianhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("@dongiaban", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("@hinhanh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("@ghichu", hang.GhiChu);
                cmd.Parameters.AddWithValue("@email", email);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Sửa hàng hóa
        public bool CapNhatHangHoa(DTO_Hang hang , string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_capnhathanghoa";
                cmd.Parameters.AddWithValue("@tenhang", hang.TenHang);
                cmd.Parameters.AddWithValue("@soluong", hang.SoLuong);
                cmd.Parameters.AddWithValue("@dongianhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("@dongiaban", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("@hinhanh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("@ghichu", hang.GhiChu);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mahang", hang.MaHang);
                
                if (cmd.ExecuteNonQuery() > 0) return true;

              
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
        // Xóa hàng hóa
        public bool XoaHangHoa (int mahang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_xoaHangHoa";
                cmd.Parameters.AddWithValue("@mahang", mahang);

                if (cmd.ExecuteNonQuery() > 0) return true;
               
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
        // tìm kiếm hàng hóa
        public DataTable TimHangHoa(string name)
        {
            _conn.Open();
            SqlCommand cmd= new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_timHangHoa";
            cmd.Parameters.AddWithValue("@tenhang", name);
            DataTable tb = new DataTable();
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
        }
        // Thống kế hàng hóa
        public DataTable ThongkeHangHoa()
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_thongkespnhap";
            DataTable tb = new DataTable();
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
        }
        // Thống kế hàng hóa tồn kho
        public DataTable ThongkeHangTonKho()
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_thongketonkho";
            DataTable tb = new DataTable();
            tb.Load(cmd.ExecuteReader());
            _conn.Close();
            return tb;
        }

    }
}
