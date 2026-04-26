using System;
using System.Collections.Generic;
using System.Linq;
using Đồ_án_Cuối_kỳ_Desktop.Data;
using Đồ_án_Cuối_kỳ_Desktop.Models;

namespace Đồ_án_Cuối_kỳ_Desktop.Services
{
    public class TinhToanTienService
    {
        private readonly QuanLySanCauLongContext _context;

        public TinhToanTienService(QuanLySanCauLongContext context)
        {
            _context = context;
        }

        public decimal TinhTienSan(int maSan, DateTime gioVao, DateTime gioRa)
        {
            // --- KIỂM TRA LỖI NHẬP LIỆU ---
            if (maSan <= 0)
                throw new ArgumentException("Vui lòng chọn một sân cụ thể.");

            if (gioVao == DateTime.MinValue)
                throw new ArgumentException("Giờ vào không hợp lệ.");

            if (gioRa <= gioVao)
                throw new Exception($"Lỗi thời gian: Giờ ra ({gioRa:HH:mm}) phải sau giờ vào ({gioVao:HH:mm}).");

            // Kiểm tra xem sân có tồn tại không
            var san = _context.Sans.Find(maSan);
            if (san == null)
                throw new Exception("Lỗi hệ thống: Không tìm thấy dữ liệu của sân này.");

            // --- XÁC ĐỊNH LOẠI NGÀY ---
            string loaiNgay = "NgayThuong";
            if (_context.NgayLes.Any(n => n.Ngay == gioVao.Date))
                loaiNgay = "NgayLe";
            else if (gioVao.DayOfWeek == DayOfWeek.Saturday || gioVao.DayOfWeek == DayOfWeek.Sunday)
                loaiNgay = "CuoiTuan";

            // --- LẤY BẢNG GIÁ ---
            var khungGias = _context.BangGias
                .Where(b => b.MaLoai == san.MaLoai && b.LoaiNgay == loaiNgay)
                .OrderBy(b => b.TuGio)
                .ToList();

            if (!khungGias.Any())
                throw new Exception($"Lỗi cấu hình: Chưa có bảng giá cho loại sân này vào ngày {loaiNgay}. Hãy cài đặt bảng giá trước.");

            // --- LOGIC TÍNH TIỀN GIAO THOA ---
            decimal tongTien = 0;
            bool coKhungGioPhuHop = false;

            foreach (var gia in khungGias)
            {
                // Tạo mốc thời gian đầy đủ cho khung giờ trong ngày đó
                DateTime mocBatDauKhung = gioVao.Date.Add(gia.TuGio);
                DateTime mocKetThucKhung = gioVao.Date.Add(gia.DenGio);

                // Tìm khoảng thời gian giao nhau giữa (gioVao - gioRa) và (mocBatDauKhung - mocKetThucKhung)
                DateTime giaoBatDau = gioVao > mocBatDauKhung ? gioVao : mocBatDauKhung;
                DateTime giaoKetThuc = gioRa < mocKetThucKhung ? gioRa : mocKetThucKhung;

                if (giaoBatDau < giaoKetThuc)
                {
                    coKhungGioPhuHop = true;
                    double soPhut = (giaoKetThuc - giaoBatDau).TotalMinutes;
                    decimal thanhTienKhung = (decimal)(soPhut / 60.0) * gia.GiaTheoGio;
                    tongTien += thanhTienKhung;
                }
            }

            if (!coKhungGioPhuHop)
                throw new Exception("Lỗi: Thời gian khách chơi không nằm trong bất kỳ khung giờ nào của bảng giá.");

            return Math.Round(tongTien, 0); // Làm tròn đến đồng
        }
    }
}