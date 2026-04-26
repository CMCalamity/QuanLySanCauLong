using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
        public int MaSan { get; set; }
        public int? MaKH { get; set; } // Nullable nếu khách lẻ

        public DateTime GioVao { get; set; } = DateTime.Now;
        public DateTime? GioRa { get; set; }

        public decimal TienSan { get; set; } = 0;
        public decimal TienDichVu { get; set; } = 0;
        public decimal PhuThu { get; set; } = 0;
        public decimal GiamGiaHoiVien { get; set; } = 0;
        public decimal TongTien { get; set; } = 0;
        public int TrangThaiThanhToan { get; set; } = 0;

        [ForeignKey("MaSan")]
        public virtual San San { get; set; }

        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
