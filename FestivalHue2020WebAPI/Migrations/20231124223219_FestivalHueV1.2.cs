using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue2020WebAPI.Migrations
{
    public partial class FestivalHueV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinh_LichDien_LichDienId",
                table: "ChuongTrinh");

            migrationBuilder.DropIndex(
                name: "IX_ChuongTrinh_LichDienId",
                table: "ChuongTrinh");

            migrationBuilder.DropColumn(
                name: "LichDienId",
                table: "ChuongTrinh");

            migrationBuilder.AddColumn<int>(
                name: "LichDienIdId",
                table: "ChuongTrinh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinh_LichDienIdId",
                table: "ChuongTrinh",
                column: "LichDienIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinh_LichDien_LichDienIdId",
                table: "ChuongTrinh",
                column: "LichDienIdId",
                principalTable: "LichDien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChuongTrinh_LichDien_LichDienIdId",
                table: "ChuongTrinh");

            migrationBuilder.DropIndex(
                name: "IX_ChuongTrinh_LichDienIdId",
                table: "ChuongTrinh");

            migrationBuilder.DropColumn(
                name: "LichDienIdId",
                table: "ChuongTrinh");

            migrationBuilder.AddColumn<int>(
                name: "LichDienId",
                table: "ChuongTrinh",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinh_LichDienId",
                table: "ChuongTrinh",
                column: "LichDienId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuongTrinh_LichDien_LichDienId",
                table: "ChuongTrinh",
                column: "LichDienId",
                principalTable: "LichDien",
                principalColumn: "Id");
        }
    }
}
