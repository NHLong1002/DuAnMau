using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;


namespace QuanLyBanHang
{
    public partial class FLogin : Form
    {
        public bool vaitro;
        public string matkhau;
        // tạo một đối tượng bus nhân viên để sử dụng các thành phần bên trong nó
        BUS_NhanVien busnhanvien = new BUS_NhanVien();

        public FLogin()
        {
            InitializeComponent();
        }

        #region Events

        // Event Đăng nhập
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nhanvien = new DTO_NhanVien();
            nhanvien.Email = txtTenDangNhap.Text;
            // mã hóa mật khẩu để so sánh với mật khẩu đã mã hóa
            nhanvien.MatKhau = busnhanvien.encryption(txtMatkhau.Text);
            // kiểm tra đăng nhập
            if (busnhanvien.DangNhap(nhanvien))
            {
                // thành công
                MessageBox.Show("Đăng nhập thành công");
                FMain.email = nhanvien.Email;
                vaitro = busnhanvien.VaiTro(nhanvien.Email);
                FMain.session = 1;
                this.Close();
                
            }
            else
            {
                // đăng nhập thất bại
                MessageBox.Show("Đăng nhập không thành công");
                txtMatkhau.Text = null;
                txtTenDangNhap.Text = null;
                txtTenDangNhap.Focus();
                MessageBox.Show(nhanvien.MatKhau);
            }
        }
        // Event Quên mật khẩu
        private void lblQuenmatkhau_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Mời bạn nhập gmail để thực hiện chức năng này");
                txtTenDangNhap.Focus();
            }
            else
            {
                if (busnhanvien.QuenMatKhau(txtTenDangNhap.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(RandomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    string matkhaumoi = busnhanvien.encryption(builder.ToString());
                    // cập nhật lại mật khẩu mới trên CSDL
                    busnhanvien.MatKhauMoi(txtTenDangNhap.Text, matkhaumoi);
                    GuiMail(txtTenDangNhap.Text,"Mật khẩu mới của bạn (QMK)",builder.ToString());
                }
            }
        }
        #endregion

   
        #region Code xử lý
        // Tạo chuỗi ngẫu nhiên
        public string RandomString(int size, bool Lowercases)
        {
            StringBuilder builder = new StringBuilder();
            Random rd = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (Lowercases)
                return builder.ToString().ToLower();
            return builder.ToString();

        }

        // Tạo số ngẫu nhiên
        public string RandomNumber(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max).ToString();
        }
        // Tự động gởi mail
        public void GuiMail(string email,string tieude ,string matkhau)
        {
            try
            {
                //// tạo đối tượng gởi mail
                //SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                //// Xác thực
                //// Nhập thông tin gmail của người gửi
                //NetworkCredential cred = new NetworkCredential("rotkbynbyn@gmail.com", "0936229300a");
                ////Tạo Messenger để gửi mail
                //MailMessage msg = new MailMessage();
                ////Địa chỉ mail người gửi
                //msg.From = new MailAddress("rotkbynbyn@gmail.com");
                //// Địa chỉ mail người nhận
                //msg.To.Add("ngiuenhoanglong100220@gmail.com");
                //// Chủ đề của văn bản
                //msg.Subject = "Bạn đã sử dụng chức năng quên mật khẩu";
                //// đoạn văn bản trong gmail
                //msg.Body = "Chào Anh/Chị , Mật khẩu của Anh/Chị là " + matkhau;
                //// gửi chi tiết đăng nhập đến client
                //client.Credentials = cred;
                //// cung cấp quyền để gửi mail
                //client.EnableSsl = true;
                //// Gửi mail
                //client.Send(msg);
                //// Xác nhận gửi sau khi nhấn nút
                //MessageBox.Show("Mật khẩu mới của bạn đã được gửi tới, Vui lòng check mail");
                MailMessage mess = new MailMessage("ngiuenhoanglong100220@gmail.com", "ngiuenhoanglong100220@gmail.com", tieude, matkhau);
                
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("ngiuenhoanglong100220@gmail.com", "0936229300");
                client.Send(mess);
                MessageBox.Show("Mật khẩu mới của bạn đã được gửi tới, Vui lòng check mail");
            }
            catch (Exception ex)
            {
                // Nếu mail không gửi được 
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        
    }
}
