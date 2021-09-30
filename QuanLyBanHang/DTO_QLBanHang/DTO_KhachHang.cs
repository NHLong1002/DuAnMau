using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_KhachHang
    {
        // thuộc tính
        private string dienTHoai;
        private string hoTen;
        private string diaChi;
        private bool phai;
        private string maNV;
        // tạo constructor
        public DTO_KhachHang(string dienthoai, string hoten, string diachi, bool phai, string manv)
        {
            this.DienTHoai = dienthoai;
            this.HoTen = hoten;
            this.DiaChi = diachi;
            this.Phai = phai;
            this.MaNV = manv;
        }
        public DTO_KhachHang()
        {

        }
        // đóng gói
        public string DienTHoai { get => dienTHoai;  set => dienTHoai = value; }
        public string HoTen { get => hoTen;  set => hoTen = value; }
        public string DiaChi { get => diaChi;  set => diaChi = value; }
        public bool Phai { get => phai;  set => phai = value; }
        public string MaNV { get => maNV;  set => maNV = value; }
    }
}
