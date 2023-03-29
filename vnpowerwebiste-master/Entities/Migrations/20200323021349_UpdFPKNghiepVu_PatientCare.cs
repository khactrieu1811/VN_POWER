using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioNet.Entities.Migrations
{
    public partial class UpdFPKNghiepVu_PatientCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhMucChiTietDanhGiaChatLuongMaus");

            migrationBuilder.DropTable(
                name: "DanhMucChiTietKetQuaThongSoXNs");

            migrationBuilder.DropTable(
                name: "DanhMucDanhGiaChatLuongMauNghiepVus");

            migrationBuilder.DropTable(
                name: "DanhMucChiTietKetQuaXN_SLSSs");

            migrationBuilder.DropTable(
                name: "DanhMucTiepNhans");

            migrationBuilder.DropTable(
                name: "DanhMucKetQuaXN_SLSS");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiTiepNhans");

            migrationBuilder.DropTable(
                name: "DanhMucPhieuSangLocs");

            migrationBuilder.DropColumn(
                name: "IdTiepNhan",
                table: "NhanMauPatientCares");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "TiepNhanPatientCare",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 200, DateTimeKind.Local).AddTicks(6990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 247, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayNhanMau",
                table: "NhanMauPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 198, DateTimeKind.Local).AddTicks(8241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 246, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.AddColumn<int>(
                name: "IdTiepNhanPatientCare",
                table: "NhanMauPatientCares",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTraKetQua",
                table: "KetQuaTongQuatPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 196, DateTimeKind.Local).AddTicks(7052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 246, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTraKetQua",
                table: "KetQuaPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 194, DateTimeKind.Local).AddTicks(8482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 245, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDanhGia",
                table: "DanhGiaChatLuongMauPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 192, DateTimeKind.Local).AddTicks(4946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 244, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayChiDinh",
                table: "ChiTietTiepNhanPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 190, DateTimeKind.Local).AddTicks(8117),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 243, DateTimeKind.Local).AddTicks(6224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietNhanMauPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 188, DateTimeKind.Local).AddTicks(7523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 242, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietLoaiMauDichVuPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 186, DateTimeKind.Local).AddTicks(8729),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 242, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetQuaTongQuatPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 185, DateTimeKind.Local).AddTicks(1928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 241, DateTimeKind.Local).AddTicks(6579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetQuaThongSoPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 183, DateTimeKind.Local).AddTicks(8625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 240, DateTimeKind.Local).AddTicks(9981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetQuaMauMoTaPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 182, DateTimeKind.Local).AddTicks(7008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 240, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetLuanDichVuPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 181, DateTimeKind.Local).AddTicks(1670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 239, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietDichVuDonViXetNghiemPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 179, DateTimeKind.Local).AddTicks(4681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 239, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietDanhGiaChatLuongMauPatientCares",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 177, DateTimeKind.Local).AddTicks(7803),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 238, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.CreateTable(
                name: "DanhMucKetLuanDichVu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKetLuanDichVu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKetLuanDichVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiMauPatientCare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiMau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucLoaiMauPatientCare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaXetNghiemSLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTraKetQua = table.Column<DateTime>(nullable: false),
                    IdNhanVienTraKetQua = table.Column<int>(nullable: false),
                    ChuanDoan = table.Column<string>(nullable: true),
                    isDuyet = table.Column<bool>(nullable: false),
                    NgayCoKetQua = table.Column<DateTime>(nullable: false),
                    NgayTiepNhan = table.Column<DateTime>(nullable: false),
                    NgayChiDinh = table.Column<DateTime>(nullable: false),
                    NgayLamXetNghiem = table.Column<DateTime>(nullable: false),
                    MaXetNghiem = table.Column<string>(nullable: true),
                    isTraKetQua = table.Column<bool>(nullable: false),
                    isNguyCoCao = table.Column<bool>(nullable: false),
                    isDongBoPDF = table.Column<bool>(nullable: false),
                    isXetNghiemLai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaXetNghiemSLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KetQuaXetNghiemSLSSs_DanhmucNguoidungs_IdNhanVienTraKetQua",
                        column: x => x.IdNhanVienTraKetQua,
                        principalTable: "DanhmucNguoidungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuSangLocSLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuSangLoc = table.Column<string>(maxLength: 50, nullable: false),
                    NgayTaoPhieu = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 168, DateTimeKind.Local).AddTicks(6067)),
                    IdNguoiDungTao = table.Column<int>(nullable: false),
                    NgayHuyPhieu = table.Column<DateTime>(nullable: false),
                    IdNguoiDungHuy = table.Column<int>(nullable: false),
                    Cancel = table.Column<bool>(nullable: false),
                    IdCheDoDinhDuong = table.Column<int>(nullable: false),
                    IdTinhTrang = table.Column<int>(nullable: false),
                    IdViTriLayMau = table.Column<int>(nullable: false),
                    IdKhachHang = table.Column<int>(nullable: false),
                    IdMapDonViCoSo_TrungTam = table.Column<int>(nullable: false),
                    MapDonvicosoTrungtamId = table.Column<int>(nullable: true),
                    TenBacSi = table.Column<string>(nullable: true),
                    TenBacSi_En = table.Column<string>(nullable: true),
                    KhoaPhong = table.Column<string>(nullable: true),
                    KhoaPhong_En = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    DiaChi_En = table.Column<string>(nullable: true),
                    NgayTruyenMau = table.Column<DateTime>(nullable: false),
                    SLTruyenMau = table.Column<int>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    Para = table.Column<string>(type: "varchar(4)", nullable: false),
                    IdNhanVienLayMau = table.Column<int>(nullable: false),
                    SDTNhanVienLayMau = table.Column<string>(nullable: true),
                    NoiLayMau = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    IdTrangThaiMau = table.Column<int>(nullable: false),
                    DanhmucNguoidungId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuSangLocSLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuSangLocSLSSs_DanhmucNguoidungs_DanhmucNguoidungId",
                        column: x => x.DanhmucNguoidungId,
                        principalTable: "DanhmucNguoidungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuSangLocSLSSs_DanhmucChedodinhduongs_IdCheDoDinhDuong",
                        column: x => x.IdCheDoDinhDuong,
                        principalTable: "DanhmucChedodinhduongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuSangLocSLSSs_DanhmucThongtinKhachhangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "DanhmucThongtinKhachhangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuSangLocSLSSs_DanhmucTinhtrangs_IdTinhTrang",
                        column: x => x.IdTinhTrang,
                        principalTable: "DanhmucTinhtrangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuSangLocSLSSs_DanhMucTrangThaiMau_IdTrangThaiMau",
                        column: x => x.IdTrangThaiMau,
                        principalTable: "DanhMucTrangThaiMau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuSangLocSLSSs_DanhmucVitrilaymaus_IdViTriLayMau",
                        column: x => x.IdViTriLayMau,
                        principalTable: "DanhmucVitrilaymaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuSangLocSLSSs_MapDonvicosoTrungtams_MapDonvicosoTrungtamId",
                        column: x => x.MapDonvicosoTrungtamId,
                        principalTable: "MapDonvicosoTrungtams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKetQuaXetNghiemSLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDichVu_SLSS = table.Column<int>(nullable: false),
                    IdKetQuaXN_SLSS = table.Column<int>(nullable: false),
                    isNguyCo = table.Column<bool>(nullable: false),
                    STT = table.Column<int>(nullable: false),
                    NgayCoKetQua = table.Column<DateTime>(nullable: false),
                    KetLuan_L1 = table.Column<string>(nullable: true),
                    KetLuan_L1En = table.Column<string>(nullable: true),
                    KetLuan_L2 = table.Column<string>(nullable: true),
                    KetLuan_L2En = table.Column<string>(nullable: true),
                    KetLuanTong = table.Column<string>(nullable: true),
                    KetLuanTongEn = table.Column<string>(nullable: true),
                    isDongBo = table.Column<bool>(nullable: false),
                    isTraKetQua = table.Column<bool>(nullable: false),
                    isXN_L2 = table.Column<bool>(nullable: false),
                    DeNghi = table.Column<string>(nullable: true),
                    DeNghiEn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKetQuaXetNghiemSLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietKetQuaXetNghiemSLSSs_DanhmucDichvuSLSSs_IdDichVu_SLSS",
                        column: x => x.IdDichVu_SLSS,
                        principalTable: "DanhmucDichvuSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKetQuaXetNghiemSLSSs_KetQuaXetNghiemSLSSs_IdKetQuaXN_SLSS",
                        column: x => x.IdKetQuaXN_SLSS,
                        principalTable: "KetQuaXetNghiemSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiepNhanSLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTiepNhan = table.Column<string>(nullable: false),
                    NgayTiepNhan = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 176, DateTimeKind.Local).AddTicks(428)),
                    IdNhanVienTiepNhan = table.Column<int>(nullable: false),
                    isDaNhapLieu = table.Column<bool>(nullable: false),
                    isDaDanhGia = table.Column<bool>(nullable: false),
                    IdPhieuSangLoc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiepNhanSLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiepNhanSLSSs_DanhmucNguoidungs_IdNhanVienTiepNhan",
                        column: x => x.IdNhanVienTiepNhan,
                        principalTable: "DanhmucNguoidungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiepNhanSLSSs_PhieuSangLocSLSSs_IdPhieuSangLoc",
                        column: x => x.IdPhieuSangLoc,
                        principalTable: "PhieuSangLocSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKetQuaThongSoXetNghiemSLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDichVu_SLSS = table.Column<int>(nullable: false),
                    DanhmucDichvuSLSSId = table.Column<int>(nullable: true),
                    IdKetQuaXN_SLSS = table.Column<int>(nullable: false),
                    KetQuaXetNghiemSLSSId = table.Column<int>(nullable: true),
                    isNguyCo = table.Column<bool>(nullable: false),
                    STT = table.Column<int>(nullable: false),
                    NgayCoKetQua = table.Column<DateTime>(nullable: false),
                    KetLuan_L1 = table.Column<string>(nullable: true),
                    KetLuan_L1En = table.Column<string>(nullable: true),
                    KetLuan_L2 = table.Column<string>(nullable: true),
                    KetLuan_L2En = table.Column<string>(nullable: true),
                    KetLuanTong = table.Column<string>(nullable: true),
                    KetLuanTongEn = table.Column<string>(nullable: true),
                    isDongBo = table.Column<bool>(nullable: false),
                    isTraKetQua = table.Column<bool>(nullable: false),
                    isXN_L2 = table.Column<bool>(nullable: false),
                    DeNghi = table.Column<string>(nullable: true),
                    DeNghiEn = table.Column<string>(nullable: true),
                    IdChiTietKQXN_SLSS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKetQuaThongSoXetNghiemSLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietKetQuaThongSoXetNghiemSLSSs_DanhmucDichvuSLSSs_DanhmucDichvuSLSSId",
                        column: x => x.DanhmucDichvuSLSSId,
                        principalTable: "DanhmucDichvuSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietKetQuaThongSoXetNghiemSLSSs_ChiTietKetQuaXetNghiemSLSSs_IdChiTietKQXN_SLSS",
                        column: x => x.IdChiTietKQXN_SLSS,
                        principalTable: "ChiTietKetQuaXetNghiemSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKetQuaThongSoXetNghiemSLSSs_KetQuaXetNghiemSLSSs_KetQuaXetNghiemSLSSId",
                        column: x => x.KetQuaXetNghiemSLSSId,
                        principalTable: "KetQuaXetNghiemSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaChatLuongMauSLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTiepNhan = table.Column<int>(nullable: false),
                    IdNhanVienDanhGia = table.Column<int>(nullable: false),
                    NgayDanhGia = table.Column<DateTime>(nullable: false),
                    isDat = table.Column<bool>(nullable: false),
                    LyDo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaChatLuongMauSLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhGiaChatLuongMauSLSSs_TiepNhanSLSSs_IdTiepNhan",
                        column: x => x.IdTiepNhan,
                        principalTable: "TiepNhanSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDanhGiaChatLuongMauSLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDanhGiaChatLuongMauNghiepVu = table.Column<int>(nullable: false),
                    IdDanhGiaChatLuongMau = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDanhGiaChatLuongMauSLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDanhGiaChatLuongMauSLSSs_DanhmucDanhgiaChatluongMaus_IdDanhGiaChatLuongMau",
                        column: x => x.IdDanhGiaChatLuongMau,
                        principalTable: "DanhmucDanhgiaChatluongMaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDanhGiaChatLuongMauSLSSs_DanhGiaChatLuongMauSLSSs_IdDanhGiaChatLuongMauNghiepVu",
                        column: x => x.IdDanhGiaChatLuongMauNghiepVu,
                        principalTable: "DanhGiaChatLuongMauSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanPatientCare_IdChiTietKetQua_SLSS",
                table: "TiepNhanPatientCare",
                column: "IdChiTietKetQua_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanPatientCare_IdKhachHang",
                table: "TiepNhanPatientCare",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanPatientCare_IdNhanVienTao",
                table: "TiepNhanPatientCare",
                column: "IdNhanVienTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhanMauPatientCares_IdNhanVienNhanMau",
                table: "NhanMauPatientCares",
                column: "IdNhanVienNhanMau");

            migrationBuilder.CreateIndex(
                name: "IX_NhanMauPatientCares_IdTiepNhanPatientCare",
                table: "NhanMauPatientCares",
                column: "IdTiepNhanPatientCare");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTongQuatPatientCares_IdKetLuanTheoGoi",
                table: "KetQuaTongQuatPatientCares",
                column: "IdKetLuanTheoGoi");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTongQuatPatientCares_IdNhanVienTraKetQua",
                table: "KetQuaTongQuatPatientCares",
                column: "IdNhanVienTraKetQua");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTongQuatPatientCares_IdTiepNhan",
                table: "KetQuaTongQuatPatientCares",
                column: "IdTiepNhan");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaPatientCares_IdDichVuXetNghiem",
                table: "KetQuaPatientCares",
                column: "IdDichVuXetNghiem");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaPatientCares_IdNhanVienTraKetQua",
                table: "KetQuaPatientCares",
                column: "IdNhanVienTraKetQua");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaChatLuongMauPatientCares_IdChiTietNhanMau",
                table: "DanhGiaChatLuongMauPatientCares",
                column: "IdChiTietNhanMau");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaChatLuongMauPatientCares_IdNhanVienDanhGia",
                table: "DanhGiaChatLuongMauPatientCares",
                column: "IdNhanVienDanhGia");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietTiepNhanPatientCares_IdDichVuXetNghiem",
                table: "ChiTietTiepNhanPatientCares",
                column: "IdDichVuXetNghiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietTiepNhanPatientCares_IdTiepNhan",
                table: "ChiTietTiepNhanPatientCares",
                column: "IdTiepNhan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhanMauPatientCares_IdChiTietTiepNhan",
                table: "ChiTietNhanMauPatientCares",
                column: "IdChiTietTiepNhan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhanMauPatientCares_IdLoaiMau",
                table: "ChiTietNhanMauPatientCares",
                column: "IdLoaiMau");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhanMauPatientCares_IdNhanMau",
                table: "ChiTietNhanMauPatientCares",
                column: "IdNhanMau");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietLoaiMauDichVuPatientCares_IdDichVuXetNghiem",
                table: "ChiTietLoaiMauDichVuPatientCares",
                column: "IdDichVuXetNghiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietLoaiMauDichVuPatientCares_IdLoaiMau",
                table: "ChiTietLoaiMauDichVuPatientCares",
                column: "IdLoaiMau");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaTongQuatPatientCares_IdKetQua",
                table: "ChiTietKetQuaTongQuatPatientCares",
                column: "IdKetQua");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaTongQuatPatientCares_IdKetQuaTongQuat",
                table: "ChiTietKetQuaTongQuatPatientCares",
                column: "IdKetQuaTongQuat");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaThongSoPatientCares_IdKetQua",
                table: "ChiTietKetQuaThongSoPatientCares",
                column: "IdKetQua");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaMauMoTaPatientCares_IdKetQua",
                table: "ChiTietKetQuaMauMoTaPatientCares",
                column: "IdKetQua");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetLuanDichVuPatientCares_IdDichVuXetNghiem",
                table: "ChiTietKetLuanDichVuPatientCares",
                column: "IdDichVuXetNghiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetLuanDichVuPatientCares_IdKetLuanDichVu",
                table: "ChiTietKetLuanDichVuPatientCares",
                column: "IdKetLuanDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVuDonViXetNghiemPatientCares_IdDichVuXetnghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares",
                column: "IdDichVuXetnghiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVuDonViXetNghiemPatientCares_IdDonViXetNghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares",
                column: "IdDonViXetNghiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDanhGiaChatLuongMauPatientCares_IdDanhGiaChatLuongMau",
                table: "ChiTietDanhGiaChatLuongMauPatientCares",
                column: "IdDanhGiaChatLuongMau");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDanhGiaChatLuongMauPatientCares_IdMauDanhGia",
                table: "ChiTietDanhGiaChatLuongMauPatientCares",
                column: "IdMauDanhGia");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDanhGiaChatLuongMauSLSSs_IdDanhGiaChatLuongMau",
                table: "ChiTietDanhGiaChatLuongMauSLSSs",
                column: "IdDanhGiaChatLuongMau");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDanhGiaChatLuongMauSLSSs_IdDanhGiaChatLuongMauNghiepVu",
                table: "ChiTietDanhGiaChatLuongMauSLSSs",
                column: "IdDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaThongSoXetNghiemSLSSs_DanhmucDichvuSLSSId",
                table: "ChiTietKetQuaThongSoXetNghiemSLSSs",
                column: "DanhmucDichvuSLSSId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaThongSoXetNghiemSLSSs_IdChiTietKQXN_SLSS",
                table: "ChiTietKetQuaThongSoXetNghiemSLSSs",
                column: "IdChiTietKQXN_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaThongSoXetNghiemSLSSs_KetQuaXetNghiemSLSSId",
                table: "ChiTietKetQuaThongSoXetNghiemSLSSs",
                column: "KetQuaXetNghiemSLSSId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaXetNghiemSLSSs_IdDichVu_SLSS",
                table: "ChiTietKetQuaXetNghiemSLSSs",
                column: "IdDichVu_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQuaXetNghiemSLSSs_IdKetQuaXN_SLSS",
                table: "ChiTietKetQuaXetNghiemSLSSs",
                column: "IdKetQuaXN_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaChatLuongMauSLSSs_IdTiepNhan",
                table: "DanhGiaChatLuongMauSLSSs",
                column: "IdTiepNhan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaXetNghiemSLSSs_IdNhanVienTraKetQua",
                table: "KetQuaXetNghiemSLSSs",
                column: "IdNhanVienTraKetQua");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuSangLocSLSSs_DanhmucNguoidungId",
                table: "PhieuSangLocSLSSs",
                column: "DanhmucNguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuSangLocSLSSs_IdCheDoDinhDuong",
                table: "PhieuSangLocSLSSs",
                column: "IdCheDoDinhDuong");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuSangLocSLSSs_IdKhachHang",
                table: "PhieuSangLocSLSSs",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuSangLocSLSSs_IdTinhTrang",
                table: "PhieuSangLocSLSSs",
                column: "IdTinhTrang");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuSangLocSLSSs_IdTrangThaiMau",
                table: "PhieuSangLocSLSSs",
                column: "IdTrangThaiMau");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuSangLocSLSSs_IdViTriLayMau",
                table: "PhieuSangLocSLSSs",
                column: "IdViTriLayMau");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuSangLocSLSSs_MapDonvicosoTrungtamId",
                table: "PhieuSangLocSLSSs",
                column: "MapDonvicosoTrungtamId");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanSLSSs_IdNhanVienTiepNhan",
                table: "TiepNhanSLSSs",
                column: "IdNhanVienTiepNhan");

            migrationBuilder.CreateIndex(
                name: "IX_TiepNhanSLSSs_IdPhieuSangLoc",
                table: "TiepNhanSLSSs",
                column: "IdPhieuSangLoc",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDanhGiaChatLuongMauPatientCares_DanhGiaChatLuongMauPatientCares_IdDanhGiaChatLuongMau",
                table: "ChiTietDanhGiaChatLuongMauPatientCares",
                column: "IdDanhGiaChatLuongMau",
                principalTable: "DanhGiaChatLuongMauPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDanhGiaChatLuongMauPatientCares_DanhmucDanhgiaChatluongMaus_IdMauDanhGia",
                table: "ChiTietDanhGiaChatLuongMauPatientCares",
                column: "IdMauDanhGia",
                principalTable: "DanhmucDanhgiaChatluongMaus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDichVuDonViXetNghiemPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetnghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares",
                column: "IdDichVuXetnghiem",
                principalTable: "DanhmucDichvuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDichVuDonViXetNghiemPatientCares_DanhMucDonViXNs_IdDonViXetNghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares",
                column: "IdDonViXetNghiem",
                principalTable: "DanhMucDonViXNs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKetLuanDichVuPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "ChiTietKetLuanDichVuPatientCares",
                column: "IdDichVuXetNghiem",
                principalTable: "DanhmucDichvuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKetLuanDichVuPatientCares_DanhMucKetLuanDichVu_IdKetLuanDichVu",
                table: "ChiTietKetLuanDichVuPatientCares",
                column: "IdKetLuanDichVu",
                principalTable: "DanhMucKetLuanDichVu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKetQuaMauMoTaPatientCares_KetQuaPatientCares_IdKetQua",
                table: "ChiTietKetQuaMauMoTaPatientCares",
                column: "IdKetQua",
                principalTable: "KetQuaPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKetQuaThongSoPatientCares_KetQuaPatientCares_IdKetQua",
                table: "ChiTietKetQuaThongSoPatientCares",
                column: "IdKetQua",
                principalTable: "KetQuaPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKetQuaTongQuatPatientCares_KetQuaPatientCares_IdKetQua",
                table: "ChiTietKetQuaTongQuatPatientCares",
                column: "IdKetQua",
                principalTable: "KetQuaPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKetQuaTongQuatPatientCares_KetQuaTongQuatPatientCares_IdKetQuaTongQuat",
                table: "ChiTietKetQuaTongQuatPatientCares",
                column: "IdKetQuaTongQuat",
                principalTable: "KetQuaTongQuatPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietLoaiMauDichVuPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "ChiTietLoaiMauDichVuPatientCares",
                column: "IdDichVuXetNghiem",
                principalTable: "DanhmucDichvuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietLoaiMauDichVuPatientCares_DanhMucLoaiMauPatientCare_IdLoaiMau",
                table: "ChiTietLoaiMauDichVuPatientCares",
                column: "IdLoaiMau",
                principalTable: "DanhMucLoaiMauPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietNhanMauPatientCares_ChiTietTiepNhanPatientCares_IdChiTietTiepNhan",
                table: "ChiTietNhanMauPatientCares",
                column: "IdChiTietTiepNhan",
                principalTable: "ChiTietTiepNhanPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietNhanMauPatientCares_DanhMucLoaiMauPatientCare_IdLoaiMau",
                table: "ChiTietNhanMauPatientCares",
                column: "IdLoaiMau",
                principalTable: "DanhMucLoaiMauPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietNhanMauPatientCares_NhanMauPatientCares_IdNhanMau",
                table: "ChiTietNhanMauPatientCares",
                column: "IdNhanMau",
                principalTable: "NhanMauPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietTiepNhanPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "ChiTietTiepNhanPatientCares",
                column: "IdDichVuXetNghiem",
                principalTable: "DanhmucDichvuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietTiepNhanPatientCares_TiepNhanPatientCare_IdTiepNhan",
                table: "ChiTietTiepNhanPatientCares",
                column: "IdTiepNhan",
                principalTable: "TiepNhanPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGiaChatLuongMauPatientCares_ChiTietNhanMauPatientCares_IdChiTietNhanMau",
                table: "DanhGiaChatLuongMauPatientCares",
                column: "IdChiTietNhanMau",
                principalTable: "ChiTietNhanMauPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGiaChatLuongMauPatientCares_DanhmucNguoidungs_IdNhanVienDanhGia",
                table: "DanhGiaChatLuongMauPatientCares",
                column: "IdNhanVienDanhGia",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "KetQuaPatientCares",
                column: "IdDichVuXetNghiem",
                principalTable: "DanhmucDichvuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaPatientCares_DanhmucNguoidungs_IdNhanVienTraKetQua",
                table: "KetQuaPatientCares",
                column: "IdNhanVienTraKetQua",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTongQuatPatientCares_KetLuanTheoGoiPatientCares_IdKetLuanTheoGoi",
                table: "KetQuaTongQuatPatientCares",
                column: "IdKetLuanTheoGoi",
                principalTable: "KetLuanTheoGoiPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTongQuatPatientCares_DanhmucNguoidungs_IdNhanVienTraKetQua",
                table: "KetQuaTongQuatPatientCares",
                column: "IdNhanVienTraKetQua",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTongQuatPatientCares_TiepNhanPatientCare_IdTiepNhan",
                table: "KetQuaTongQuatPatientCares",
                column: "IdTiepNhan",
                principalTable: "TiepNhanPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanMauPatientCares_DanhmucNguoidungs_IdNhanVienNhanMau",
                table: "NhanMauPatientCares",
                column: "IdNhanVienNhanMau",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanMauPatientCares_TiepNhanPatientCare_IdTiepNhanPatientCare",
                table: "NhanMauPatientCares",
                column: "IdTiepNhanPatientCare",
                principalTable: "TiepNhanPatientCare",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanPatientCare_ChiTietKetQuaXetNghiemSLSSs_IdChiTietKetQua_SLSS",
                table: "TiepNhanPatientCare",
                column: "IdChiTietKetQua_SLSS",
                principalTable: "ChiTietKetQuaXetNghiemSLSSs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanPatientCare_DanhmucThongtinKhachhangs_IdKhachHang",
                table: "TiepNhanPatientCare",
                column: "IdKhachHang",
                principalTable: "DanhmucThongtinKhachhangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiepNhanPatientCare_DanhmucNguoidungs_IdNhanVienTao",
                table: "TiepNhanPatientCare",
                column: "IdNhanVienTao",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDanhGiaChatLuongMauPatientCares_DanhGiaChatLuongMauPatientCares_IdDanhGiaChatLuongMau",
                table: "ChiTietDanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDanhGiaChatLuongMauPatientCares_DanhmucDanhgiaChatluongMaus_IdMauDanhGia",
                table: "ChiTietDanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDichVuDonViXetNghiemPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetnghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDichVuDonViXetNghiemPatientCares_DanhMucDonViXNs_IdDonViXetNghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKetLuanDichVuPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "ChiTietKetLuanDichVuPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKetLuanDichVuPatientCares_DanhMucKetLuanDichVu_IdKetLuanDichVu",
                table: "ChiTietKetLuanDichVuPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKetQuaMauMoTaPatientCares_KetQuaPatientCares_IdKetQua",
                table: "ChiTietKetQuaMauMoTaPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKetQuaThongSoPatientCares_KetQuaPatientCares_IdKetQua",
                table: "ChiTietKetQuaThongSoPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKetQuaTongQuatPatientCares_KetQuaPatientCares_IdKetQua",
                table: "ChiTietKetQuaTongQuatPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKetQuaTongQuatPatientCares_KetQuaTongQuatPatientCares_IdKetQuaTongQuat",
                table: "ChiTietKetQuaTongQuatPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietLoaiMauDichVuPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "ChiTietLoaiMauDichVuPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietLoaiMauDichVuPatientCares_DanhMucLoaiMauPatientCare_IdLoaiMau",
                table: "ChiTietLoaiMauDichVuPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietNhanMauPatientCares_ChiTietTiepNhanPatientCares_IdChiTietTiepNhan",
                table: "ChiTietNhanMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietNhanMauPatientCares_DanhMucLoaiMauPatientCare_IdLoaiMau",
                table: "ChiTietNhanMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietNhanMauPatientCares_NhanMauPatientCares_IdNhanMau",
                table: "ChiTietNhanMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietTiepNhanPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "ChiTietTiepNhanPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietTiepNhanPatientCares_TiepNhanPatientCare_IdTiepNhan",
                table: "ChiTietTiepNhanPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaChatLuongMauPatientCares_ChiTietNhanMauPatientCares_IdChiTietNhanMau",
                table: "DanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaChatLuongMauPatientCares_DanhmucNguoidungs_IdNhanVienDanhGia",
                table: "DanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiem",
                table: "KetQuaPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaPatientCares_DanhmucNguoidungs_IdNhanVienTraKetQua",
                table: "KetQuaPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTongQuatPatientCares_KetLuanTheoGoiPatientCares_IdKetLuanTheoGoi",
                table: "KetQuaTongQuatPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTongQuatPatientCares_DanhmucNguoidungs_IdNhanVienTraKetQua",
                table: "KetQuaTongQuatPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTongQuatPatientCares_TiepNhanPatientCare_IdTiepNhan",
                table: "KetQuaTongQuatPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanMauPatientCares_DanhmucNguoidungs_IdNhanVienNhanMau",
                table: "NhanMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanMauPatientCares_TiepNhanPatientCare_IdTiepNhanPatientCare",
                table: "NhanMauPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanPatientCare_ChiTietKetQuaXetNghiemSLSSs_IdChiTietKetQua_SLSS",
                table: "TiepNhanPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanPatientCare_DanhmucThongtinKhachhangs_IdKhachHang",
                table: "TiepNhanPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_TiepNhanPatientCare_DanhmucNguoidungs_IdNhanVienTao",
                table: "TiepNhanPatientCare");

            migrationBuilder.DropTable(
                name: "ChiTietDanhGiaChatLuongMauSLSSs");

            migrationBuilder.DropTable(
                name: "ChiTietKetQuaThongSoXetNghiemSLSSs");

            migrationBuilder.DropTable(
                name: "DanhMucKetLuanDichVu");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiMauPatientCare");

            migrationBuilder.DropTable(
                name: "DanhGiaChatLuongMauSLSSs");

            migrationBuilder.DropTable(
                name: "ChiTietKetQuaXetNghiemSLSSs");

            migrationBuilder.DropTable(
                name: "TiepNhanSLSSs");

            migrationBuilder.DropTable(
                name: "KetQuaXetNghiemSLSSs");

            migrationBuilder.DropTable(
                name: "PhieuSangLocSLSSs");

            migrationBuilder.DropIndex(
                name: "IX_TiepNhanPatientCare_IdChiTietKetQua_SLSS",
                table: "TiepNhanPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_TiepNhanPatientCare_IdKhachHang",
                table: "TiepNhanPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_TiepNhanPatientCare_IdNhanVienTao",
                table: "TiepNhanPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_NhanMauPatientCares_IdNhanVienNhanMau",
                table: "NhanMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_NhanMauPatientCares_IdTiepNhanPatientCare",
                table: "NhanMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaTongQuatPatientCares_IdKetLuanTheoGoi",
                table: "KetQuaTongQuatPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaTongQuatPatientCares_IdNhanVienTraKetQua",
                table: "KetQuaTongQuatPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaTongQuatPatientCares_IdTiepNhan",
                table: "KetQuaTongQuatPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaPatientCares_IdDichVuXetNghiem",
                table: "KetQuaPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaPatientCares_IdNhanVienTraKetQua",
                table: "KetQuaPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhGiaChatLuongMauPatientCares_IdChiTietNhanMau",
                table: "DanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhGiaChatLuongMauPatientCares_IdNhanVienDanhGia",
                table: "DanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietTiepNhanPatientCares_IdDichVuXetNghiem",
                table: "ChiTietTiepNhanPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietTiepNhanPatientCares_IdTiepNhan",
                table: "ChiTietTiepNhanPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietNhanMauPatientCares_IdChiTietTiepNhan",
                table: "ChiTietNhanMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietNhanMauPatientCares_IdLoaiMau",
                table: "ChiTietNhanMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietNhanMauPatientCares_IdNhanMau",
                table: "ChiTietNhanMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietLoaiMauDichVuPatientCares_IdDichVuXetNghiem",
                table: "ChiTietLoaiMauDichVuPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietLoaiMauDichVuPatientCares_IdLoaiMau",
                table: "ChiTietLoaiMauDichVuPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKetQuaTongQuatPatientCares_IdKetQua",
                table: "ChiTietKetQuaTongQuatPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKetQuaTongQuatPatientCares_IdKetQuaTongQuat",
                table: "ChiTietKetQuaTongQuatPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKetQuaThongSoPatientCares_IdKetQua",
                table: "ChiTietKetQuaThongSoPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKetQuaMauMoTaPatientCares_IdKetQua",
                table: "ChiTietKetQuaMauMoTaPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKetLuanDichVuPatientCares_IdDichVuXetNghiem",
                table: "ChiTietKetLuanDichVuPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietKetLuanDichVuPatientCares_IdKetLuanDichVu",
                table: "ChiTietKetLuanDichVuPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDichVuDonViXetNghiemPatientCares_IdDichVuXetnghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDichVuDonViXetNghiemPatientCares_IdDonViXetNghiem",
                table: "ChiTietDichVuDonViXetNghiemPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDanhGiaChatLuongMauPatientCares_IdDanhGiaChatLuongMau",
                table: "ChiTietDanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDanhGiaChatLuongMauPatientCares_IdMauDanhGia",
                table: "ChiTietDanhGiaChatLuongMauPatientCares");

            migrationBuilder.DropColumn(
                name: "IdTiepNhanPatientCare",
                table: "NhanMauPatientCares");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "TiepNhanPatientCare",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 247, DateTimeKind.Local).AddTicks(6065),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 200, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayNhanMau",
                table: "NhanMauPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 246, DateTimeKind.Local).AddTicks(9486),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 198, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.AddColumn<int>(
                name: "IdTiepNhan",
                table: "NhanMauPatientCares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTraKetQua",
                table: "KetQuaTongQuatPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 246, DateTimeKind.Local).AddTicks(2819),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 196, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTraKetQua",
                table: "KetQuaPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 245, DateTimeKind.Local).AddTicks(5887),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 194, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDanhGia",
                table: "DanhGiaChatLuongMauPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 244, DateTimeKind.Local).AddTicks(2830),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 192, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayChiDinh",
                table: "ChiTietTiepNhanPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 243, DateTimeKind.Local).AddTicks(6224),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 190, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietNhanMauPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 242, DateTimeKind.Local).AddTicks(9661),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 188, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietLoaiMauDichVuPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 242, DateTimeKind.Local).AddTicks(3131),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 186, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetQuaTongQuatPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 241, DateTimeKind.Local).AddTicks(6579),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 185, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetQuaThongSoPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 240, DateTimeKind.Local).AddTicks(9981),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 183, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetQuaMauMoTaPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 240, DateTimeKind.Local).AddTicks(3367),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 182, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietKetLuanDichVuPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 239, DateTimeKind.Local).AddTicks(6823),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 181, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietDichVuDonViXetNghiemPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 239, DateTimeKind.Local).AddTicks(287),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 179, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietDanhGiaChatLuongMauPatientCares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 238, DateTimeKind.Local).AddTicks(3433),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 23, 9, 13, 49, 177, DateTimeKind.Local).AddTicks(7803));

            migrationBuilder.CreateTable(
                name: "DanhMucKetQuaXN_SLSS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuanDoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhmucNguoidungId = table.Column<int>(type: "int", nullable: true),
                    IdNhanVienTraKetQua = table.Column<int>(type: "int", nullable: false),
                    MaXetNghiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayChiDinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCoKetQua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayLamXetNghiem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTiepNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTraKetQua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDongBoPDF = table.Column<bool>(type: "bit", nullable: false),
                    isDuyet = table.Column<bool>(type: "bit", nullable: false),
                    isNguyCoCao = table.Column<bool>(type: "bit", nullable: false),
                    isTraKetQua = table.Column<bool>(type: "bit", nullable: false),
                    isXetNghiemLai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKetQuaXN_SLSS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucKetQuaXN_SLSS_DanhmucNguoidungs_DanhmucNguoidungId",
                        column: x => x.DanhmucNguoidungId,
                        principalTable: "DanhmucNguoidungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiTiepNhans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiTiepNhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucLoaiTiepNhans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucPhieuSangLocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cancel = table.Column<bool>(type: "bit", nullable: false),
                    DanhmucNguoidungId = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCheDoDinhDuong = table.Column<int>(type: "int", nullable: false),
                    IdKhachHang = table.Column<int>(type: "int", nullable: false),
                    IdMapDonViCoSo_TrungTam = table.Column<int>(type: "int", nullable: false),
                    IdNguoiDungHuy = table.Column<int>(type: "int", nullable: false),
                    IdNguoiDungTao = table.Column<int>(type: "int", nullable: false),
                    IdNhanVienLayMau = table.Column<int>(type: "int", nullable: false),
                    IdTinhTrang = table.Column<int>(type: "int", nullable: false),
                    IdTrangThaiMau = table.Column<int>(type: "int", nullable: false),
                    IdViTriLayMau = table.Column<int>(type: "int", nullable: false),
                    KhoaPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoaPhong_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaPhieuSangLoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MapDonvicosoTrungtamId = table.Column<int>(type: "int", nullable: true),
                    NgayHuyPhieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTaoPhieu = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 223, DateTimeKind.Local).AddTicks(85)),
                    NgayTruyenMau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiLayMau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Para = table.Column<string>(type: "varchar(4)", nullable: false),
                    SDTNhanVienLayMau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLTruyenMau = table.Column<int>(type: "int", nullable: false),
                    TenBacSi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenBacSi_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucPhieuSangLocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucPhieuSangLocs_DanhmucNguoidungs_DanhmucNguoidungId",
                        column: x => x.DanhmucNguoidungId,
                        principalTable: "DanhmucNguoidungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhMucPhieuSangLocs_DanhmucChedodinhduongs_IdCheDoDinhDuong",
                        column: x => x.IdCheDoDinhDuong,
                        principalTable: "DanhmucChedodinhduongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucPhieuSangLocs_DanhmucThongtinKhachhangs_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "DanhmucThongtinKhachhangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucPhieuSangLocs_DanhmucTinhtrangs_IdTinhTrang",
                        column: x => x.IdTinhTrang,
                        principalTable: "DanhmucTinhtrangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucPhieuSangLocs_DanhMucTrangThaiMau_IdTrangThaiMau",
                        column: x => x.IdTrangThaiMau,
                        principalTable: "DanhMucTrangThaiMau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucPhieuSangLocs_DanhmucVitrilaymaus_IdViTriLayMau",
                        column: x => x.IdViTriLayMau,
                        principalTable: "DanhmucVitrilaymaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucPhieuSangLocs_MapDonvicosoTrungtams_MapDonvicosoTrungtamId",
                        column: x => x.MapDonvicosoTrungtamId,
                        principalTable: "MapDonvicosoTrungtams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChiTietKetQuaXN_SLSSs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeNghi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeNghiEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDichVu_SLSS = table.Column<int>(type: "int", nullable: false),
                    IdKetQuaXN_SLSS = table.Column<int>(type: "int", nullable: false),
                    KetLuanTong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetLuanTongEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetLuan_L1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetLuan_L1En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetLuan_L2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetLuan_L2En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCoKetQua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STT = table.Column<int>(type: "int", nullable: false),
                    isDongBo = table.Column<bool>(type: "bit", nullable: false),
                    isNguyCo = table.Column<bool>(type: "bit", nullable: false),
                    isTraKetQua = table.Column<bool>(type: "bit", nullable: false),
                    isXN_L2 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChiTietKetQuaXN_SLSSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucChiTietKetQuaXN_SLSSs_DanhmucDichvuSLSSs_IdDichVu_SLSS",
                        column: x => x.IdDichVu_SLSS,
                        principalTable: "DanhmucDichvuSLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucChiTietKetQuaXN_SLSSs_DanhMucKetQuaXN_SLSS_IdKetQuaXN_SLSS",
                        column: x => x.IdKetQuaXN_SLSS,
                        principalTable: "DanhMucKetQuaXN_SLSS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucTiepNhans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLoaiTiepNhan = table.Column<int>(type: "int", nullable: false),
                    IdNhanVienTiepNhan = table.Column<int>(type: "int", nullable: false),
                    IdPhieuSangLoc = table.Column<int>(type: "int", nullable: false),
                    MaTiepNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTiepNhan = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2020, 3, 21, 11, 21, 15, 230, DateTimeKind.Local).AddTicks(7414)),
                    isDaDanhGia = table.Column<bool>(type: "bit", nullable: false),
                    isDaNhapLieu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucTiepNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucTiepNhans_DanhMucLoaiTiepNhans_IdLoaiTiepNhan",
                        column: x => x.IdLoaiTiepNhan,
                        principalTable: "DanhMucLoaiTiepNhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucTiepNhans_DanhmucNguoidungs_IdNhanVienTiepNhan",
                        column: x => x.IdNhanVienTiepNhan,
                        principalTable: "DanhmucNguoidungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucTiepNhans_DanhMucPhieuSangLocs_IdPhieuSangLoc",
                        column: x => x.IdPhieuSangLoc,
                        principalTable: "DanhMucPhieuSangLocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChiTietKetQuaThongSoXNs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaTriCuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTriMax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTriMin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTriTrungBinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTri_L1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaTri_L2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChiTietKQXN_SLSS = table.Column<int>(type: "int", nullable: false),
                    KetLuanThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetLuanThongSoEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STT = table.Column<int>(type: "int", nullable: false),
                    isGiaTri = table.Column<bool>(type: "bit", nullable: false),
                    isNguyCo = table.Column<bool>(type: "bit", nullable: false),
                    isXoa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChiTietKetQuaThongSoXNs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucChiTietKetQuaThongSoXNs_DanhMucChiTietKetQuaXN_SLSSs_IdChiTietKQXN_SLSS",
                        column: x => x.IdChiTietKQXN_SLSS,
                        principalTable: "DanhMucChiTietKetQuaXN_SLSSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucDanhGiaChatLuongMauNghiepVus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNhanVienDanhGia = table.Column<int>(type: "int", nullable: false),
                    IdTiepNhan = table.Column<int>(type: "int", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDanhGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucDanhGiaChatLuongMauNghiepVus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucDanhGiaChatLuongMauNghiepVus_DanhMucTiepNhans_IdTiepNhan",
                        column: x => x.IdTiepNhan,
                        principalTable: "DanhMucTiepNhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucChiTietDanhGiaChatLuongMaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDanhGiaChatLuongMau = table.Column<int>(type: "int", nullable: false),
                    IdDanhGiaChatLuongMauNghiepVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucChiTietDanhGiaChatLuongMaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucChiTietDanhGiaChatLuongMaus_DanhmucDanhgiaChatluongMaus_IdDanhGiaChatLuongMau",
                        column: x => x.IdDanhGiaChatLuongMau,
                        principalTable: "DanhmucDanhgiaChatluongMaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhMucChiTietDanhGiaChatLuongMaus_DanhMucDanhGiaChatLuongMauNghiepVus_IdDanhGiaChatLuongMauNghiepVu",
                        column: x => x.IdDanhGiaChatLuongMauNghiepVu,
                        principalTable: "DanhMucDanhGiaChatLuongMauNghiepVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMaus_IdDanhGiaChatLuongMau",
                table: "DanhMucChiTietDanhGiaChatLuongMaus",
                column: "IdDanhGiaChatLuongMau");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMaus_IdDanhGiaChatLuongMauNghiepVu",
                table: "DanhMucChiTietDanhGiaChatLuongMaus",
                column: "IdDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaThongSoXNs_IdChiTietKQXN_SLSS",
                table: "DanhMucChiTietKetQuaThongSoXNs",
                column: "IdChiTietKQXN_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSSs_IdDichVu_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs",
                column: "IdDichVu_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSSs_IdKetQuaXN_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs",
                column: "IdKetQuaXN_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanhGiaChatLuongMauNghiepVus_IdTiepNhan",
                table: "DanhMucDanhGiaChatLuongMauNghiepVus",
                column: "IdTiepNhan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucKetQuaXN_SLSS_DanhmucNguoidungId",
                table: "DanhMucKetQuaXN_SLSS",
                column: "DanhmucNguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLocs_DanhmucNguoidungId",
                table: "DanhMucPhieuSangLocs",
                column: "DanhmucNguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLocs_IdCheDoDinhDuong",
                table: "DanhMucPhieuSangLocs",
                column: "IdCheDoDinhDuong");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLocs_IdKhachHang",
                table: "DanhMucPhieuSangLocs",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLocs_IdTinhTrang",
                table: "DanhMucPhieuSangLocs",
                column: "IdTinhTrang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLocs_IdTrangThaiMau",
                table: "DanhMucPhieuSangLocs",
                column: "IdTrangThaiMau");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLocs_IdViTriLayMau",
                table: "DanhMucPhieuSangLocs",
                column: "IdViTriLayMau");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLocs_MapDonvicosoTrungtamId",
                table: "DanhMucPhieuSangLocs",
                column: "MapDonvicosoTrungtamId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTiepNhans_IdLoaiTiepNhan",
                table: "DanhMucTiepNhans",
                column: "IdLoaiTiepNhan");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTiepNhans_IdNhanVienTiepNhan",
                table: "DanhMucTiepNhans",
                column: "IdNhanVienTiepNhan");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTiepNhans_IdPhieuSangLoc",
                table: "DanhMucTiepNhans",
                column: "IdPhieuSangLoc",
                unique: true);
        }
    }
}
