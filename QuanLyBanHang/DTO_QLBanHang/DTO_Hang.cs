using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
   public class DTO_Hang
    {

		// thuộc tính
		private int maHang;
		private string tenHang;
		private int soLuong;
		private float donGiaNhap;
		private float donGiaBan;
		private string hinhAnh;
		private string ghiChu;
		private string maNV;
        //tạo constructor
        public DTO_Hang(int mahang, string tenhang, int soluong, float dongianhap, float dongiaban,string hinhanh,string ghichu,string manv)
        {
            this.MaHang = mahang;
            this.TenHang = tenhang;
            this.SoLuong = soluong;
            this.DonGiaNhap = dongianhap;
            this.DonGiaBan = dongiaban;
            this.HinhAnh = hinhanh;
            this.GhiChu = ghichu;
            this.MaNV = manv;
        }
        public DTO_Hang()
        {

        }
        public void Hello()
        {
           
        }
        // đóng gói
        public int MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }
        public float DonGiaBan { get => donGiaBan; set => donGiaBan = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string MaNV { get => maNV; set => maNV = value; }
    }
}
