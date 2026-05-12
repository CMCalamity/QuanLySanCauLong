using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Đồ_án_Cuối_kỳ_Desktop.Migrations
{
    /// <inheritdoc />
    public partial class BoSungCotHinhAnh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "Sans",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "DichVus",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "Sans");

            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "DichVus");
        }
    }
}
