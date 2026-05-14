using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySan.Models
{
    [Table("KhachHangs")]
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        public string TenKH { get; set; }

        public string SDT { get; set; }

        public string DiaChi { get; set; }

        public int DiemTichLuy { get; set; }

        public string Hang { get; set; }
    }
}