using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_NhanVien
    {
        private int iD;
        private string maNV;
        private string hoTen;
        private string email;
        private bool tinhTrang;
        private bool vaiTro;
        private string matKhau;

        // tạo constructer
        public DTO_NhanVien(int id, string manv , string hoten , string email , bool tinhtrang, bool vaitro , string matkhau)
        {
            this.ID = id;
            this.MaNV = manv;
            this.HoTen = hoten;
            this.Email = email;
            this.TinhTrang = tinhtrang;
            this.VaiTro = vaitro;
            this.MatKhau = matkhau;
        }
        public DTO_NhanVien()
        {

        }
        // đóng gói
        public int ID { get => iD; set => iD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Email { get => email; set => email = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public bool VaiTro { get => vaiTro; set => vaiTro = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
