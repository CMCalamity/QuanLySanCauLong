using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class BangGia
    {
        [Key]
        public int MaGia { get; set; }
        public int MaLoai { get; set; }

        [StringLength(20)]
        public string LoaiNgay { get; set; } // NgayThuong, CuoiTuan...

        [StringLength(50)]
        public string TenKhungGio { get; set; }

        public TimeSpan TuGio { get; set; }
        public TimeSpan DenGio { get; set; }
        public decimal GiaTheoGio { get; set; }

        [ForeignKey("MaLoai")]
        public virtual LoaiSan LoaiSan { get; set; }
    }
}
