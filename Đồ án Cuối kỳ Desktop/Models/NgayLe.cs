using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class NgayLe
    {
        [Key]
        public DateTime Ngay { get; set; }

        [StringLength(100)]
        public string TenLe { get; set; }
    }
}
