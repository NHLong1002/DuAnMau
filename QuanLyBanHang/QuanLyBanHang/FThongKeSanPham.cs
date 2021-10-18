using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
namespace QuanLyBanHang
{
    public partial class FThongKeSanPham : Form
    {
        BUS_HangHoa bushanghoa = new BUS_HangHoa();
        public FThongKeSanPham()
        {
            InitializeComponent();
        }

        #region Events
        private void FThongKeSanPham_Load(object sender, EventArgs e)
        {
            loadgridview_ThongKeSP();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadgridview_ThongKeSP();
        }
        private void btnKhoSanPham_Click(object sender, EventArgs e)
        {
            loadgridview_ThongKeSPTonKho();
        }
        #endregion
        #region Codes
        private void loadgridview_ThongKeSP()
        {
            dataGridView1.DataSource = bushanghoa.ThongkeHangHoa();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[3].HeaderText = "Số lượng nhập";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void loadgridview_ThongKeSPTonKho()
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.DataSource = bushanghoa.ThongKeHangTonKho();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[0].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[1].HeaderText = "Số lượng tồn kho";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }





        #endregion

      
    }
}
