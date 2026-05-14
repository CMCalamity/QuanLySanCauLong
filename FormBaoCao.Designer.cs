namespace QuanLyBanHang
{
    partial class FormBaoCao
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
            dgvBaoCao = new DataGridView();
            lblTieuDe = new Label();
            lblTongTien = new TextBox();
            btnDong = new Button();
            lblTongDoanhThu = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(37, 21);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.Size = new Size(704, 188);
            dgvBaoCao.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(48, 248);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(224, 20);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "BÁO CÁO DOANH THU CỦA CA ";
            // 
            // lblTongTien
            // 
            lblTongTien.Location = new Point(48, 271);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(224, 27);
            lblTongTien.TabIndex = 2;
            lblTongTien.Text = "0 VNĐ";
            lblTongTien.TextChanged += textBox1_TextChanged;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(552, 239);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(155, 29);
            btnDong.TabIndex = 3;
            btnDong.Text = "Đóng báo cáo";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Location = new Point(48, 313);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(114, 20);
            lblTongDoanhThu.TabIndex = 4;
            lblTongDoanhThu.Text = "Xác nhận & Đóng";
            lblTongDoanhThu.Click += lblTongDoanhThu_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(383, 302);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // FormBaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(lblTongDoanhThu);
            Controls.Add(btnDong);
            Controls.Add(lblTongTien);
            Controls.Add(lblTieuDe);
            Controls.Add(dgvBaoCao);
            Name = "FormBaoCao";
            Text = "FormBaoCao";
            Load += FormBaoCao_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBaoCao;
        private Label lblTieuDe;
        private TextBox lblTongTien;
        private Button btnDong;
        private Label lblTongDoanhThu;
        private Label label1;
    }
}