
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKhoSanPham = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(890, 360);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnKhoSanPham
            // 
            this.btnKhoSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoSanPham.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoSanPham.Location = new System.Drawing.Point(330, 2);
            this.btnKhoSanPham.Name = "btnKhoSanPham";
            this.btnKhoSanPham.Size = new System.Drawing.Size(332, 41);
            this.btnKhoSanPham.TabIndex = 3;
            this.btnKhoSanPham.Text = "Thống kê sản phẩm tồn kho";
            this.btnKhoSanPham.UseVisualStyleBackColor = true;
            this.btnKhoSanPham.Click += new System.EventHandler(this.btnKhoSanPham_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thống kê sản phẩm nhập";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FThongKeSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 425);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnKhoSanPham);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FThongKeSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ThongKeSanPham";
            this.Load += new System.EventHandler(this.FThongKeSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnKhoSanPham;
        private System.Windows.Forms.Button button1;
    }
}