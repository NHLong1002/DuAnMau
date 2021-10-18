using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
using DAL_QLBanHang;
using System.Data;
namespace BUS_QLBanHang
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalkhachhang = new DAL_KhachHang();
        // Tìm Kh
        public DataTable TimKH(string sdt)
        {
            return dalkhachhang.TimKH(sdt);
        }
        // Xóa khách hàng
        public bool XoaKh(string sdt)
        {
            return dalkhachhang.Xoakh(sdt);
        }
        // Sửa khách hàng
        public bool CapNhatKH(DTO_KhachHang kh)
        {
            return dalkhachhang.CapNhatkh(kh);
        }
        // Nhập khách hàng
        public bool NhapKH(DTO_KhachHang kh, string email)
        {
            return dalkhachhang.NhapKH(kh, email);
        }
        // Xuất danh sách khách hàng
        public DataTable DanhSachKH()
        {
            return dalkhachhang.DanhSachKH();
        }
    }
}
