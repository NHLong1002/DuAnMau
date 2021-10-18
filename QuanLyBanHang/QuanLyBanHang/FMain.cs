using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FMain  :Form 
    {
        public static int session = 0; // kiem tra tinh trang login 
        public static int profile = 0;
        public static string email ; // Truyền gmail sang form khác thông qua biến static
        FLogin dn;

        public FMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.ShowInTaskbar = false;
           
        }
        #region Event
        public void FMain_Load(object sender, EventArgs e)
        {
            ResetValue() ;
            if(profile == 1)// Vừa đổi mật khẩu , cần đăng nhập lại
            {
                
                session = 0; // đưa về trạng thái chưa đăng nhập
            }    
        }
        private void ITEMMNSHSNV_Click(object sender, EventArgs e)
        {
            FDoiMatKhau f = new FDoiMatKhau(email);
            if (!CheckExitsChildForm("FDoiMatKhau"))
            {
                f.MdiParent = this;
                f.Show();
                f.TopLevel = false;
                f.Visible = true;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                f.FormClosed += new FormClosedEventHandler(FMain_Load);
            }
            else
            {
                ActiveChildForm("FDoiMatKhau");
            }
        }
        private void ITEMMNSHDSD_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Huongdan.txt");
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ITEMMNSDANGNHAP_Click(object sender, EventArgs e)
        {
             dn = new FLogin();
           
            if (!CheckExitsChildForm("FLogin"))
            {
                dn.MdiParent = this;
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(FMain_Load);
            }
            else
            {
                ActiveChildForm("FLogin");
            }
        }
        private void ITEMMNSSANPHAM_Click(object sender, EventArgs e)
        {
            FQuanLyHangHoa fhanghoa = new FQuanLyHangHoa();
            if (!CheckExitsChildForm("FQuanLyHangHoa"))
            {
                fhanghoa.MdiParent = this;
                fhanghoa.Show();
                fhanghoa.TopLevel = false;
                fhanghoa.Visible = true;
                fhanghoa.FormBorderStyle = FormBorderStyle.None;
                fhanghoa.Dock = DockStyle.Fill;
                fhanghoa.FormClosed += new FormClosedEventHandler(FMain_Load);
            }
            else
            {
                ActiveChildForm("FQuanLyHangHoa");
            }
        }
        private void ITEMMNSNHANVIEN_Click(object sender, EventArgs e)
        {
            FQuanlyNV f = new FQuanlyNV();
            if (!CheckExitsChildForm("FQuanlyNV"))
            {
                f.MdiParent = this;
                f.Show();
                f.TopLevel = false;
                f.Visible = true;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                f.FormClosed += new FormClosedEventHandler(FMain_Load);
            }
            else
            {
                ActiveChildForm("FQuanlyNV");
            }
        }
        private void ITEMMNSKHACHHANG_Click(object sender, EventArgs e)
        {
            FQuanLyKhachHang f = new FQuanLyKhachHang();
            if (!CheckExitsChildForm("FQuanLyKhachHang"))
            {
                f.MdiParent = this;
                f.Show();
                f.TopLevel = false;
                f.Visible = true;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                f.FormClosed += new FormClosedEventHandler(FMain_Load);
            }
            else
            {
                ActiveChildForm("FQuanLyKhachHang");
            }
        }
        private void ITEMMNSTHONGKESP_Click(object sender, EventArgs e)
        {
            FThongKeSanPham f = new FThongKeSanPham();
            if (!CheckExitsChildForm("FThongKeSanPham"))
            {
                f.MdiParent = this;
                f.Show();
                f.TopLevel = false;
                f.Visible = true;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                f.FormClosed += new FormClosedEventHandler(FMain_Load);
            }
            else
            {
                ActiveChildForm("FThongKeSanPham");
            }
        }
        private void ITEMMNSTHOAT_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion
        #region     Code nghiep vu
        private void ResetValue()
        {
            if (session == 1)
            {
                Thongtinnv.Text = "Chào \t" + email;
                ITEMMNSDANGNHAP.Enabled = false;
                ITEMMNSDANGXUAT.Enabled = true;
                ITEMMNSHSNV.Visible = true;
                ITEMMNSKHACHHANG.Visible = true;
                ITEMMNSSANPHAM.Visible = true;
                danhMụcToolStripMenuItem.Visible = true;
                ITEMMNSHSNV.Enabled = true;
                if (dn.vaitro)
                {
                    ITEMMNSNHANVIEN.Visible = true;
                    thốngKêToolStripMenuItem.Visible = true;
                }    
            }
            else
            {
                Thongtinnv.Text = "";
                ITEMMNSDANGNHAP.Enabled = true;
                ITEMMNSDANGXUAT.Enabled = false;
                ITEMMNSHSNV.Enabled = false;
                danhMụcToolStripMenuItem.Visible = false;            
            }
        }
        private bool CheckExitsChildForm(string name)
        {
            bool check = false;

            foreach (Form form in this.MdiChildren)
            {
                
                if (form.Name == name) 
                {
                    return true;
                    break;
                }

            }
            return check;
        }
        private void ActiveChildForm (string name)
        {
            foreach (Form f in this.MdiChildren)
            {
                if(f.Name == name)
                {
                    f.Activate();
                    break;
                }
            }
        }



        #endregion


    }
}
