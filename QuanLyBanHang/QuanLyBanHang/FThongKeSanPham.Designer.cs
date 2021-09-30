
namespace QuanLyBanHang
{
    partial class FThongKeSanPham
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
            this.mnsThongke = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sảnPhẩmNhâpKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mnsThongke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsThongke
            // 
            this.mnsThongke.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnsThongke.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsThongke.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sảnPhẩmNhâpKhoToolStripMenuItem,
            this.sảnPhẩmTồnKhoToolStripMenuItem});
            this.mnsThongke.Location = new System.Drawing.Point(0, 0);
            this.mnsThongke.Name = "mnsThongke";
            this.mnsThongke.Size = new System.Drawing.Size(800, 33);
            this.mnsThongke.TabIndex = 0;
            this.mnsThongke.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // sảnPhẩmNhâpKhoToolStripMenuItem
            // 
            this.sảnPhẩmNhâpKhoToolStripMenuItem.Name = "sảnPhẩmNhâpKhoToolStripMenuItem";
            this.sảnPhẩmNhâpKhoToolStripMenuItem.Size = new System.Drawing.Size(194, 29);
            this.sảnPhẩmNhâpKhoToolStripMenuItem.Text = "Sản phẩm nhâp kho";
            // 
            // sảnPhẩmTồnKhoToolStripMenuItem
            // 
            this.sảnPhẩmTồnKhoToolStripMenuItem.Name = "sảnPhẩmTồnKhoToolStripMenuItem";
            this.sảnPhẩmTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.sảnPhẩmTồnKhoToolStripMenuItem.Text = "Sản phẩm tồn kho";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 339);
            this.dataGridView1.TabIndex = 2;
            // 
            // FThongKeSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 387);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mnsThongke);
            this.MainMenuStrip = this.mnsThongke;
            this.Name = "FThongKeSanPham";
            this.Text = "ThongKeSanPham";
            this.mnsThongke.ResumeLayout(false);
            this.mnsThongke.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsThongke;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmNhâpKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmTồnKhoToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}