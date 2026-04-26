using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Đồ_án_Cuối_kỳ_Desktop.Models; // Đảm bảo các file Model của bạn nằm trong namespace này

namespace Đồ_án_Cuối_kỳ_Desktop.Data
{
    public class QuanLySanCauLongContext : DbContext
    {
        // 1. KHAI BÁO CÁC BẢNG (DbSet)
        public DbSet<LoaiSan> LoaiSans { get; set; } = null!;
        public DbSet<San> Sans { get; set; } = null!;
        public DbSet<BangGia> BangGias { get; set; } = null!;
        public DbSet<NgayLe> NgayLes { get; set; } = null!;
        public DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public DbSet<DichVu> DichVus { get; set; } = null!;
        public DbSet<HoaDon> HoaDons { get; set; } = null!;
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;

        // 2. CẤU HÌNH KẾT NỐI
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thay "TEN_SERVER_CUA_BAN" bằng tên SQL Server 
                string connectionString = "Server=LAPTOP-448VUAA7\\SQLEXPRESS;Database=QuanLySanCauLong;Trusted_Connection=True;TrustServerCertificate=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // 3. CẤU HÌNH CÁC RÀNG BUỘC ĐẶC BIỆT (Fluent API)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình khóa chính phức hợp (Composite Key) cho bảng ChiTietHoaDon
            // Vì bảng này có khóa chính gồm 2 cột: MaHD và MaDV
            modelBuilder.Entity<ChiTietHoaDon>()
                .HasKey(ct => new { ct.MaHD, ct.MaDV });

            base.OnModelCreating(modelBuilder);
        }
    }
}

// Tạo Database (thông qua lệnh Add-Migration và Update-Database của EF Core trong Package Manager Console) để có SQL để chạy
//Vd Add-Migration KhoiTaoDataBase nó sẽ tạo ra file migration với tên KhoiTaoDataBase chứa các lệnh SQL để tạo bảng, sau đó chạy Update-Database để áp dụng các thay đổi này vào database thực tế.
