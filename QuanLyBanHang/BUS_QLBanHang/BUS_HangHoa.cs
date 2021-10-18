using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLBanHang;
using DTO_QLBanHang;
namespace BUS_QLBanHang
{
    public class BUS_HangHoa
    {
        DAL_HangHoa dalhanghoa = new DAL_HangHoa();
        // danh sách hàng hóa
        public DataTable danhsachHang()
        {
            return dalhanghoa.danhsachHang();
        }
        // Nhập hàng hóa
        public bool NhapHangHoa(DTO_Hang hang, string email)
        {
            return dalhanghoa.NhapHangHoa(hang,email);
        }
        // Sửa hàng hóa
        public bool CapNhatHangHoa(DTO_Hang hang , string email)
        {
            return dalhanghoa.CapNhatHangHoa(hang , email);
        }
        // Xóa hàng hóa
        public bool XoaHangHoa(int mahang)
        {
            
            return dalhanghoa.XoaHangHoa(mahang);
        }
        // tìm kiếm hàng hóa
        public DataTable TimHangHoa(string name)
        {
           
            return dalhanghoa.TimHangHoa(name);
        }
        // danh sách thống kê hàng tồn kho
        public DataTable ThongKeHangTonKho()
        {
            return dalhanghoa.ThongkeHangTonKho();
        }
        // danh sách thống kê hàng hóa
        public DataTable ThongkeHangHoa()
        {
            return dalhanghoa.ThongkeHangHoa();
        }
    }
}
