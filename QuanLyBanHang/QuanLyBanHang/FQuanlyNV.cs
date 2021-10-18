using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace QuanLyBanHang
{
    public partial class FQuanlyNV : Form
    {
        BUS_NhanVien busnhanvien = new BUS_NhanVien();
        private static bool VAITRO;
        private static bool TINHTRANG;
        FLogin f = new FLogin();
            public FQuanlyNV()
        {
            InitializeComponent();
        }

        #region Events
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable ds = busnhanvien.TimNV(txtTim.Text.Trim());
            if (ds.Rows.Count > 0)
            {
                dtgvDSNV.DataSource = ds;
                dtgvDSNV.Columns[0].HeaderText = "Mã NV";
                dtgvDSNV.Columns[1].HeaderText = "Tên nhân viên";
                dtgvDSNV.Columns[2].HeaderText = "Email";
                dtgvDSNV.Columns[3].HeaderText = "Địa chỉ";
                dtgvDSNV.Columns[4].HeaderText = "Vai trò";
                dtgvDSNV.Columns[4].ReadOnly = true;
                dtgvDSNV.Columns[5].ReadOnly = true;
                dtgvDSNV.Columns[5].HeaderText = "Tình trạng";
                dtgvDSNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvDSNV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTim.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadGridview_DSNV();
            ResetValue();
            txtTim.Text = "--Nhập tên nhân viên--";
            txtTim.ForeColor = Color.Silver;
        }
        private void txtTim_Click(object sender, EventArgs e)
        {
            txtTim.Text = null;
            txtTim.ForeColor = Color.Black;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDiachi.Enabled = true;
            txtEmail.Enabled = true;
            txtHoten.Enabled = true;
            rdbNhanvien.Enabled = true;
            rdbQTV.Enabled = true;
            rdbhoatdong.Enabled = true;
            rdbNgungHD.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim().Length > 0 && txtDiachi.Text.Trim().Length > 0 && txtHoten.Text.Trim().Length > 0)
                {
                    if (!hasSpecialChar(txtDiachi.Text))
                    {
                        if (!hasSpecialChar(txtHoten.Text))
                        {
                            // Check vai trò
                            if (rdbNhanvien.Checked) VAITRO = false;
                            else if (rdbQTV.Checked) VAITRO = true;
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("Người này có vai trò là 'Nhân viên' phải không?'", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                    VAITRO = false;
                                else
                                    VAITRO = true;

                            }
                            if (IsValid(txtEmail.Text))
                            {
                                // kiểm tra họ tên có phải là số hay không
                                bool isNumber = false;
                                foreach (char item in txtHoten.Text)
                                 {
                                    if (Char.IsNumber(item))
                                    {
                                        isNumber = true;
                                        break;
                                    }
                                }
                                if (!isNumber)
                                {
                                    DTO_NhanVien nhanvien = new DTO_NhanVien();
                                    nhanvien.DiaChi = txtDiachi.Text.Trim();
                                    nhanvien.VaiTro = VAITRO;
                                    nhanvien.Email = txtEmail.Text.Trim();
                                    nhanvien.HoTen = txtHoten.Text.Trim();
                                    if (busnhanvien.CheckEmailExist(txtEmail.Text))
                                    {
                                        if (busnhanvien.NhapNV(nhanvien))
                                        {
                                            MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ResetValue();
                                            LoadGridview_DSNV();
                                            f.GuiMail("rotkbynbyn@gmail.com", "Mật khẩu của bạn là", "123");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Thêm nhân viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Email đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Họ va tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                // tạo đối tượng nhân viên và gán các giá trị của người dùng truyền vào

                            }
                            else
                            {
                                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtEmail.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Họ tên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Địa chỉ không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
           
                }
                else
                {
                    MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rdbQTV.Checked)
            {
                MessageBox.Show("Bạn không thể xóa QTV", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa nhân viên " + txtHoten.Text + " không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    busnhanvien.XoaNV(txtEmail.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValue();
                    LoadGridview_DSNV();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim().Length > 0 && txtDiachi.Text.Trim().Length > 0 && txtHoten.Text.Trim().Length > 0)
                {
                    if (!hasSpecialChar(txtDiachi.Text))
                    {
                        if (!hasSpecialChar(txtHoten.Text))
                        {
                            // Check vai trò
                            if (rdbhoatdong.Checked) TINHTRANG = true;
                            else TINHTRANG = false;
                            if (rdbNhanvien.Checked) VAITRO = false;
                            else VAITRO = true;
                            // tạo đối tượng nhân viên và gán các giá trị của người dùng truyền vào
                            DTO_NhanVien nhanvien = new DTO_NhanVien();
                            nhanvien.Email = txtEmail.Text;
                            nhanvien.DiaChi = txtDiachi.Text;
                            nhanvien.VaiTro = VAITRO;
                            nhanvien.HoTen = txtHoten.Text;
                            nhanvien.TinhTrang = TINHTRANG;

                            if (MessageBox.Show("Bạn có muốn sửa thông tin không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (busnhanvien.CheckEmailExist(txtEmail.Text))
                                {
                                    if (busnhanvien.CapNhatNV(nhanvien))
                                    {
                                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ResetValue();
                                        LoadGridview_DSNV();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Email đã tồn tại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Họ và tên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Địa chỉ không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Trục trặc rồi đại vương ơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void FQuanlyNV_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridview_DSNV();
        }
        private void dtgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDSNV.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;  
                txtHoten.Enabled = true;
                txtDiachi.Enabled = true;
                rdbhoatdong.Enabled = true;
                rdbNgungHD.Enabled = true;
                rdbNhanvien.Enabled = true;
                rdbQTV.Enabled = true;
                // hiển thị dữ liệu vào các controls
                txtEmail.Text = dtgvDSNV.CurrentRow.Cells["email"].Value.ToString();
                txtDiachi.Text = dtgvDSNV.CurrentRow.Cells["diachi"].Value.ToString();
                txtHoten.Text = dtgvDSNV.CurrentRow.Cells["hoten"].Value.ToString();
                if (dtgvDSNV.CurrentRow.Cells["vaitro"].Value.ToString() == "" )
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    txtHoten.Enabled = false;
                    txtDiachi.Enabled = false;
                    rdbNhanvien.Checked = false;
                    rdbQTV.Checked = false;
                    rdbhoatdong.Checked = false;
                    rdbNgungHD.Checked = false;
                    rdbNhanvien.Enabled = false;
                    rdbQTV.Enabled = false;
                    rdbhoatdong.Enabled = false;
                    rdbNgungHD.Enabled = false;
                }
                else
                {
                    switch ((bool.Parse(dtgvDSNV.CurrentRow.Cells["vaitro"].Value.ToString())))
                    {
                        case true: rdbQTV.Checked = true; break;
                        case false: rdbNhanvien.Checked = true;break;
                        default: break;
                    }
                    if ((bool.Parse(dtgvDSNV.CurrentRow.Cells["tinhtrang"].Value.ToString())))
                    {
                        rdbhoatdong.Checked = true;
                    }
                    else
                    {
                        rdbNgungHD.Checked = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("BẢng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Code
        // Kiểm tra email
        public bool IsValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        // Xuất danh sách nhân viên
        private void LoadGridview_DSNV()
        {
            dtgvDSNV.DataSource = busnhanvien.DanhSachNV();
            dtgvDSNV.Columns[0].HeaderText = "Mã NV";
            dtgvDSNV.Columns[1].HeaderText = "Tên nhân viên";
            dtgvDSNV.Columns[2].HeaderText = "Email";
            dtgvDSNV.Columns[3].HeaderText = "Địa chỉ";
            dtgvDSNV.Columns[4].HeaderText = "Vai trò";
            dtgvDSNV.Columns[4].ReadOnly = true;
            dtgvDSNV.Columns[5].ReadOnly = true;
            dtgvDSNV.Columns[5].HeaderText = "Tình trạng";
            dtgvDSNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvDSNV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        // Hàm khởi tạo giá trị ban đầu
        private void ResetValue()
        {
            txtDiachi.Enabled = false;
            txtEmail.Enabled = false;
            txtHoten.Enabled = false;
            rdbNhanvien.Enabled = false;
            rdbQTV.Enabled = false;
            rdbNgungHD.Enabled = false;
            rdbhoatdong.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private static bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion


    }
}
