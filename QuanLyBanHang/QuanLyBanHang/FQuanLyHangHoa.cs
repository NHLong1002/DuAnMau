using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;
namespace QuanLyBanHang
{
    public partial class FQuanLyHangHoa : Form
    {
        BUS_HangHoa bushanghoa = new BUS_HangHoa();
        string checkUrlImage;// kiểm tra hình khi cập nhật
        string filename; // tên file
        string filesavePath; // url store images
        string fileAddress; // url load images

        public FQuanLyHangHoa()
        {
            InitializeComponent();
        }
        #region Events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void FQuanLyHangHoa_Load(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtGhichu.Enabled = true;
            txtDongiaban.Enabled = true;
            txtDongianhap.Enabled = true;
            txtHinh.Enabled = true;
            txtSoluong.Enabled = true;
            txtTenhang.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThemHinh.Enabled = true;

        }
        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Title = "Chọn hình minh họa cho sản phẩm";
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            if(dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pictureBox1.Image = Image.FromFile(fileAddress);
                filename = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                filesavePath = saveDirectory + "\\Images\\" + filename; // combine with file name
                txtHinh.Text = "\\Images\\" + filename;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int Soluong;
            bool isInt = int.TryParse(txtSoluong.Text.Trim().ToString(), out Soluong); // ép kiểu để kiểm tra số hay chữ
            float Dongianhap;
            bool isFloatnhap = float.TryParse(txtDongianhap.Text.Trim().ToString(), out Dongianhap);
            float Dongiaban;
            bool isFloatban = float.TryParse(txtDongiaban.Text.Trim().ToString(), out Dongiaban);
            if(txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if (!isInt || int.Parse(txtSoluong.Text)<0)
            {
                MessageBox.Show("Số lượng bạn nhập vào không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if(!isFloatban || float.Parse(txtDongiaban.Text) < 0)
            {
                MessageBox.Show("Đơn giá bán không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(!isFloatnhap || float.Parse(txtDongianhap.Text) < 0)
            {
                MessageBox.Show("Đơn giá nhập không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtHinh.Text.Trim().Length == 0) // kt phải nhập hình
            {
                MessageBox.Show("Bạn chưa nhập hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHinh.Focus();
                return;
            }
            else
            {
                DTO_Hang hang = new DTO_Hang();
                hang.TenHang = txtTenhang.Text;
                hang.SoLuong = Soluong;
                hang.DonGiaNhap = Dongianhap;
                hang.DonGiaBan = Dongiaban;
                hang.HinhAnh = "\\Images\\" + filename;
                hang.GhiChu = txtGhichu.Text;
                if (bushanghoa.NhapHangHoa(hang,FMain.email))
                {

                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Copy(fileAddress, filesavePath, true); // copy hình ảnh vào ứng dụng
                    ResetValue();
                    LoadGridView();

                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int Soluong;
            bool isInt = int.TryParse(txtSoluong.Text.Trim().ToString(), out Soluong); // ép kiểu để kiểm tra số hay chữ
            float Dongianhap;
            bool isFloatnhap = float.TryParse(txtDongianhap.Text.Trim().ToString(), out Dongianhap);
            float Dongiaban;
            bool isFloatban = float.TryParse(txtDongiaban.Text.Trim().ToString(), out Dongiaban);
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!isInt || int.Parse(txtSoluong.Text) < 0)
            {
                MessageBox.Show("Số lượng bạn nhập vào không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!isFloatban || float.Parse(txtDongiaban.Text) < 0)
            {
                MessageBox.Show("Đơn giá bán không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!isFloatnhap || float.Parse(txtDongianhap.Text) < 0)
            {
                MessageBox.Show("Đơn giá nhập không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtHinh.Text.Trim().Length == 0) // kt phải nhập hình
            {
                MessageBox.Show("Bạn chưa nhập hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHinh.Focus();
                return;
            }
            else
            {
                DTO_Hang hang = new DTO_Hang();
                hang.MaHang = int.Parse(txtMahang.Text);
                hang.TenHang = txtTenhang.Text;
                hang.SoLuong = Soluong;
                hang.DonGiaNhap = Dongianhap;
                hang.DonGiaBan = Dongiaban;
                hang.HinhAnh = "\\Images\\" + filename;
                hang.GhiChu = txtGhichu.Text;
                if(MessageBox.Show("Bạn có muốn cập nhật không ?","Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bushanghoa.CapNhatHangHoa(hang,FMain.email))
                    {
                        if (txtHinh.Text != checkUrlImage)// nếu có thay đổi hình
                            File.Copy(fileAddress, filesavePath, true); // copy hình vào ứng dụng
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValue();
                        LoadGridView();

                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc là muốn xóa ?","Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bushanghoa.XoaHangHoa(int.Parse(txtMahang.Text));
                MessageBox.Show("Xóa  thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValue();
                LoadGridView();
            }
            else
            {
                MessageBox.Show("Xóa không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTim.Text.Trim().Length > 0)
            {

                dataGridView1.DataSource = bushanghoa.TimHangHoa(txtTim.Text);
                dataGridView1.Columns[0].HeaderText = "Mã hàng";
                dataGridView1.Columns[1].HeaderText = "Tên hàng";
                dataGridView1.Columns[2].HeaderText = "Số lượng";
                dataGridView1.Columns[3].HeaderText = "Đơn giá nhập";
                dataGridView1.Columns[4].HeaderText = "Đơn giá bán";
                dataGridView1.Columns[5].HeaderText = "Hình ảnh";
                dataGridView1.Columns[6].HeaderText = "Ghi chú";
                dataGridView1.Columns[7].HeaderText = "Mã NV";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ResetValue();
            LoadGridView();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.Value.ToString() == "")
            {
                MessageBox.Show("Dữ liệu trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                txtMahang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenhang.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSoluong.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDongianhap.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDongiaban.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtHinh.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtGhichu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                checkUrlImage = txtHinh.Text;
                txtGhichu.Enabled = true;
                txtDongiaban.Enabled = true;
                txtDongianhap.Enabled = true;
                txtHinh.Enabled = true;
                txtSoluong.Enabled = true;
                txtTenhang.Enabled = true;
                btnLuu.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThemHinh.Enabled = true;
                pictureBox1.Image = Image.FromFile(saveDirectory + dataGridView1.CurrentRow.Cells[5].Value.ToString());
            }
        }
        #endregion
        #region Codes
        private void ResetValue()
        {
            txtGhichu.Enabled = false;
            txtDongiaban.Enabled = false;
            txtDongianhap.Enabled = false;
            txtHinh.Enabled = false;
            txtMahang.ReadOnly = true;
            txtSoluong.Enabled = false;
            txtTenhang.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThemHinh.Enabled = false;
        }

        private void LoadGridView()
        {
            dataGridView1.DataSource = bushanghoa.danhsachHang();
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn giá nhập";
            dataGridView1.Columns[4].HeaderText = "Đơn giá bán";
            dataGridView1.Columns[5].HeaderText = "Hình ảnh";
            dataGridView1.Columns[6].HeaderText = "Ghi chú";
            dataGridView1.Columns[7].HeaderText = "Mã NV";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }
        #endregion

        
    }
}
