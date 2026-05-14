namespace QuanLyBanHang
{
    partial class FormBanHang
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cboSanPham = new ComboBox();
            label2 = new Label();
            txtSoLuong = new TextBox();
            btnThem = new Button();
            btnXoa = new Button();
            dgvHoaDon = new DataGridView();
            label3 = new Label();
            txtTongTien = new TextBox();
            btnThanhToan = new Button();
            btnBaoCao = new Button();
            groupBox1 = new GroupBox();
            txtGia = new TextBox();
            txtTen = new TextBox();
            lblGia = new Label();
            lblTen = new Label();
            txtMa = new TextBox();
            vlblMa = new Label();
            picHinhAnh = new PictureBox();
            txtTenKhach = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 7);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Chọn dịch vụ:";
            // 
            // cboSanPham
            // 
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Items.AddRange(new object[] { "Sting dâu", "", "", "Revive chanh muối", "", "", "Bò húc (Redbull)", "", "", "Nước suối Aquafina", "", "", "Quấn cán vợt (loại tốt)", "", "", "Ống cầu lông (lẻ 1 quả)", "", "", "Thuê sân (Giờ cao điểm)" });
            cboSanPham.Location = new Point(28, 24);
            cboSanPham.Margin = new Padding(3, 2, 3, 2);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(224, 23);
            cboSanPham.TabIndex = 1;
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 47);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(28, 64);
            txtSoLuong.Margin = new Padding(3, 2, 3, 2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(224, 23);
            txtSoLuong.TabIndex = 3;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(133, 110);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(124, 22);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(5, 110);
            btnXoa.Margin = new Padding(3, 2, 3, 2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(124, 22);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(28, 152);
            dgvHoaDon.Margin = new Padding(3, 2, 3, 2);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(649, 149);
            dgvHoaDon.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 106);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 7;
            label3.Text = "Tổng tiền:";
            label3.Click += label3_Click;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(99, 100);
            txtTongTien.Margin = new Padding(3, 2, 3, 2);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(154, 23);
            txtTongTien.TabIndex = 8;
            txtTongTien.Text = "0 đ";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(420, 305);
            btnThanhToan.Margin = new Padding(3, 2, 3, 2);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(110, 22);
            btnThanhToan.TabIndex = 9;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click_1;
            // 
            // btnBaoCao
            // 
            btnBaoCao.Location = new Point(536, 305);
            btnBaoCao.Margin = new Padding(3, 2, 3, 2);
            btnBaoCao.Name = "btnBaoCao";
            btnBaoCao.Size = new Size(147, 22);
            btnBaoCao.TabIndex = 10;
            btnBaoCao.Text = "Báo cáo / Thống kê";
            btnBaoCao.UseVisualStyleBackColor = true;
            btnBaoCao.Click += btnBaoCao_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGia);
            groupBox1.Controls.Add(txtTen);
            groupBox1.Controls.Add(lblGia);
            groupBox1.Controls.Add(lblTen);
            groupBox1.Controls.Add(txtMa);
            groupBox1.Controls.Add(vlblMa);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Location = new Point(415, 7);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(262, 141);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // txtGia
            // 
            txtGia.Location = new Point(62, 77);
            txtGia.Margin = new Padding(3, 2, 3, 2);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(194, 23);
            txtGia.TabIndex = 11;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(62, 47);
            txtTen.Margin = new Padding(3, 2, 3, 2);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(194, 23);
            txtTen.TabIndex = 10;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(5, 82);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(27, 15);
            lblGia.TabIndex = 9;
            lblGia.Text = "Giá:";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(5, 52);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(29, 15);
            lblTen.TabIndex = 8;
            lblTen.Text = "Tên:";
            lblTen.Click += label5_Click;
            // 
            // txtMa
            // 
            txtMa.Location = new Point(62, 20);
            txtMa.Margin = new Padding(3, 2, 3, 2);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(194, 23);
            txtMa.TabIndex = 7;
            // 
            // vlblMa
            // 
            vlblMa.AutoSize = true;
            vlblMa.Location = new Point(5, 23);
            vlblMa.Name = "vlblMa";
            vlblMa.Size = new Size(27, 15);
            vlblMa.TabIndex = 6;
            vlblMa.Text = "Mã:";
            // 
            // picHinhAnh
            // 
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Location = new Point(257, 1);
            picHinhAnh.Margin = new Padding(3, 2, 3, 2);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(152, 138);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 12;
            picHinhAnh.TabStop = false;
            picHinhAnh.Click += picHinhAnh_Click;
            // 
            // txtTenKhach
            // 
            txtTenKhach.Location = new Point(308, 306);
            txtTenKhach.Name = "txtTenKhach";
            txtTenKhach.Size = new Size(100, 23);
            txtTenKhach.TabIndex = 13;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(txtTenKhach);
            Controls.Add(picHinhAnh);
            Controls.Add(groupBox1);
            Controls.Add(btnBaoCao);
            Controls.Add(btnThanhToan);
            Controls.Add(txtTongTien);
            Controls.Add(label3);
            Controls.Add(dgvHoaDon);
            Controls.Add(txtSoLuong);
            Controls.Add(label2);
            Controls.Add(cboSanPham);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormBanHang";
            Text = "Bán Hàng";
            Load += FormBanHang_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboSanPham;
        private Label label2;
        private TextBox txtSoLuong;
        private Button btnThem;
        private Button btnXoa;
        private DataGridView dgvHoaDon;
        private Label label3;
        private TextBox txtTongTien;
        private Button btnThanhToan;
        private Button btnBaoCao;
        private GroupBox groupBox1;
        private Label lblGia;
        private Label lblTen;
        private TextBox txtMa;
        private Label vlblMa;
        private TextBox txtGia;
        private TextBox txtTen;
        private PictureBox picHinhAnh;
        private TextBox txtTenKhach;
    }
}
