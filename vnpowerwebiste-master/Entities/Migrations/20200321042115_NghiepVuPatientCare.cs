using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioNet.Entities.Migrations
{
    public partial class NghiepVuPatientCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTiepNhan",
                table: "DanhMucTiepNhans",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 230, DateTimeKind.Local).AddTicks(7414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 10, 8, 44, 143, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTaoPhieu",
                table: "DanhMucPhieuSangLocs",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 223, DateTimeKind.Local).AddTicks(85),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 10, 8, 44, 135, DateTimeKind.Local).AddTicks(6884));

            migrationBuilder.CreateTable(
                name: "ChiTietDanhGiaChatLuongMauPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMauDanhGia = table.Column<int>(nullable: false),
                    IdDanhGiaChatLuongMau = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 238, DateTimeKind.Local).AddTicks(3433))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDanhGiaChatLuongMauPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDichVuDonViXetNghiemPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDichVuXetnghiem = table.Column<int>(nullable: false),
                    IdDonViXetNghiem = table.Column<int>(nullable: false),
                    UuTien = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 239, DateTimeKind.Local).AddTicks(287))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDichVuDonViXetNghiemPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKetLuanDichVuPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKetLuanDichVu = table.Column<int>(nullable: false),
                    IdDichVuXetNghiem = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 239, DateTimeKind.Local).AddTicks(6823))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKetLuanDichVuPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKetQuaMauMoTaPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKetQua = table.Column<int>(nullable: false),
                    KetQuaMauMoTa = table.Column<string>(nullable: true),
                    KetLuanMauMoTa = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 240, DateTimeKind.Local).AddTicks(3367))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKetQuaMauMoTaPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKetQuaThongSoPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKetQua = table.Column<int>(nullable: false),
                    GiaTriMin = table.Column<string>(nullable: true),
                    GiaTriMax = table.Column<string>(nullable: true),
                    GiaTriTrungBinh = table.Column<string>(nullable: true),
                    GiaTriCuoi = table.Column<string>(nullable: true),
                    STT = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 240, DateTimeKind.Local).AddTicks(9981)),
                    KetLuan = table.Column<string>(nullable: true),
                    KetLuanEn = table.Column<string>(nullable: true),
                    isMauXNLai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKetQuaThongSoPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKetQuaTongQuatPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKetQuaTongQuat = table.Column<int>(nullable: false),
                    IdKetQua = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 241, DateTimeKind.Local).AddTicks(6579))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKetQuaTongQuatPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietLoaiMauDichVuPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLoaiMau = table.Column<int>(nullable: false),
                    IdDichVuXetNghiem = table.Column<int>(nullable: false),
                    UuTien = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 242, DateTimeKind.Local).AddTicks(3131))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietLoaiMauDichVuPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhanMauPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNhanMau = table.Column<int>(nullable: false),
                    IdLoaiMau = table.Column<int>(nullable: false),
                    IdChiTietTiepNhan = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 242, DateTimeKind.Local).AddTicks(9661))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhanMauPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietTiepNhanPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDichVuXetNghiem = table.Column<int>(nullable: false),
                    IdTiepNhan = table.Column<int>(nullable: false),
                    NgayChiDinh = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 243, DateTimeKind.Local).AddTicks(6224))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietTiepNhanPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaChatLuongMauPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNhanVienDanhGia = table.Column<int>(nullable: false),
                    NgayDanhGia = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 244, DateTimeKind.Local).AddTicks(2830)),
                    LyDo = table.Column<string>(nullable: true),
                    IdChiTietNhanMau = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaChatLuongMauPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KetLuanTheoGoiPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKetLuanTheoGoi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetLuanTheoGoiPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNhanVienTraKetQua = table.Column<int>(nullable: false),
                    IdDichVuXetNghiem = table.Column<int>(nullable: false),
                    NgayTiepNhan = table.Column<DateTime>(nullable: false),
                    NgayChiDinh = table.Column<DateTime>(nullable: false),
                    NgayLamXetNghiem = table.Column<DateTime>(nullable: false),
                    NgayTraKetQua = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 245, DateTimeKind.Local).AddTicks(5887)),
                    NgayCoKetQua = table.Column<DateTime>(nullable: false),
                    isDuyet = table.Column<bool>(nullable: false),
                    isTraKetQua = table.Column<bool>(nullable: false),
                    isNguyCoCao = table.Column<bool>(nullable: false),
                    KetLuan = table.Column<string>(nullable: true),
                    KetLuanEn = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaTongQuatPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTiepNhan = table.Column<int>(nullable: false),
                    IdKetLuanTheoGoi = table.Column<int>(nullable: false),
                    IdNhanVienTraKetQua = table.Column<int>(nullable: false),
                    NgayTraKetQua = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 246, DateTimeKind.Local).AddTicks(2819)),
                    KetLuan = table.Column<string>(nullable: true),
                    LuuY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaTongQuatPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanMauPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhanMau = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 246, DateTimeKind.Local).AddTicks(9486)),
                    GhiChu = table.Column<string>(nullable: true),
                    isDat = table.Column<bool>(nullable: false),
                    IdTiepNhan = table.Column<int>(nullable: false),
                    IdNhanVienNhanMau = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanMauPatientCares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiepNhanPatientCares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKhachHang = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 247, DateTimeKind.Local).AddTicks(6065)),
                    IdNhanVienTao = table.Column<int>(nullable: false),
                    IdChiTietKetQua_SLSS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiepNhanPatientCares", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietDichVuDonViXetNghiemPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietKetLuanDichVuPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietKetQuaMauMoTaPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietKetQuaThongSoPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietKetQuaTongQuatPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietLoaiMauDichVuPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietNhanMauPatientCares");

            migrationBuilder.DropTable(
                name: "ChiTietTiepNhanPatientCares");

            migrationBuilder.DropTable(
                name: "DanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropTable(
                name: "KetLuanTheoGoiPatientCares");

            migrationBuilder.DropTable(
                name: "KetQuaPatientCares");

            migrationBuilder.DropTable(
                name: "KetQuaTongQuatPatientCares");

            migrationBuilder.DropTable(
                name: "NhanMauPatientCares");

            migrationBuilder.DropTable(
                name: "TiepNhanPatientCare");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTiepNhan",
                table: "DanhMucTiepNhans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 10, 8, 44, 143, DateTimeKind.Local).AddTicks(2553),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 230, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTaoPhieu",
                table: "DanhMucPhieuSangLocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 10, 8, 44, 135, DateTimeKind.Local).AddTicks(6884),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 223, DateTimeKind.Local).AddTicks(85));
        }
    }
}
