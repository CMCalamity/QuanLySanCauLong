using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }

        [Required]
        public string TenDangNhap { get; set; }

        [Required]
        public string MatKhau { get; set; }
    }
}
