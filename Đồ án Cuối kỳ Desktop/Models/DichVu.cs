using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class DichVu
    {
        [Key]
        public int MaDV { get; set; }

        [Required, StringLength(100)]
        public string TenDV { get; set; }

        [StringLength(20)]
        public string DonViTinh { get; set; }

        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; } = 0;

        [StringLength(500)]
        public string? HinhAnh { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
