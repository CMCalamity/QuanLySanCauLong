using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [Required, StringLength(100)]
        public string TenKH { get; set; }

        [Required, StringLength(15)]
        public string SDT { get; set; }
        public string Sdt { get; internal set; }
        public int DiemTichLuy { get; set; } = 0;

        [StringLength(50)]
        public string Hang { get; set; } = "Thành viên";

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
