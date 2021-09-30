using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FMain : Form
    {
        // hello git hub
        public FMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.ShowInTaskbar = false;
           
        }
        #region Event
        public void ITEMMNSDANGNHAP_Click(object sender, EventArgs e)
        {
            FLogin dn = new FLogin();
           
            if (!CheckExitsChildForm("FLogin"))
            {
                dn.MdiParent = this;
                dn.Show();
            }
            else
            {
                ActiveChildForm("FLogin");
            }
        }
        #endregion
        #region     Code nghiep vu
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

        private void FMain_Load(object sender, EventArgs e)
        {

        }
    }
}
