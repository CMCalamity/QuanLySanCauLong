using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class San
    {
        [Key]
        public int MaSan { get; set; }

        [Required, StringLength(50)]
        public string TenSan { get; set; }

        public int MaLoai { get; set; }
        public int TrangThai { get; set; } = 0; // 0: Trống, 1: Đang chơi, 2: Đặt trước

        [ForeignKey("MaLoai")]
        public virtual LoaiSan LoaiSan { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
