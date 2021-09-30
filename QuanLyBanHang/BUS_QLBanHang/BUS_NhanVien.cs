using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
using DAL_QLBanHang;
namespace BUS_QLBanHang
{
    public class BUS_NhanVien
    {
        // Tạo các đối tượng của lớp khác để truy xuất
        DAL_NhanVien dalnhanvien = new DAL_NhanVien();
        // mã hóa mật khẩu
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            // mã hóa mật khẩu thành dữ liệu mã hóa
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptData = new StringBuilder();
            // tạo ra một chuỗi ký tự mới từ dữ liệu đã mã hóa
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptData.Append(encrypt[i].ToString());
            }
            return encryptData.ToString();
        }
        // Đăng nhập
        public bool DangNhap(DTO_NhanVien nv)
        {
            return dalnhanvien.DangNhap(nv);
        }
        //Quên mật khẩu
        public bool QuenMatKhau(string email)
        {
            return dalnhanvien.NVQuenMatKhau(email);
        }
        //Tạo mật khẩu mới
        public bool MatKhauMoi (string email , string matkhaumoi)
        {
            return dalnhanvien.TaoMatKhauMoi(email, matkhaumoi);
        }
    }
}
