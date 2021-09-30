
namespace QuanLyBanHang
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSDANGNHAP = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSDANGXUAT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ITEMMNSHSNV = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSTHOAT = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSSANPHAM = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSNHANVIEN = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSKHACHHANG = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSTHONGKESP = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSHDSD = new System.Windows.Forms.ToolStripMenuItem();
            this.ITEMMNSGTSP = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.thốngKêToolStripMenuItem,
            this.hướngDẫnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mnsQLBH";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ITEMMNSDANGNHAP,
            this.ITEMMNSDANGXUAT,
            this.toolStripSeparator1,
            this.ITEMMNSHSNV,
            this.ITEMMNSTHOAT});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(130, 36);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // ITEMMNSDANGNHAP
            // 
            this.ITEMMNSDANGNHAP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSDANGNHAP.Image = global::QuanLyBanHang.Properties.Resources.login;
            this.ITEMMNSDANGNHAP.Name = "ITEMMNSDANGNHAP";
            this.ITEMMNSDANGNHAP.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.ITEMMNSDANGNHAP.Size = new System.Drawing.Size(305, 30);
            this.ITEMMNSDANGNHAP.Text = "Đăng nhập";
            this.ITEMMNSDANGNHAP.Click += new System.EventHandler(this.ITEMMNSDANGNHAP_Click);
            // 
            // ITEMMNSDANGXUAT
            // 
            this.ITEMMNSDANGXUAT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSDANGXUAT.Image = global::QuanLyBanHang.Properties.Resources.logout;
            this.ITEMMNSDANGXUAT.Name = "ITEMMNSDANGXUAT";
            this.ITEMMNSDANGXUAT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ITEMMNSDANGXUAT.Size = new System.Drawing.Size(305, 30);
            this.ITEMMNSDANGXUAT.Text = "Đăng xuất";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(302, 6);
            // 
            // ITEMMNSHSNV
            // 
            this.ITEMMNSHSNV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSHSNV.Image = global::QuanLyBanHang.Properties.Resources.user;
            this.ITEMMNSHSNV.Name = "ITEMMNSHSNV";
            this.ITEMMNSHSNV.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.ITEMMNSHSNV.Size = new System.Drawing.Size(305, 30);
            this.ITEMMNSHSNV.Text = "Hồ sơ nhân viên";
            // 
            // ITEMMNSTHOAT
            // 
            this.ITEMMNSTHOAT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSTHOAT.Image = global::QuanLyBanHang.Properties.Resources.remove_button;
            this.ITEMMNSTHOAT.Name = "ITEMMNSTHOAT";
            this.ITEMMNSTHOAT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ITEMMNSTHOAT.Size = new System.Drawing.Size(305, 30);
            this.ITEMMNSTHOAT.Text = "Thoát";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ITEMMNSSANPHAM,
            this.ITEMMNSNHANVIEN,
            this.ITEMMNSKHACHHANG});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(139, 36);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // ITEMMNSSANPHAM
            // 
            this.ITEMMNSSANPHAM.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSSANPHAM.Image = global::QuanLyBanHang.Properties.Resources.box;
            this.ITEMMNSSANPHAM.Name = "ITEMMNSSANPHAM";
            this.ITEMMNSSANPHAM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.ITEMMNSSANPHAM.Size = new System.Drawing.Size(267, 30);
            this.ITEMMNSSANPHAM.Text = "Sản phẩm";
            // 
            // ITEMMNSNHANVIEN
            // 
            this.ITEMMNSNHANVIEN.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSNHANVIEN.Image = global::QuanLyBanHang.Properties.Resources.service;
            this.ITEMMNSNHANVIEN.Name = "ITEMMNSNHANVIEN";
            this.ITEMMNSNHANVIEN.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.ITEMMNSNHANVIEN.Size = new System.Drawing.Size(267, 30);
            this.ITEMMNSNHANVIEN.Text = "Nhân viên";
            // 
            // ITEMMNSKHACHHANG
            // 
            this.ITEMMNSKHACHHANG.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSKHACHHANG.Image = global::QuanLyBanHang.Properties.Resources.user1;
            this.ITEMMNSKHACHHANG.Name = "ITEMMNSKHACHHANG";
            this.ITEMMNSKHACHHANG.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.ITEMMNSKHACHHANG.Size = new System.Drawing.Size(267, 30);
            this.ITEMMNSKHACHHANG.Text = "Khách hàng";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ITEMMNSTHONGKESP});
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(130, 36);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // ITEMMNSTHONGKESP
            // 
            this.ITEMMNSTHONGKESP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMMNSTHONGKESP.Image = global::QuanLyBanHang.Properties.Resources.financial_statement;
            this.ITEMMNSTHONGKESP.Name = "ITEMMNSTHONGKESP";
            this.ITEMMNSTHONGKESP.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.ITEMMNSTHONGKESP.Size = new System.Drawing.Size(325, 30);
            this.ITEMMNSTHONGKESP.Text = "Thống kê sản phẩm";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ITEMMNSHDSD,
            this.ITEMMNSGTSP});
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(149, 36);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng dẫn";
            // 
            // ITEMMNSHDSD
            // 
            this.ITEMMNSHDSD.Name = "ITEMMNSHDSD";
            this.ITEMMNSHDSD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.ITEMMNSHDSD.Size = new System.Drawing.Size(395, 36);
            this.ITEMMNSHDSD.Text = "Hướng dẫn sử dụng";
            // 
            // ITEMMNSGTSP
            // 
            this.ITEMMNSGTSP.Name = "ITEMMNSGTSP";
            this.ITEMMNSGTSP.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.ITEMMNSGTSP.Size = new System.Drawing.Size(395, 36);
            this.ITEMMNSGTSP.Text = "Giới thiệu sản phẩm";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = global::QuanLyBanHang.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(982, 483);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSDANGNHAP;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSDANGXUAT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSHSNV;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSTHOAT;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSSANPHAM;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSNHANVIEN;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSKHACHHANG;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSTHONGKESP;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSHDSD;
        private System.Windows.Forms.ToolStripMenuItem ITEMMNSGTSP;
    }
}

