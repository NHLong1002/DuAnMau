using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS_QLBanHang;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FDoiMatKhau : Form
    {
        public FDoiMatKhau(string email)
        {
            InitializeComponent();
            txtEmail.Text = email;
            txtEmail.ReadOnly = true;
        }
        BUS_NhanVien busnhanvien = new BUS_NhanVien();
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim())|| string.IsNullOrWhiteSpace(txtMkhaucu.Text.Trim()) || string.IsNullOrWhiteSpace(txtMkhaumoi.Text.Trim()) || string.IsNullOrWhiteSpace(txtNhaplaiMKM.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if(txtMkhaumoi.Text.Trim().Length<5 || txtMkhaumoi.Text.Trim().Length > 50)
                {
                    MessageBox.Show("Mật khẩu phải từ 5 - 50 ký tự", "Thông báo", MessageBoxButtons.OK);
                }
                else if(txtMkhaumoi.Text.Trim() != txtNhaplaiMKM.Text.Trim())
                {

                    MessageBox.Show("Nhập lại mật khẩu không đúng , mời bạn nhập lại", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    string matkhaucu = busnhanvien.encryption(txtMkhaucu.Text);
                    string matkhaumoi = busnhanvien.encryption(txtMkhaumoi.Text);
                    if (busnhanvien.DoiMatKhau(txtEmail.Text, matkhaucu, matkhaumoi))
                    {
                        FMain.profile = 1; // cập nhật trajgn thái đổi mk thành công
                        FMain.session = 0; // trả về trạng thái chưa đăng nhập
                        FLogin f = new FLogin();
                        f.GuiMail(txtEmail.Text, "Mật khẩu mới của bạn",txtMkhaumoi.Text);
                        MessageBox.Show("Đổi mật khẩu thành công , vui lòng đăng nhập lại", "Thông báo", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bạn nhập sai Email hoặc mật khẩu cũ , vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
