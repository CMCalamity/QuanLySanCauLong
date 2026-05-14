using System.Data.Entity;
using QuanLySan.Models;

namespace QuanLySan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLySanCauLong;Integrated Security=True")
        {
        }

        public DbSet<KhachHang> KhachHangs { get; set; }
    }
}