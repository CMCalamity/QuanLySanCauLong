using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_Cuối_kỳ_Desktop.Models
{
    public class ChiTietHoaDon
    {
        public int MaHD { get; set; }
        public int MaDV { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }

        [ForeignKey("MaDV")]
        public virtual DichVu DichVu { get; set; }
    }
}
