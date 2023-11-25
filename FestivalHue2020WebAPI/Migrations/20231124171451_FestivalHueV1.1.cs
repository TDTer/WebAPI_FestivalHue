using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalHue2020WebAPI.Migrations
{
    public partial class FestivalHueV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaDiem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LichDien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Md5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichDien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuongTrinhName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuongTrinhContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeInoff = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TypeProgram = table.Column<int>(type: "int", nullable: false),
                    Arrange = table.Column<int>(type: "int", nullable: false),
                    Md5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LichDienId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuongTrinh_LichDien_LichDienId",
                        column: x => x.LichDienId,
                        principalTable: "LichDien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "chuongTrinhDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDoan = table.Column<int>(type: "int", nullable: false),
                    DoanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDiaDiem = table.Column<int>(type: "int", nullable: false),
                    DiaDiemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNhom = table.Column<int>(type: "int", nullable: false),
                    NhomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuongTrinhId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuongTrinhDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chuongTrinhDetail_ChuongTrinh_ChuongTrinhId",
                        column: x => x.ChuongTrinhId,
                        principalTable: "ChuongTrinh",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuongTrinhId = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<float>(type: "real", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QRCode = table.Column<int>(type: "int", nullable: false),
                    HopLe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ve_ChuongTrinh_ChuongTrinhId",
                        column: x => x.ChuongTrinhId,
                        principalTable: "ChuongTrinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuongTrinh_LichDienId",
                table: "ChuongTrinh",
                column: "LichDienId");

            migrationBuilder.CreateIndex(
                name: "IX_chuongTrinhDetail_ChuongTrinhId",
                table: "chuongTrinhDetail",
                column: "ChuongTrinhId");

            migrationBuilder.CreateIndex(
                name: "IX_Ve_ChuongTrinhId",
                table: "Ve",
                column: "ChuongTrinhId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chuongTrinhDetail");

            migrationBuilder.DropTable(
                name: "DiaDiem");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "Ve");

            migrationBuilder.DropTable(
                name: "ChuongTrinh");

            migrationBuilder.DropTable(
                name: "LichDien");
        }
    }
}
