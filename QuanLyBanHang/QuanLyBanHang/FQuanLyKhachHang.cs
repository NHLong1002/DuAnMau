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
    public partial class FQuanLyKhachHang : Form
    {
        BUS_KhachHang buskhachhang = new BUS_KhachHang();
        FQuanlyNV f = new FQuanlyNV();
        
        public static  bool gioitinh;
        public FQuanLyKhachHang()
        {
            InitializeComponent();
        }


        #region events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim().Length > 0)
            {
                if(buskhachhang.XoaKh(txtSDT.Text))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridview_DSKH();
                    ResetValue();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkNumber = true;
                if (txtSDT.Text.Trim().Length > 0 && txtDiachi.Text.Trim().Length > 0 && txtHoten.Text.Trim().Length > 0)
                {
                    foreach (char item in txtSDT.Text)
                    {
                        if (!Char.IsNumber(item))
                        {
                            checkNumber = false; break;
                        }
                    }
                    // Check vai trò
                    if (rdbNam.Checked) gioitinh = false;
                    else gioitinh = true;
                    
                    if (checkNumber)
                    {
                        bool checkChar = true;
                        foreach (char item in txtHoten.Text)
                        {
                            if (Char.IsNumber(item))
                            {
                                checkChar = false; break;
                            }
                        }
                        if (checkChar)
                        {
                            if (!hasSpecialChar(txtHoten.Text))
                            {
                                // tạo đối tượng Khách hàng và gán các giá trị của người dùng truyền vào
                                DTO_KhachHang kh = new DTO_KhachHang();
                                kh.DienTHoai = txtSDT.Text;
                                kh.DiaChi = txtDiachi.Text;
                                kh.Phai = gioitinh;
                                kh.HoTen = txtHoten.Text;
                                if (buskhachhang.CapNhatKH(kh))
                                {
                                    MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ResetValue();
                                    LoadGridview_DSKH();
                                }
                                else
                                {
                                    MessageBox.Show("Sửa Khách hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Họ tên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Họ tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSDT.Focus();
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkNumber = true;
                if (txtSDT.Text.Trim().Length > 0 && txtDiachi.Text.Trim().Length > 0 && txtHoten.Text.Trim().Length > 0)
                {
                    foreach (char item in txtSDT.Text)
                    {
                        if (!Char.IsNumber(item))
                        {
                            checkNumber = false;break; 
                        }
                    }
                    // Check vai trò
                    if (rdbNam.Checked) gioitinh = false;
                    else if (rdbNu.Checked) gioitinh = true;
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn là 'Nữ' đúng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            gioitinh = true;
                            rdbNu.Checked =true;
                        }
                            
                        else
                        {
                            gioitinh = false;
                            rdbNam.Checked = true;
                        }    
                           

                    }
                    if (checkNumber)
                    {
                        bool checkChar = true;
                        foreach (char item in txtHoten.Text)
                        {
                            if (Char.IsNumber(item))
                            {
                                checkChar = false; break;
                            }
                        }
                        if (checkChar)
                        {
                            if (!hasSpecialChar(txtHoten.Text))
                            {
                                // tạo đối tượng Khách hàng và gán các giá trị của người dùng truyền vào
                                DTO_KhachHang kh = new DTO_KhachHang();
                                kh.DiaChi = txtDiachi.Text;
                                kh.Phai = gioitinh;
                                kh.DienTHoai = txtSDT.Text;
                                kh.HoTen = txtHoten.Text;
                                if (buskhachhang.NhapKH(kh,FMain.email))
                                {
                                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ResetValue();
                                    LoadGridview_DSKH();
                                }
                                else
                                {
                                    MessageBox.Show("Thêm khách hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Họ tên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Họ tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSDT.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception )
            {
               
                MessageBox.Show("Trục trặc rồi đại vương ơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvKH.Rows.Count > 1)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                txtSDT.Enabled = false;
                btnXoa.Enabled = true;
                txtHoten.Enabled = true;
                txtDiachi.Enabled = true;
                rdbNam.Enabled = true;
                rdbNu.Enabled = true;
                // hiển thị dữ liệu vào các controls
                txtSDT.Text = dtgvKH.CurrentRow.Cells["dienthoai"].Value.ToString();
                txtDiachi.Text = dtgvKH.CurrentRow.Cells["diachi"].Value.ToString();
                txtHoten.Text = dtgvKH.CurrentRow.Cells["hoten"].Value.ToString();
                if (dtgvKH.CurrentRow.Cells["phai"].Value.ToString() == "")
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    txtSDT.Enabled = false;
                    txtHoten.Enabled = false;
                    txtDiachi.Enabled = false;
                    rdbNam.Enabled = false;
                    rdbNu.Enabled = false;
                    rdbNam.Checked = false;
                    rdbNu.Checked = false;
                }
                else
                {
                    switch ((bool.Parse(dtgvKH.CurrentRow.Cells["phai"].Value.ToString())))
                    {
                        case true: rdbNu.Checked = true; break;
                        case false: rdbNam.Checked = true; break;
                        default: break;
                    }
                }
            }
            else
            {
                MessageBox.Show("BẢng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void FQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadGridview_DSKH();
            ResetValue();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtSDT.Enabled = true;
            txtHoten.Enabled = true;
            txtDiachi.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
        }
        #endregion

        #region codes
        private void LoadGridview_DSKH()
        {
            dtgvKH.DataSource = buskhachhang.DanhSachKH();
            dtgvKH.Columns[0].HeaderText = "Họ tên";
            dtgvKH.Columns[1].HeaderText = "Số điện thoại";
            dtgvKH.Columns[2].HeaderText = "Địa chỉ";
            dtgvKH.Columns[3].HeaderText = "Phái";
            dtgvKH.Columns[3].ReadOnly = true;
            dtgvKH.Columns[4].HeaderText = "Mã Khách hàng";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void ResetValue()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtSDT.Enabled = false;
            txtHoten.Enabled = false;
            txtDiachi.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
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



        // check sdt

        #endregion

        
    }
}
