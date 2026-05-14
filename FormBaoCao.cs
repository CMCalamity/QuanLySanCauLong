using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormBaoCao : Form
    {
        private long soTienNhanDuoc;

        // Constructor nhận tham số tiền
        public FormBaoCao(long tien)
        {
            InitializeComponent();
            soTienNhanDuoc = tien;

            // Hiển thị ngay khi form load
            if (lblTongTien != null)
            {
                lblTongTien.Text = soTienNhanDuoc.ToString("N0") + " VNĐ";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            // Thiết lập cột cho DataGridView
            dgvBaoCao.Columns.Clear();
            dgvBaoCao.Columns.Add("Ngay", "Ngày thanh toán");
            dgvBaoCao.Columns.Add("SoTien", "Số tiền");

            // Thêm dòng dữ liệu minh họa
            dgvBaoCao.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), soTienNhanDuoc.ToString("N0") + " đ");
        }

        private void lblTongDoanhThu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}