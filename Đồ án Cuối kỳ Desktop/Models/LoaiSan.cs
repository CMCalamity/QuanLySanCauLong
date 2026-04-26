using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class LoaiSan
    {
        [Key]
        public int MaLoai { get; set; }

        [Required, StringLength(50)]
        public string TenLoai { get; set; }
        public virtual ICollection<San> Sans { get; set; }
        public virtual ICollection<BangGia> BangGias { get; set; }
    }
}
