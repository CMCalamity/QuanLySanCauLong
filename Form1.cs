using System;
using System.Linq;
using System.Windows.Forms;
using QuanLySan.Data;
using QuanLySan.Models;

namespace Desktop
{
    public partial class Form1 : Form
    {
        AppDbContext db = new AppDbContext();

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSearch.Click += btnSearch_Click;

            dgvMembers.CellClick += dgvMembers_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboType.Items.Clear();

            cboType.Items.Add("Thường");
            cboType.Items.Add("Bạc");
            cboType.Items.Add("Vàng");
            cboType.Items.Add("VIP");

            dgvMembers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMembers.MultiSelect = false;

            dgvMembers.ReadOnly = true;

            dgvMembers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();
        }

        public void LoadData()
        {
            dgvMembers.DataSource = db.KhachHangs
                .Select(x => new
                {
                    x.MaKH,
                    x.TenKH,
                    x.SDT,
                    x.DiemTichLuy,
                    x.Hang
                })
                .ToList();
        }

        private void ClearInput()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSearch.Clear();

            cboType.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" ||
                txtPhone.Text == "" ||
                cboType.Text == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!");

                return;
            }

            KhachHang kh = new KhachHang();

            kh.TenKH = txtName.Text;
            kh.SDT = txtPhone.Text;
            kh.DiemTichLuy = 0;
            kh.Hang = cboType.Text;

            db.KhachHangs.Add(kh);

            db.SaveChanges();

            MessageBox.Show(
                "Thêm khách hàng thành công!");

            LoadData();

            ClearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần sửa!");

                return;
            }

            int maKH = Convert.ToInt32(
                dgvMembers.CurrentRow.Cells["MaKH"].Value);

            var kh = db.KhachHangs.Find(maKH);

            if (kh != null)
            {
                kh.TenKH = txtName.Text;
                kh.SDT = txtPhone.Text;
                kh.Hang = cboType.Text;

                db.SaveChanges();

                MessageBox.Show(
                    "Sửa khách hàng thành công!");

                LoadData();

                ClearInput();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần xóa!");

                return;
            }

            int maKH = Convert.ToInt32(
                dgvMembers.CurrentRow.Cells["MaKH"].Value);

            var kh = db.KhachHangs.Find(maKH);

            if (kh != null)
            {
                DialogResult result =
                    MessageBox.Show(
                        "Bạn có chắc muốn xóa không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.KhachHangs.Remove(kh);

                    db.SaveChanges();

                    MessageBox.Show(
                        "Xóa khách hàng thành công!");

                    LoadData();

                    ClearInput();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sdt = txtSearch.Text.Trim();

            dgvMembers.DataSource = db.KhachHangs
                .Where(x => x.SDT.Contains(sdt))
                .Select(x => new
                {
                    x.MaKH,
                    x.TenKH,
                    x.SDT,
                    x.DiemTichLuy,
                    x.Hang
                })
                .ToList();
        }

        private void dgvMembers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvMembers.Rows[e.RowIndex];

                txtName.Text =
                    row.Cells["TenKH"].Value?.ToString();

                txtPhone.Text =
                    row.Cells["SDT"].Value?.ToString();

                cboType.Text =
                    row.Cells["Hang"].Value?.ToString();

                txtAddress.Text = "";
            }
        }

        private void dgvMembers_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

        }
    }
}