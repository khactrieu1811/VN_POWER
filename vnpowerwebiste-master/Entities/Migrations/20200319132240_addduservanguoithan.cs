using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioNet.Entities.Migrations
{
    public partial class addduservanguoithan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMau_DanhMucDanhGiaChatLuongMauNghiepVu_DanhMucDanhGiaChatLuongMauNghiepVuId",
                table: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMau_DanhmucDanhgiaChatluongMaus_DanhmucDanhgiaChatluongMauId",
                table: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietKetQuaThongSoXN_DanhMucChiTietKetQuaXN_SLSS_DanhMucChiTietKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaThongSoXN");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSS_DanhMucKetQuaXN_SLSS_DanhMucKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSS_DanhmucDichvuSLSSs_DanhmucDichvuSLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidung_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidung_DanhmucQuyen_DanhmucQuyenId",
                table: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDanhGiaChatLuongMauNghiepVu_DanhMucTiepNhan_DanhMucTiepNhanId",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKetQuaXN_SLSS_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhMucKetQuaXN_SLSS");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucLoaiNguoidung_DanhmucNhomNguoidung_DanhmucNhomNguoidungId",
                table: "DanhmucLoaiNguoidung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucNguoidung_DanhmucLoaiNguoidung_DanhmucLoaiNguoidungId",
                table: "DanhmucNguoidung");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhMucTrangThaiMau_DanhMucTrangThaiMauId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucChedodinhduongs_DanhmucChedodinhduongId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucThongtinKhachhangs_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucTinhtrangs_DanhmucTinhtrangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucVitrilaymaus_DanhmucVitrilaymauId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_MapDonvicosoTrungtams_MapDonvicosoTrungtamId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucQuyen_DanhmucNhomQuyen_DanhmucNhomQuyenId",
                table: "DanhmucQuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTiepNhan_DanhMucLoaiTiepNhan_DanhMucLoaiTiepNhanId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTiepNhan_DanhMucPhieuSangLoc_DanhMucPhieuSangLocId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTiepNhan_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucTiepNhan",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTiepNhan_DanhMucLoaiTiepNhanId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTiepNhan_DanhMucPhieuSangLocId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTiepNhan_DanhmucNguoidungId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucQuyen",
                table: "DanhmucQuyen");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucQuyen_DanhmucNhomQuyenId",
                table: "DanhmucQuyen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucPhieuSangLoc",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhMucTrangThaiMauId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucChedodinhduongId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucTinhtrangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucVitrilaymauId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNhomQuyen",
                table: "DanhmucNhomQuyen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNhomNguoidung",
                table: "DanhmucNhomNguoidung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNguoidung",
                table: "DanhmucNguoidung");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucNguoidung_DanhmucLoaiNguoidungId",
                table: "DanhmucNguoidung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucLoaiTiepNhan",
                table: "DanhMucLoaiTiepNhan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucLoaiNguoidung",
                table: "DanhmucLoaiNguoidung");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucLoaiNguoidung_DanhmucNhomNguoidungId",
                table: "DanhmucLoaiNguoidung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucDanhGiaChatLuongMauNghiepVu",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDanhGiaChatLuongMauNghiepVu_DanhMucTiepNhanId",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucChitietQuyenNguoidung",
                table: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietQuyenNguoidung_DanhmucNguoidungId",
                table: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietQuyenNguoidung_DanhmucQuyenId",
                table: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaXN_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSS_DanhMucKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSS_DanhmucDichvuSLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaThongSoXN",
                table: "DanhMucChiTietKetQuaThongSoXN");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietKetQuaThongSoXN_DanhMucChiTietKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaThongSoXN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChiTietDanhGiaChatLuongMau",
                table: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMau_DanhMucDanhGiaChatLuongMauNghiepVuId",
                table: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMau_DanhmucDanhgiaChatluongMauId",
                table: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.DropColumn(
                name: "DanhMucLoaiTiepNhanId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropColumn(
                name: "DanhMucPhieuSangLocId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropColumn(
                name: "DanhmucNguoidungId",
                table: "DanhMucTiepNhan");

            migrationBuilder.DropColumn(
                name: "DanhmucNhomQuyenId",
                table: "DanhmucQuyen");

            migrationBuilder.DropColumn(
                name: "DanhMucTrangThaiMauId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropColumn(
                name: "DanhmucChedodinhduongId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropColumn(
                name: "DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropColumn(
                name: "DanhmucTinhtrangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropColumn(
                name: "DanhmucVitrilaymauId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropColumn(
                name: "DanhmucLoaiNguoidungId",
                table: "DanhmucNguoidung");

            migrationBuilder.DropColumn(
                name: "DanhmucNhomNguoidungId",
                table: "DanhmucLoaiNguoidung");

            migrationBuilder.DropColumn(
                name: "DanhMucTiepNhanId",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.DropColumn(
                name: "DanhmucNguoidungId",
                table: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.DropColumn(
                name: "DanhmucQuyenId",
                table: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.DropColumn(
                name: "DanhMucKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.DropColumn(
                name: "DanhmucDichvuSLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.DropColumn(
                name: "DanhMucChiTietKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaThongSoXN");

            migrationBuilder.DropColumn(
                name: "DanhMucDanhGiaChatLuongMauNghiepVuId",
                table: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.DropColumn(
                name: "DanhmucDanhgiaChatluongMauId",
                table: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.RenameTable(
                name: "DanhMucTiepNhan",
                newName: "DanhMucTiepNhans");

            migrationBuilder.RenameTable(
                name: "DanhmucQuyen",
                newName: "DanhmucQuyens");

            migrationBuilder.RenameTable(
                name: "DanhMucPhieuSangLoc",
                newName: "DanhMucPhieuSangLocs");

            migrationBuilder.RenameTable(
                name: "DanhmucNhomQuyen",
                newName: "DanhmucNhomQuyens");

            migrationBuilder.RenameTable(
                name: "DanhmucNhomNguoidung",
                newName: "DanhmucNhomNguoidungs");

            migrationBuilder.RenameTable(
                name: "DanhmucNguoidung",
                newName: "DanhmucNguoidungs");

            migrationBuilder.RenameTable(
                name: "DanhMucLoaiTiepNhan",
                newName: "DanhMucLoaiTiepNhans");

            migrationBuilder.RenameTable(
                name: "DanhmucLoaiNguoidung",
                newName: "DanhmucLoaiNguoidungs");

            migrationBuilder.RenameTable(
                name: "DanhMucDanhGiaChatLuongMauNghiepVu",
                newName: "DanhMucDanhGiaChatLuongMauNghiepVus");

            migrationBuilder.RenameTable(
                name: "DanhmucChitietQuyenNguoidung",
                newName: "DanhmucChitietQuyenNguoidungs");

            migrationBuilder.RenameTable(
                name: "DanhMucChiTietKetQuaXN_SLSS",
                newName: "DanhMucChiTietKetQuaXN_SLSSs");

            migrationBuilder.RenameTable(
                name: "DanhMucChiTietKetQuaThongSoXN",
                newName: "DanhMucChiTietKetQuaThongSoXNs");

            migrationBuilder.RenameTable(
                name: "DanhMucChiTietDanhGiaChatLuongMau",
                newName: "DanhMucChiTietDanhGiaChatLuongMaus");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucPhieuSangLoc_MapDonvicosoTrungtamId",
                table: "DanhMucPhieuSangLocs",
                newName: "IX_DanhMucPhieuSangLocs_MapDonvicosoTrungtamId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucNguoidungId",
                table: "DanhMucPhieuSangLocs",
                newName: "IX_DanhMucPhieuSangLocs_DanhmucNguoidungId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTiepNhan",
                table: "DanhMucTiepNhans",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 19, 20, 22, 40, 23, DateTimeKind.Local).AddTicks(3610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "MaTiepNhan",
                table: "DanhMucTiepNhans",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenQuyen",
                table: "DanhmucQuyens",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Para",
                table: "DanhMucPhieuSangLocs",
                type: "varchar(4)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTaoPhieu",
                table: "DanhMucPhieuSangLocs",
                nullable: false,
                defaultValue: new DateTime(2020, 3, 19, 20, 22, 40, 13, DateTimeKind.Local).AddTicks(8954),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "MaPhieuSangLoc",
                table: "DanhMucPhieuSangLocs",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNhomQuyen",
                table: "DanhmucNhomQuyens",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNhomUser",
                table: "DanhmucNhomNguoidungs",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "DanhmucNguoidungs",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "DanhmucNguoidungs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenCode",
                table: "DanhmucNguoidungs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "DanhmucNguoidungs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiTiepNhan",
                table: "DanhMucLoaiTiepNhans",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiUser",
                table: "DanhmucLoaiNguoidungs",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucTiepNhans",
                table: "DanhMucTiepNhans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucQuyens",
                table: "DanhmucQuyens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucPhieuSangLocs",
                table: "DanhMucPhieuSangLocs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNhomQuyens",
                table: "DanhmucNhomQuyens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNhomNguoidungs",
                table: "DanhmucNhomNguoidungs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNguoidungs",
                table: "DanhmucNguoidungs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucLoaiTiepNhans",
                table: "DanhMucLoaiTiepNhans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucLoaiNguoidungs",
                table: "DanhmucLoaiNguoidungs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucDanhGiaChatLuongMauNghiepVus",
                table: "DanhMucDanhGiaChatLuongMauNghiepVus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucChitietQuyenNguoidungs",
                table: "DanhmucChitietQuyenNguoidungs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaXN_SLSSs",
                table: "DanhMucChiTietKetQuaXN_SLSSs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaThongSoXNs",
                table: "DanhMucChiTietKetQuaThongSoXNs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChiTietDanhGiaChatLuongMaus",
                table: "DanhMucChiTietDanhGiaChatLuongMaus",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucQuyens_IdNhomQuyen",
                table: "DanhmucQuyens",
                column: "IdNhomQuyen");

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
                name: "IX_DanhmucNguoidungs_IdLoaiUser",
                table: "DanhmucNguoidungs",
                column: "IdLoaiUser");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucLoaiNguoidungs_IdNhomUser",
                table: "DanhmucLoaiNguoidungs",
                column: "IdNhomUser");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanhGiaChatLuongMauNghiepVus_IdTiepNhan",
                table: "DanhMucDanhGiaChatLuongMauNghiepVus",
                column: "IdTiepNhan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietQuyenNguoidungs_IdQuyen",
                table: "DanhmucChitietQuyenNguoidungs",
                column: "IdQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietQuyenNguoidungs_IdUser",
                table: "DanhmucChitietQuyenNguoidungs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSSs_IdDichVu_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs",
                column: "IdDichVu_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSSs_IdKetQuaXN_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs",
                column: "IdKetQuaXN_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaThongSoXNs_IdChiTietKQXN_SLSS",
                table: "DanhMucChiTietKetQuaThongSoXNs",
                column: "IdChiTietKQXN_SLSS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMaus_IdDanhGiaChatLuongMau",
                table: "DanhMucChiTietDanhGiaChatLuongMaus",
                column: "IdDanhGiaChatLuongMau");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMaus_IdDanhGiaChatLuongMauNghiepVu",
                table: "DanhMucChiTietDanhGiaChatLuongMaus",
                column: "IdDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMaus_DanhmucDanhgiaChatluongMaus_IdDanhGiaChatLuongMau",
                table: "DanhMucChiTietDanhGiaChatLuongMaus",
                column: "IdDanhGiaChatLuongMau",
                principalTable: "DanhmucDanhgiaChatluongMaus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMaus_DanhMucDanhGiaChatLuongMauNghiepVus_IdDanhGiaChatLuongMauNghiepVu",
                table: "DanhMucChiTietDanhGiaChatLuongMaus",
                column: "IdDanhGiaChatLuongMauNghiepVu",
                principalTable: "DanhMucDanhGiaChatLuongMauNghiepVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietKetQuaThongSoXNs_DanhMucChiTietKetQuaXN_SLSSs_IdChiTietKQXN_SLSS",
                table: "DanhMucChiTietKetQuaThongSoXNs",
                column: "IdChiTietKQXN_SLSS",
                principalTable: "DanhMucChiTietKetQuaXN_SLSSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSSs_DanhmucDichvuSLSSs_IdDichVu_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs",
                column: "IdDichVu_SLSS",
                principalTable: "DanhmucDichvuSLSSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSSs_DanhMucKetQuaXN_SLSS_IdKetQuaXN_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs",
                column: "IdKetQuaXN_SLSS",
                principalTable: "DanhMucKetQuaXN_SLSS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidungs_DanhmucQuyens_IdQuyen",
                table: "DanhmucChitietQuyenNguoidungs",
                column: "IdQuyen",
                principalTable: "DanhmucQuyens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidungs_DanhmucNguoidungs_IdUser",
                table: "DanhmucChitietQuyenNguoidungs",
                column: "IdUser",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDanhGiaChatLuongMauNghiepVus_DanhMucTiepNhans_IdTiepNhan",
                table: "DanhMucDanhGiaChatLuongMauNghiepVus",
                column: "IdTiepNhan",
                principalTable: "DanhMucTiepNhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKetQuaXN_SLSS_DanhmucNguoidungs_DanhmucNguoidungId",
                table: "DanhMucKetQuaXN_SLSS",
                column: "DanhmucNguoidungId",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucLoaiNguoidungs_DanhmucNhomNguoidungs_IdNhomUser",
                table: "DanhmucLoaiNguoidungs",
                column: "IdNhomUser",
                principalTable: "DanhmucNhomNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucNguoidungs_DanhmucLoaiNguoidungs_IdLoaiUser",
                table: "DanhmucNguoidungs",
                column: "IdLoaiUser",
                principalTable: "DanhmucLoaiNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucNguoidungs_DanhmucNguoidungId",
                table: "DanhMucPhieuSangLocs",
                column: "DanhmucNguoidungId",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucChedodinhduongs_IdCheDoDinhDuong",
                table: "DanhMucPhieuSangLocs",
                column: "IdCheDoDinhDuong",
                principalTable: "DanhmucChedodinhduongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucThongtinKhachhangs_IdKhachHang",
                table: "DanhMucPhieuSangLocs",
                column: "IdKhachHang",
                principalTable: "DanhmucThongtinKhachhangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucTinhtrangs_IdTinhTrang",
                table: "DanhMucPhieuSangLocs",
                column: "IdTinhTrang",
                principalTable: "DanhmucTinhtrangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhMucTrangThaiMau_IdTrangThaiMau",
                table: "DanhMucPhieuSangLocs",
                column: "IdTrangThaiMau",
                principalTable: "DanhMucTrangThaiMau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucVitrilaymaus_IdViTriLayMau",
                table: "DanhMucPhieuSangLocs",
                column: "IdViTriLayMau",
                principalTable: "DanhmucVitrilaymaus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLocs_MapDonvicosoTrungtams_MapDonvicosoTrungtamId",
                table: "DanhMucPhieuSangLocs",
                column: "MapDonvicosoTrungtamId",
                principalTable: "MapDonvicosoTrungtams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucQuyens_DanhmucNhomQuyens_IdNhomQuyen",
                table: "DanhmucQuyens",
                column: "IdNhomQuyen",
                principalTable: "DanhmucNhomQuyens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTiepNhans_DanhMucLoaiTiepNhans_IdLoaiTiepNhan",
                table: "DanhMucTiepNhans",
                column: "IdLoaiTiepNhan",
                principalTable: "DanhMucLoaiTiepNhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTiepNhans_DanhmucNguoidungs_IdNhanVienTiepNhan",
                table: "DanhMucTiepNhans",
                column: "IdNhanVienTiepNhan",
                principalTable: "DanhmucNguoidungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTiepNhans_DanhMucPhieuSangLocs_IdPhieuSangLoc",
                table: "DanhMucTiepNhans",
                column: "IdPhieuSangLoc",
                principalTable: "DanhMucPhieuSangLocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMaus_DanhmucDanhgiaChatluongMaus_IdDanhGiaChatLuongMau",
                table: "DanhMucChiTietDanhGiaChatLuongMaus");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMaus_DanhMucDanhGiaChatLuongMauNghiepVus_IdDanhGiaChatLuongMauNghiepVu",
                table: "DanhMucChiTietDanhGiaChatLuongMaus");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietKetQuaThongSoXNs_DanhMucChiTietKetQuaXN_SLSSs_IdChiTietKQXN_SLSS",
                table: "DanhMucChiTietKetQuaThongSoXNs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSSs_DanhmucDichvuSLSSs_IdDichVu_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSSs_DanhMucKetQuaXN_SLSS_IdKetQuaXN_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidungs_DanhmucQuyens_IdQuyen",
                table: "DanhmucChitietQuyenNguoidungs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidungs_DanhmucNguoidungs_IdUser",
                table: "DanhmucChitietQuyenNguoidungs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDanhGiaChatLuongMauNghiepVus_DanhMucTiepNhans_IdTiepNhan",
                table: "DanhMucDanhGiaChatLuongMauNghiepVus");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucKetQuaXN_SLSS_DanhmucNguoidungs_DanhmucNguoidungId",
                table: "DanhMucKetQuaXN_SLSS");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucLoaiNguoidungs_DanhmucNhomNguoidungs_IdNhomUser",
                table: "DanhmucLoaiNguoidungs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucNguoidungs_DanhmucLoaiNguoidungs_IdLoaiUser",
                table: "DanhmucNguoidungs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucNguoidungs_DanhmucNguoidungId",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucChedodinhduongs_IdCheDoDinhDuong",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucThongtinKhachhangs_IdKhachHang",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucTinhtrangs_IdTinhTrang",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhMucTrangThaiMau_IdTrangThaiMau",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLocs_DanhmucVitrilaymaus_IdViTriLayMau",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLocs_MapDonvicosoTrungtams_MapDonvicosoTrungtamId",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucQuyens_DanhmucNhomQuyens_IdNhomQuyen",
                table: "DanhmucQuyens");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTiepNhans_DanhMucLoaiTiepNhans_IdLoaiTiepNhan",
                table: "DanhMucTiepNhans");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTiepNhans_DanhmucNguoidungs_IdNhanVienTiepNhan",
                table: "DanhMucTiepNhans");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucTiepNhans_DanhMucPhieuSangLocs_IdPhieuSangLoc",
                table: "DanhMucTiepNhans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucTiepNhans",
                table: "DanhMucTiepNhans");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTiepNhans_IdLoaiTiepNhan",
                table: "DanhMucTiepNhans");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTiepNhans_IdNhanVienTiepNhan",
                table: "DanhMucTiepNhans");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucTiepNhans_IdPhieuSangLoc",
                table: "DanhMucTiepNhans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucQuyens",
                table: "DanhmucQuyens");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucQuyens_IdNhomQuyen",
                table: "DanhmucQuyens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucPhieuSangLocs",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLocs_IdCheDoDinhDuong",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLocs_IdKhachHang",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLocs_IdTinhTrang",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLocs_IdTrangThaiMau",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhieuSangLocs_IdViTriLayMau",
                table: "DanhMucPhieuSangLocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNhomQuyens",
                table: "DanhmucNhomQuyens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNhomNguoidungs",
                table: "DanhmucNhomNguoidungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNguoidungs",
                table: "DanhmucNguoidungs");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucNguoidungs_IdLoaiUser",
                table: "DanhmucNguoidungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucLoaiTiepNhans",
                table: "DanhMucLoaiTiepNhans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucLoaiNguoidungs",
                table: "DanhmucLoaiNguoidungs");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucLoaiNguoidungs_IdNhomUser",
                table: "DanhmucLoaiNguoidungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucDanhGiaChatLuongMauNghiepVus",
                table: "DanhMucDanhGiaChatLuongMauNghiepVus");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucDanhGiaChatLuongMauNghiepVus_IdTiepNhan",
                table: "DanhMucDanhGiaChatLuongMauNghiepVus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucChitietQuyenNguoidungs",
                table: "DanhmucChitietQuyenNguoidungs");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietQuyenNguoidungs_IdQuyen",
                table: "DanhmucChitietQuyenNguoidungs");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietQuyenNguoidungs_IdUser",
                table: "DanhmucChitietQuyenNguoidungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaXN_SLSSs",
                table: "DanhMucChiTietKetQuaXN_SLSSs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSSs_IdDichVu_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSSs_IdKetQuaXN_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSSs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaThongSoXNs",
                table: "DanhMucChiTietKetQuaThongSoXNs");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietKetQuaThongSoXNs_IdChiTietKQXN_SLSS",
                table: "DanhMucChiTietKetQuaThongSoXNs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChiTietDanhGiaChatLuongMaus",
                table: "DanhMucChiTietDanhGiaChatLuongMaus");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMaus_IdDanhGiaChatLuongMau",
                table: "DanhMucChiTietDanhGiaChatLuongMaus");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMaus_IdDanhGiaChatLuongMauNghiepVu",
                table: "DanhMucChiTietDanhGiaChatLuongMaus");

            migrationBuilder.RenameTable(
                name: "DanhMucTiepNhans",
                newName: "DanhMucTiepNhan");

            migrationBuilder.RenameTable(
                name: "DanhmucQuyens",
                newName: "DanhmucQuyen");

            migrationBuilder.RenameTable(
                name: "DanhMucPhieuSangLocs",
                newName: "DanhMucPhieuSangLoc");

            migrationBuilder.RenameTable(
                name: "DanhmucNhomQuyens",
                newName: "DanhmucNhomQuyen");

            migrationBuilder.RenameTable(
                name: "DanhmucNhomNguoidungs",
                newName: "DanhmucNhomNguoidung");

            migrationBuilder.RenameTable(
                name: "DanhmucNguoidungs",
                newName: "DanhmucNguoidung");

            migrationBuilder.RenameTable(
                name: "DanhMucLoaiTiepNhans",
                newName: "DanhMucLoaiTiepNhan");

            migrationBuilder.RenameTable(
                name: "DanhmucLoaiNguoidungs",
                newName: "DanhmucLoaiNguoidung");

            migrationBuilder.RenameTable(
                name: "DanhMucDanhGiaChatLuongMauNghiepVus",
                newName: "DanhMucDanhGiaChatLuongMauNghiepVu");

            migrationBuilder.RenameTable(
                name: "DanhmucChitietQuyenNguoidungs",
                newName: "DanhmucChitietQuyenNguoidung");

            migrationBuilder.RenameTable(
                name: "DanhMucChiTietKetQuaXN_SLSSs",
                newName: "DanhMucChiTietKetQuaXN_SLSS");

            migrationBuilder.RenameTable(
                name: "DanhMucChiTietKetQuaThongSoXNs",
                newName: "DanhMucChiTietKetQuaThongSoXN");

            migrationBuilder.RenameTable(
                name: "DanhMucChiTietDanhGiaChatLuongMaus",
                newName: "DanhMucChiTietDanhGiaChatLuongMau");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucPhieuSangLocs_MapDonvicosoTrungtamId",
                table: "DanhMucPhieuSangLoc",
                newName: "IX_DanhMucPhieuSangLoc_MapDonvicosoTrungtamId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucPhieuSangLocs_DanhmucNguoidungId",
                table: "DanhMucPhieuSangLoc",
                newName: "IX_DanhMucPhieuSangLoc_DanhmucNguoidungId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTiepNhan",
                table: "DanhMucTiepNhan",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 19, 20, 22, 40, 23, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.AlterColumn<string>(
                name: "MaTiepNhan",
                table: "DanhMucTiepNhan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DanhMucLoaiTiepNhanId",
                table: "DanhMucTiepNhan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhMucPhieuSangLocId",
                table: "DanhMucTiepNhan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucNguoidungId",
                table: "DanhMucTiepNhan",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenQuyen",
                table: "DanhmucQuyen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucNhomQuyenId",
                table: "DanhmucQuyen",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Para",
                table: "DanhMucPhieuSangLoc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(4)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTaoPhieu",
                table: "DanhMucPhieuSangLoc",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 3, 19, 20, 22, 40, 13, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.AlterColumn<string>(
                name: "MaPhieuSangLoc",
                table: "DanhMucPhieuSangLoc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "DanhMucTrangThaiMauId",
                table: "DanhMucPhieuSangLoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucChedodinhduongId",
                table: "DanhMucPhieuSangLoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucTinhtrangId",
                table: "DanhMucPhieuSangLoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucVitrilaymauId",
                table: "DanhMucPhieuSangLoc",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNhomQuyen",
                table: "DanhmucNhomQuyen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TenNhomUser",
                table: "DanhmucNhomNguoidung",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "DanhmucNguoidung",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "DanhmucNguoidung",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ReferenCode",
                table: "DanhmucNguoidung",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "DanhmucNguoidung",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DanhmucLoaiNguoidungId",
                table: "DanhmucNguoidung",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiTiepNhan",
                table: "DanhMucLoaiTiepNhan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiUser",
                table: "DanhmucLoaiNguoidung",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucNhomNguoidungId",
                table: "DanhmucLoaiNguoidung",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhMucTiepNhanId",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucNguoidungId",
                table: "DanhmucChitietQuyenNguoidung",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucQuyenId",
                table: "DanhmucChitietQuyenNguoidung",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhMucKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucDichvuSLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhMucChiTietKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaThongSoXN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhMucDanhGiaChatLuongMauNghiepVuId",
                table: "DanhMucChiTietDanhGiaChatLuongMau",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucDanhgiaChatluongMauId",
                table: "DanhMucChiTietDanhGiaChatLuongMau",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucTiepNhan",
                table: "DanhMucTiepNhan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucQuyen",
                table: "DanhmucQuyen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucPhieuSangLoc",
                table: "DanhMucPhieuSangLoc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNhomQuyen",
                table: "DanhmucNhomQuyen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNhomNguoidung",
                table: "DanhmucNhomNguoidung",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNguoidung",
                table: "DanhmucNguoidung",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucLoaiTiepNhan",
                table: "DanhMucLoaiTiepNhan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucLoaiNguoidung",
                table: "DanhmucLoaiNguoidung",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucDanhGiaChatLuongMauNghiepVu",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucChitietQuyenNguoidung",
                table: "DanhmucChitietQuyenNguoidung",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaXN_SLSS",
                table: "DanhMucChiTietKetQuaXN_SLSS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChiTietKetQuaThongSoXN",
                table: "DanhMucChiTietKetQuaThongSoXN",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChiTietDanhGiaChatLuongMau",
                table: "DanhMucChiTietDanhGiaChatLuongMau",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTiepNhan_DanhMucLoaiTiepNhanId",
                table: "DanhMucTiepNhan",
                column: "DanhMucLoaiTiepNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTiepNhan_DanhMucPhieuSangLocId",
                table: "DanhMucTiepNhan",
                column: "DanhMucPhieuSangLocId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTiepNhan_DanhmucNguoidungId",
                table: "DanhMucTiepNhan",
                column: "DanhmucNguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucQuyen_DanhmucNhomQuyenId",
                table: "DanhmucQuyen",
                column: "DanhmucNhomQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhMucTrangThaiMauId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhMucTrangThaiMauId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucChedodinhduongId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucChedodinhduongId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucThongtinKhachhangId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucTinhtrangId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucTinhtrangId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhieuSangLoc_DanhmucVitrilaymauId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucVitrilaymauId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucNguoidung_DanhmucLoaiNguoidungId",
                table: "DanhmucNguoidung",
                column: "DanhmucLoaiNguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucLoaiNguoidung_DanhmucNhomNguoidungId",
                table: "DanhmucLoaiNguoidung",
                column: "DanhmucNhomNguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucDanhGiaChatLuongMauNghiepVu_DanhMucTiepNhanId",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu",
                column: "DanhMucTiepNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietQuyenNguoidung_DanhmucNguoidungId",
                table: "DanhmucChitietQuyenNguoidung",
                column: "DanhmucNguoidungId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietQuyenNguoidung_DanhmucQuyenId",
                table: "DanhmucChitietQuyenNguoidung",
                column: "DanhmucQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSS_DanhMucKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS",
                column: "DanhMucKetQuaXN_SLSSId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaXN_SLSS_DanhmucDichvuSLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS",
                column: "DanhmucDichvuSLSSId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietKetQuaThongSoXN_DanhMucChiTietKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaThongSoXN",
                column: "DanhMucChiTietKetQuaXN_SLSSId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMau_DanhMucDanhGiaChatLuongMauNghiepVuId",
                table: "DanhMucChiTietDanhGiaChatLuongMau",
                column: "DanhMucDanhGiaChatLuongMauNghiepVuId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucChiTietDanhGiaChatLuongMau_DanhmucDanhgiaChatluongMauId",
                table: "DanhMucChiTietDanhGiaChatLuongMau",
                column: "DanhmucDanhgiaChatluongMauId");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMau_DanhMucDanhGiaChatLuongMauNghiepVu_DanhMucDanhGiaChatLuongMauNghiepVuId",
                table: "DanhMucChiTietDanhGiaChatLuongMau",
                column: "DanhMucDanhGiaChatLuongMauNghiepVuId",
                principalTable: "DanhMucDanhGiaChatLuongMauNghiepVu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietDanhGiaChatLuongMau_DanhmucDanhgiaChatluongMaus_DanhmucDanhgiaChatluongMauId",
                table: "DanhMucChiTietDanhGiaChatLuongMau",
                column: "DanhmucDanhgiaChatluongMauId",
                principalTable: "DanhmucDanhgiaChatluongMaus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietKetQuaThongSoXN_DanhMucChiTietKetQuaXN_SLSS_DanhMucChiTietKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaThongSoXN",
                column: "DanhMucChiTietKetQuaXN_SLSSId",
                principalTable: "DanhMucChiTietKetQuaXN_SLSS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSS_DanhMucKetQuaXN_SLSS_DanhMucKetQuaXN_SLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS",
                column: "DanhMucKetQuaXN_SLSSId",
                principalTable: "DanhMucKetQuaXN_SLSS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucChiTietKetQuaXN_SLSS_DanhmucDichvuSLSSs_DanhmucDichvuSLSSId",
                table: "DanhMucChiTietKetQuaXN_SLSS",
                column: "DanhmucDichvuSLSSId",
                principalTable: "DanhmucDichvuSLSSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidung_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhmucChitietQuyenNguoidung",
                column: "DanhmucNguoidungId",
                principalTable: "DanhmucNguoidung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietQuyenNguoidung_DanhmucQuyen_DanhmucQuyenId",
                table: "DanhmucChitietQuyenNguoidung",
                column: "DanhmucQuyenId",
                principalTable: "DanhmucQuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDanhGiaChatLuongMauNghiepVu_DanhMucTiepNhan_DanhMucTiepNhanId",
                table: "DanhMucDanhGiaChatLuongMauNghiepVu",
                column: "DanhMucTiepNhanId",
                principalTable: "DanhMucTiepNhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucKetQuaXN_SLSS_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhMucKetQuaXN_SLSS",
                column: "DanhmucNguoidungId",
                principalTable: "DanhmucNguoidung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucLoaiNguoidung_DanhmucNhomNguoidung_DanhmucNhomNguoidungId",
                table: "DanhmucLoaiNguoidung",
                column: "DanhmucNhomNguoidungId",
                principalTable: "DanhmucNhomNguoidung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucNguoidung_DanhmucLoaiNguoidung_DanhmucLoaiNguoidungId",
                table: "DanhmucNguoidung",
                column: "DanhmucLoaiNguoidungId",
                principalTable: "DanhmucLoaiNguoidung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhMucTrangThaiMau_DanhMucTrangThaiMauId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhMucTrangThaiMauId",
                principalTable: "DanhMucTrangThaiMau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucChedodinhduongs_DanhmucChedodinhduongId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucChedodinhduongId",
                principalTable: "DanhmucChedodinhduongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucNguoidungId",
                principalTable: "DanhmucNguoidung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucThongtinKhachhangs_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucThongtinKhachhangId",
                principalTable: "DanhmucThongtinKhachhangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucTinhtrangs_DanhmucTinhtrangId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucTinhtrangId",
                principalTable: "DanhmucTinhtrangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucVitrilaymaus_DanhmucVitrilaymauId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucVitrilaymauId",
                principalTable: "DanhmucVitrilaymaus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_MapDonvicosoTrungtams_MapDonvicosoTrungtamId",
                table: "DanhMucPhieuSangLoc",
                column: "MapDonvicosoTrungtamId",
                principalTable: "MapDonvicosoTrungtams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucQuyen_DanhmucNhomQuyen_DanhmucNhomQuyenId",
                table: "DanhmucQuyen",
                column: "DanhmucNhomQuyenId",
                principalTable: "DanhmucNhomQuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTiepNhan_DanhMucLoaiTiepNhan_DanhMucLoaiTiepNhanId",
                table: "DanhMucTiepNhan",
                column: "DanhMucLoaiTiepNhanId",
                principalTable: "DanhMucLoaiTiepNhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTiepNhan_DanhMucPhieuSangLoc_DanhMucPhieuSangLocId",
                table: "DanhMucTiepNhan",
                column: "DanhMucPhieuSangLocId",
                principalTable: "DanhMucPhieuSangLoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucTiepNhan_DanhmucNguoidung_DanhmucNguoidungId",
                table: "DanhMucTiepNhan",
                column: "DanhmucNguoidungId",
                principalTable: "DanhmucNguoidung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
