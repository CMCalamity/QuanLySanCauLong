using System;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FormBanHang : Form

    {
        // Lưu số lượng tồn kho cho từng món (Key là tên món, Value là số lượng)
        Dictionary<string, int> khoHang = new Dictionary<string, int>()
{
    { "Nước suối Lavie", 50 },
    { "Sting dâu / Bò húc", 24 },
    { "Nước điện giải Revive", 30 },
    { "Thuê vợt Victor", 10 }
};


        // Cấu trúc lưu thông tin mỗi tờ hóa đơn
        public class LichSuBanHang
        {
            public DateTime NgayBan { get; set; }
            public string TenKhach { get; set; }
            public long TongTien { get; set; }
        }

        // Danh sách static để các Form khác cũng nhìn thấy được
        public static List<LichSuBanHang> danhSachLichSu = new List<LichSuBanHang>();

        // ==================== THÊM DÒNG NÀY ====================
        private string thuMucAnh = @"Images\";   // Đường dẫn tới thư mục chứa ảnh

        // Các biến khác của bạn...
        public static int TongDoanhThuCa = 0; // Biến dùng chung để lưu tiền
        private string tenDichVu;

        public FormBanHang()
        {
            InitializeComponent();
        }

        // ================= LOAD FORM =================
        private void FormBanHang_Load(object sender, EventArgs e)
        {
            // ================= SETUP DANH SÁCH SẢN PHẨM =================
            cboSanPham.Items.Clear();
            cboSanPham.DisplayMember = "Ten";
            cboSanPham.ValueMember = "Gia";

            cboSanPham.Items.Add(new { Ma = "SP01", Ten = "Nước suối", Gia = 10000 });
            cboSanPham.Items.Add(new { Ma = "SP02", Ten = "Thuê vợt", Gia = 30000 });
            cboSanPham.Items.Add(new { Ma = "SP03", Ten = "Khăn lạnh", Gia = 5000 });
            cboSanPham.Items.Add(new { Ma = "SP04", Ten = "Nước ngọt", Gia = 15000 });
            cboSanPham.Items.Add(new { Ma = "SP05", Ten = "Bia", Gia = 25000 });
            cboSanPham.Items.Add(new { Ma = "SP06", Ten = "Thuê giày", Gia = 20000 });

            // ================= SETUP DATAGRIDVIEW =================
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add("MaSP", "Mã SP");
            dgvHoaDon.Columns.Add("TenSP", "Tên sản phẩm");
            dgvHoaDon.Columns.Add("SoLuong", "Số lượng");
            dgvHoaDon.Columns.Add("DonGia", "Đơn giá");
            dgvHoaDon.Columns.Add("ThanhTien", "Thành tiền");

            // Định dạng cột cho đẹp
            dgvHoaDon.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvHoaDon.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // ================= CHỌN SẢN PHẨM =================
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem != null)
            {
                dynamic sp = cboSanPham.SelectedItem;

                txtMa.Text = sp.Ma;
                txtTen.Text = sp.Ten;
                txtGia.Text = sp.Gia.ToString();
            }
        }

        private void btnBaoCao_Click_1(object sender, EventArgs e)
        {
            FormBaoCao f = new FormBaoCao(TongDoanhThuCa); // Truyền biến doanh thu vào
            f.ShowDialog();
        }

        // ================= THÊM SẢN PHẨM =================
        // --- Đây là hàm thực hiện khi bấm nút Thêm ---
        // --- ĐÂY LÀ HÀM NÚT THÊM ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Lấy tên sản phẩm
            string tenSP = txtTen.Text;

            // 2. Kiểm tra nếu chưa nhập số lượng
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng!");
                return;
            }

            // 3. KIỂM TRA NẾU Ô GIÁ BỊ TRỐNG (Đoạn này giúp sửa lỗi FormatException)
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để hiển thị giá trước khi thêm!");
                return;
            }

            // 4. Chuyển đổi dữ liệu sau khi đã kiểm tra an toàn
            int slMua = int.Parse(txtSoLuong.Text);
            int gia = int.Parse(txtGia.Text);

            // 5. Kiểm tra tồn kho hàng
            if (khoHang.ContainsKey(tenSP))
            {
                if (slMua > khoHang[tenSP])
                {
                    MessageBox.Show($"Kho không đủ! {tenSP} chỉ còn {khoHang[tenSP]}", "Cảnh báo");
                    return;
                }
            }

            // 6. Tính tiền và thêm vào bảng (DataGridView)
            int thanhTien = slMua * gia;
            dgvHoaDon.Rows.Add(txtMa.Text, tenSP, slMua, gia, thanhTien);

            // 7. Cập nhật tổng tiền cuối cùng
            tinhTongTien();
        } // <--- DẤU NGOẶC NÀY KẾT THÚC HÀM btnThem

        // --- ĐÂY LÀ HÀM TÍNH TỔNG TIỀN (NẰM RIÊNG BIỆT) ---
        private void tinhTongTien()
        {
            long tong = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    tong += Convert.ToInt64(row.Cells[4].Value);
                }
            }
            txtTongTien.Text = tong.ToString("N0") + " đ";
        } // <--- DẤU NGOẶC NÀY KẾT THÚC HÀM tinhTongTien

        // ================= XOÁ =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvHoaDon.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgvHoaDon.Rows.Remove(row);
                }

                CapNhatTongTien();
            }
            else
            {
                MessageBox.Show("Chọn dòng để xoá!");
            }
        }

        // ================= TỔNG TIỀN =================
        private void CapNhatTongTien()
        {
            int tong = 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tong += Convert.ToInt32(row.Cells["ThanhTien"].Value);
                }
            }

            txtTongTien.Text = tong.ToString("N0") + " đ";
        }

        // ================= THANH TOÁN =================
        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra nếu bảng đang trống thì không làm gì cả
            if (dgvHoaDon.Rows.Count == 0 || dgvHoaDon.Rows[0].IsNewRow) return;

            // 1. Lấy số tiền và làm sạch chuỗi để tính toán
            string soTienThuan = txtTongTien.Text.Replace(" đ", "").Replace(",", "").Replace(".", "");

            // 2. TRỪ KHO THỰC TẾ
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    string tenSP = row.Cells[1].Value.ToString();
                    int slMua = Convert.ToInt32(row.Cells[2].Value);

                    // Trừ số lượng trong Dictionary khoHang
                    if (khoHang.ContainsKey(tenSP))
                    {
                        khoHang[tenSP] -= slMua;
                    }
                }
            }

            // 3. HIỆN MÃ QR
            FormQR frm = new FormQR(soTienThuan);
            frm.ShowDialog();

            // 4. LƯU LỊCH SỬ (Để làm báo cáo Bước 4)
            danhSachLichSu.Add(new LichSuBanHang
            {
                NgayBan = DateTime.Now,
                TenKhach = "Khách lẻ", // Nếu có ô txtTenKhach thì đổi thành txtTenKhach.Text
                TongTien = Convert.ToInt64(soTienThuan)
            });

            // 5. THÔNG BÁO VÀ LÀM TRỐNG BẢNG ĐỂ TIẾP KHÁCH MỚI
            MessageBox.Show("Thanh toán thành công và đã lưu vào báo cáo!", "Thông báo");
            dgvHoaDon.Rows.Clear();

            // Gọi hàm tính tiền để ô Tổng tiền về 0 đ
            tinhTongTien();
        }

        // ================= BÁO CÁO =================
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            // Mở FormBaoCao và truyền biến TongDoanhThuCa (tổng tiền tích lũy) sang
            // Lưu ý: Phải dùng đúng tên biến TongDoanhThuCa bạn đã cộng dồn ở nút Thanh toán
            FormBaoCao frm = new FormBaoCao(TongDoanhThuCa);
            frm.ShowDialog();
        }

        // ================= EVENT PHỤ =================
        private void txtSoLuong_TextChanged(object sender, EventArgs e) { }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        private void FormBanHang_Load_1(object sender, EventArgs e)
        {
            // Xóa danh sách cũ trước khi nạp mới
            cboSanPham.Items.Clear();

            // --- NHÓM DỊCH VỤ THUÊ SÂN (Nhiệm vụ Thành viên 1 & 4) ---
            cboSanPham.Items.Add(new { Ma = "S01", Ten = "Thuê sân đơn (1 giờ)", Gia = 50000 });
            cboSanPham.Items.Add(new { Ma = "S02", Ten = "Thuê sân đôi (1 giờ)", Gia = 80000 });
            cboSanPham.Items.Add(new { Ma = "S03", Ten = "Thuê sân giải đấu (1 giờ)", Gia = 150000 });

            // --- NHÓM DỤNG CỤ THỂ THAO (Nhiệm vụ Thành viên 4) [cite: 16] ---
            cboSanPham.Items.Add(new { Ma = "V01", Ten = "Thuê vợt Yonex", Gia = 30000 });
            cboSanPham.Items.Add(new { Ma = "V02", Ten = "Thuê vợt Victor", Gia = 25000 });
            cboSanPham.Items.Add(new { Ma = "G01", Ten = "Thuê giày cầu lông", Gia = 20000 });
            cboSanPham.Items.Add(new { Ma = "C01", Ten = "Ống cầu (12 quả)", Gia = 220000 });
            cboSanPham.Items.Add(new { Ma = "C02", Ten = "Cầu lẻ (1 quả)", Gia = 20000 });

            // --- NHÓM GIẢI KHÁT & ĐỒ ĂN (Nhiệm vụ Thành viên 4) [cite: 16] ---
            cboSanPham.Items.Add(new { Ma = "N01", Ten = "Nước suối Aquafina", Gia = 10000 });
            cboSanPham.Items.Add(new { Ma = "N02", Ten = "Sting dâu / bò húc", Gia = 15000 });
            cboSanPham.Items.Add(new { Ma = "N03", Ten = "Nước điện giải Revive", Gia = 15000 });
            cboSanPham.Items.Add(new { Ma = "N04", Ten = "Bia Heineken", Gia = 25000 });
            cboSanPham.Items.Add(new { Ma = "K01", Ten = "Khăn lạnh", Gia = 5000 });
            cboSanPham.Items.Add(new { Ma = "M01", Ten = "Mì ly xúc xích", Gia = 20000 });

            // Cấu hình hiển thị cho ComboBox
            cboSanPham.DisplayMember = "Ten";
            cboSanPham.ValueMember = "Gia";

            // --- SETUP BẢNG HÓA ĐƠN (DataGridView) ---
            if (dgvHoaDon.Columns.Count == 0)
            {
                dgvHoaDon.Columns.Add("MaSP", "Mã SP");
                dgvHoaDon.Columns.Add("TenSP", "Tên sản phẩm");
                dgvHoaDon.Columns.Add("SoLuong", "Số lượng");
                dgvHoaDon.Columns.Add("DonGia", "Đơn giá");
                dgvHoaDon.Columns.Add("ThanhTien", "Thành tiền");
            }
        }
        private void cboSanPham_SelectedInSdexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem != null)
            {
                // Lấy thông tin từ mục được chọn
                dynamic sp = cboSanPham.SelectedItem;

                // Tự động điền vào các ô để nhân viên không phải nhập tay
                txtMa.Text = sp.Ma;
                txtTen.Text = sp.Ten;
                txtGia.Text = sp.Gia.ToString();

                // Mặc định số lượng là 1 để nhân viên thao tác nhanh
                txtSoLuong.Text = "1";
            }
        }

        private void cboSanPham_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem == null) return;
            string mon = cboSanPham.SelectedItem.ToString();
            string path = Application.StartupPath + @"\Images\";

            // Xóa hình cũ trước khi hiện hình mới
            picHinhAnh.Image = null;

            // --- NHÓM THUÊ SÂN ---
            if (mon.Contains("Thuê sân đơn"))
            {
                txtMa.Text = "SD01"; txtTen.Text = mon; txtGia.Text = "50000";
            }
            else if (mon.Contains("Thuê sân đôi"))
            {
                txtMa.Text = "SD02"; txtTen.Text = mon; txtGia.Text = "80000";
            }
            else if (mon.Contains("giải đấu"))
            {
                txtMa.Text = "SGD"; txtTen.Text = mon; txtGia.Text = "150000";
            }

            // --- NHÓM DỤNG CỤ ---
            else if (mon.Contains("Yonex"))
            {
                txtMa.Text = "V01"; txtTen.Text = mon; txtGia.Text = "30000";
                if (System.IO.File.Exists(path + "yonex.jpg")) picHinhAnh.Image = Image.FromFile(path + "yonex.jpg");
            }
            else if (mon.Contains("Victor"))
            {
                txtMa.Text = "V02"; txtTen.Text = mon; txtGia.Text = "25000";
                if (System.IO.File.Exists(path + "victor.jpg")) picHinhAnh.Image = Image.FromFile(path + "victor.jpg");
            }
            else if (mon.Contains("giày"))
            {
                txtMa.Text = "G01"; txtTen.Text = mon; txtGia.Text = "20000";
            }
            else if (mon.Contains("Ống cầu"))
            {
                txtMa.Text = "C12"; txtTen.Text = mon; txtGia.Text = "200000";
            }

            // --- NHÓM NƯỚC UỐNG & ĐỒ ĂN ---
            else if (mon.Contains("Aquafina"))
            {
                txtMa.Text = "N01"; txtTen.Text = mon; txtGia.Text = "10000";
                if (System.IO.File.Exists(path + "aquafina.jpg")) picHinhAnh.Image = Image.FromFile(path + "aquafina.jpg");
            }
            else if (mon.Contains("Sting") || mon.Contains("bò húc"))
            {
                txtMa.Text = "N02"; txtTen.Text = mon; txtGia.Text = "15000";
                if (System.IO.File.Exists(path + "sting.jpg")) picHinhAnh.Image = Image.FromFile(path + "sting.jpg");
            }
            else if (mon.Contains("Revive"))
            {
                txtMa.Text = "N03"; txtTen.Text = mon; txtGia.Text = "15000";
                if (System.IO.File.Exists(path + "revive.jpg")) picHinhAnh.Image = Image.FromFile(path + "revive.jpg");
            }
            else if (mon.Contains("Heineken"))
            {
                txtMa.Text = "B01"; txtTen.Text = mon; txtGia.Text = "20000";
                if (System.IO.File.Exists(path + "heineken.jpg")) picHinhAnh.Image = Image.FromFile(path + "heineken.jpg");
            }
            else if (mon.Contains("Khăn lạnh"))
            {
                txtMa.Text = "K01"; txtTen.Text = mon; txtGia.Text = "5000";
                if (System.IO.File.Exists(path + "khan.jpg")) picHinhAnh.Image = Image.FromFile(path + "khan.jpg");
            }
            else if (mon.Contains("Mì ly"))
            {
                txtMa.Text = "M01"; txtTen.Text = mon; txtGia.Text = "15000";
                if (System.IO.File.Exists(path + "mily.jpg")) picHinhAnh.Image = Image.FromFile(path + "mily.jpg");
            }

            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
        }


        private void picHinhAnh_Click(object sender, EventArgs e)
        {

        }
    }



}