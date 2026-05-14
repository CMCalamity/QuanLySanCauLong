using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormQR : Form
    {
        public FormQR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FormQR(string soTien) // Nhận số tiền từ Form chính gửi qua
        {
            InitializeComponent();
            // Tạo mã QR (Hãy thay STK của bạn vào đây)
            string url = "https://img.vietqr.io/image/VCB-123456789-compact.png?amount=" + soTien;

            // Nạp ảnh vào PictureBox ở giữa FormQR
            pictureBox1.Load(url);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void FormQR_Load(object sender, EventArgs e)
        {

        }
    }
}
