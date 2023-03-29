using Microsoft.EntityFrameworkCore.Migrations;

namespace BioNet.Entities.Migrations
{
    public partial class adddanhmucpatientcareandkhachhang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuPatientCare_DanhmucDichvuPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuXNPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCare_DanhmucGoiXNTheobenhPatientCare_DanhmucGoiXNTheobenhPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucDichvuXNPatientCare_DanhmucNhomXNPatientCare_DanhmucNhomXNPatientCareId",
                table: "DanhmucDichvuXNPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucGoiXNTheobenhPatientCare_DanhmucDichvuPatientCare_DanhmucDichvuPatientCareId",
                table: "DanhmucGoiXNTheobenhPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucLoaiXNPatientCare_DanhmucMenuXNPatientCare_DanhmucMenuXNPatientCareId",
                table: "DanhmucLoaiXNPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucNhomXNPatientCare_DanhmucLoaiXNPatientCare_DanhmucLoaiXNPatientCareId",
                table: "DanhmucNhomXNPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucThongtinKhachhang_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCare_DanhmucDichvuXNPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCare_DanhmucDonvidoPatientCare_DanhmucDonvidoPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCare_DanhmucThongsoXNPatientCare_DanhmucThongsoXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNPatientCare_DanhmucTrungtams_DanhmucTrungtamId",
                table: "DanhmucThongsoXNPatientCare");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongtinKhachhang_DanhmucPhuongphapsinh_DanhmucPhuongphapsinhId",
                table: "DanhmucThongtinKhachhang");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongtinKhachhang_DanhmucPhuongxas_DanhmucPhuongxaId",
                table: "DanhmucThongtinKhachhang");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThongTinNguoiThan_DanhmucLoainguoithan_DanhmucLoainguoithanId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThongTinNguoiThan_DanhmucPhuongxas_DanhmucPhuongxaId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThongTinNguoiThan_DanhmucThongtinKhachhang_DanhmucThongtinKhachhangId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucThongTinNguoiThan",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThongTinNguoiThan_DanhmucLoainguoithanId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThongTinNguoiThan_DanhmucPhuongxaId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThongTinNguoiThan_DanhmucThongtinKhachhangId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucThongtinKhachhang",
                table: "DanhmucThongtinKhachhang");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongtinKhachhang_DanhmucPhuongphapsinhId",
                table: "DanhmucThongtinKhachhang");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongtinKhachhang_DanhmucPhuongxaId",
                table: "DanhmucThongtinKhachhang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucThongsoXNPatientCare",
                table: "DanhmucThongsoXNPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucThongsoXNDichvuPatientCare",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCare_DanhmucDonvidoPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCare_DanhmucThongsoXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNhomXNPatientCare",
                table: "DanhmucNhomXNPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucNhomXNPatientCare_DanhmucLoaiXNPatientCareId",
                table: "DanhmucNhomXNPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucMenuXNPatientCare",
                table: "DanhmucMenuXNPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucLoaiXNPatientCare",
                table: "DanhmucLoaiXNPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucLoaiXNPatientCare_DanhmucMenuXNPatientCareId",
                table: "DanhmucLoaiXNPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucLoainguoithan",
                table: "DanhmucLoainguoithan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucGoiXNTheobenhPatientCare",
                table: "DanhmucGoiXNTheobenhPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucGoiXNTheobenhPatientCare_DanhmucDichvuPatientCareId",
                table: "DanhmucGoiXNTheobenhPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucDonvidoPatientCare",
                table: "DanhmucDonvidoPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucDichvuXNPatientCare",
                table: "DanhmucDichvuXNPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucDichvuXNPatientCare_DanhmucNhomXNPatientCareId",
                table: "DanhmucDichvuXNPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucDichvuPatientCare",
                table: "DanhmucDichvuPatientCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucChitietGoiDVXNPatientCare",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCare_DanhmucGoiXNTheobenhPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucLoainguoithanId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropColumn(
                name: "DanhmucPhuongxaId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropColumn(
                name: "DanhmucThongtinKhachhangId",
                table: "DanhMucThongTinNguoiThan");

            migrationBuilder.DropColumn(
                name: "DanhmucPhuongphapsinhId",
                table: "DanhmucThongtinKhachhang");

            migrationBuilder.DropColumn(
                name: "DanhmucPhuongxaId",
                table: "DanhmucThongtinKhachhang");

            migrationBuilder.DropColumn(
                name: "DanhmucDichvuXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucDonvidoPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucThongsoXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucLoaiXNPatientCareId",
                table: "DanhmucNhomXNPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucMenuXNPatientCareId",
                table: "DanhmucLoaiXNPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucDichvuPatientCareId",
                table: "DanhmucGoiXNTheobenhPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucNhomXNPatientCareId",
                table: "DanhmucDichvuXNPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucDichvuXNPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.DropColumn(
                name: "DanhmucGoiXNTheobenhPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhMucThongTinNguoiThan",
                newName: "DanhMucThongTinNguoiThans");

            migrationBuilder.RenameTable(
                name: "DanhmucThongtinKhachhang",
                newName: "DanhmucThongtinKhachhangs");

            migrationBuilder.RenameTable(
                name: "DanhmucThongsoXNPatientCare",
                newName: "DanhmucThongsoXNPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucThongsoXNDichvuPatientCare",
                newName: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucNhomXNPatientCare",
                newName: "DanhmucNhomXNPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucMenuXNPatientCare",
                newName: "DanhmucMenuXNPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucLoaiXNPatientCare",
                newName: "DanhmucLoaiXNPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucLoainguoithan",
                newName: "DanhmucLoainguoithans");

            migrationBuilder.RenameTable(
                name: "DanhmucGoiXNTheobenhPatientCare",
                newName: "DanhmucGoiXNTheobenhPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucDonvidoPatientCare",
                newName: "DanhmucDonvidoPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucDichvuXNPatientCare",
                newName: "DanhmucDichvuXNPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucDichvuPatientCare",
                newName: "DanhmucDichvuPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhmucChitietGoiDVXNPatientCare",
                newName: "DanhmucChitietGoiDVXNPatientCares");

            migrationBuilder.RenameIndex(
                name: "IX_DanhmucThongsoXNPatientCare_DanhmucTrungtamId",
                table: "DanhmucThongsoXNPatientCares",
                newName: "IX_DanhmucThongsoXNPatientCares_DanhmucTrungtamId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCares",
                newName: "IX_DanhmucChitietGoiDVXNPatientCares_DanhmucDichvuPatientCareId");

            migrationBuilder.AlterColumn<string>(
                name: "TenNguoiThan",
                table: "DanhMucThongTinNguoiThans",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NgaySinhNguoiThan",
                table: "DanhMucThongTinNguoiThans",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenKhachHang",
                table: "DanhmucThongtinKhachhangs",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Para",
                table: "DanhmucThongtinKhachhangs",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaKhachHang",
                table: "DanhmucThongtinKhachhangs",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenThongSoXetNghiemP",
                table: "DanhmucThongsoXNPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenHienThiThongSoXetNghiemP",
                table: "DanhmucThongsoXNPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaThongSoXetNghiemP",
                table: "DanhmucThongsoXNPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNhomXetNghiemP",
                table: "DanhmucNhomXNPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhomXetNghiemP",
                table: "DanhmucNhomXNPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "DanhmucMenuXNPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuCode",
                table: "DanhmucMenuXNPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiXetNghiemP",
                table: "DanhmucLoaiXNPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaLoaiXetNghiemP",
                table: "DanhmucLoaiXNPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiNguoiThan",
                table: "DanhmucLoainguoithans",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenGoiXetNghiemP",
                table: "DanhmucGoiXNTheobenhPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaGoiXetNghiemP",
                table: "DanhmucGoiXNTheobenhPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDonViDoP",
                table: "DanhmucDonvidoPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDonViDoP",
                table: "DanhmucDonvidoPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDichVuXetNghiemP",
                table: "DanhmucDichvuXNPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDichVuXetNghiemP",
                table: "DanhmucDichvuXNPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenHienThiDichVuP",
                table: "DanhmucDichvuPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDichVuP",
                table: "DanhmucDichvuPatientCares",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDichVuP",
                table: "DanhmucDichvuPatientCares",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucThongTinNguoiThans",
                table: "DanhMucThongTinNguoiThans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucThongtinKhachhangs",
                table: "DanhmucThongtinKhachhangs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucThongsoXNPatientCares",
                table: "DanhmucThongsoXNPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucThongsoXNDichvuPatientCares",
                table: "DanhmucThongsoXNDichvuPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNhomXNPatientCares",
                table: "DanhmucNhomXNPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucMenuXNPatientCares",
                table: "DanhmucMenuXNPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucLoaiXNPatientCares",
                table: "DanhmucLoaiXNPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucLoainguoithans",
                table: "DanhmucLoainguoithans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucGoiXNTheobenhPatientCares",
                table: "DanhmucGoiXNTheobenhPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucDonvidoPatientCares",
                table: "DanhmucDonvidoPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucDichvuXNPatientCares",
                table: "DanhmucDichvuXNPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucDichvuPatientCares",
                table: "DanhmucDichvuPatientCares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucChitietGoiDVXNPatientCares",
                table: "DanhmucChitietGoiDVXNPatientCares",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThongTinNguoiThans_IdKhachHang",
                table: "DanhMucThongTinNguoiThans",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThongTinNguoiThans_IdLoaiNguoiThan",
                table: "DanhMucThongTinNguoiThans",
                column: "IdLoaiNguoiThan");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThongTinNguoiThans_IdPhuongXa",
                table: "DanhMucThongTinNguoiThans",
                column: "IdPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongtinKhachhangs_IdPhuongPhapSinh",
                table: "DanhmucThongtinKhachhangs",
                column: "IdPhuongPhapSinh");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongtinKhachhangs_IdPhuongXa",
                table: "DanhmucThongtinKhachhangs",
                column: "IdPhuongXa");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCares_IdDichVuXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares",
                column: "IdDichVuXetNghiemP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCares_IdDonViDoP",
                table: "DanhmucThongsoXNDichvuPatientCares",
                column: "IdDonViDoP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCares_IdThongSoXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares",
                column: "IdThongSoXetNghiemP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucNhomXNPatientCares_IdLoaiXetNghiemP",
                table: "DanhmucNhomXNPatientCares",
                column: "IdLoaiXetNghiemP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucLoaiXNPatientCares_IdMenu",
                table: "DanhmucLoaiXNPatientCares",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucGoiXNTheobenhPatientCares_IdDichVuP",
                table: "DanhmucGoiXNTheobenhPatientCares",
                column: "IdDichVuP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucDichvuXNPatientCares_IdNhomXetNghiemP",
                table: "DanhmucDichvuXNPatientCares",
                column: "IdNhomXetNghiemP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCares_IdDichVuXetNghiemNP",
                table: "DanhmucChitietGoiDVXNPatientCares",
                column: "IdDichVuXetNghiemNP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCares_IdGoiXetNghiemP",
                table: "DanhmucChitietGoiDVXNPatientCares",
                column: "IdGoiXetNghiemP");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCares_DanhmucDichvuPatientCares_DanhmucDichvuPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCares",
                column: "DanhmucDichvuPatientCareId",
                principalTable: "DanhmucDichvuPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiemNP",
                table: "DanhmucChitietGoiDVXNPatientCares",
                column: "IdDichVuXetNghiemNP",
                principalTable: "DanhmucDichvuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCares_DanhmucGoiXNTheobenhPatientCares_IdGoiXetNghiemP",
                table: "DanhmucChitietGoiDVXNPatientCares",
                column: "IdGoiXetNghiemP",
                principalTable: "DanhmucGoiXNTheobenhPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucDichvuXNPatientCares_DanhmucNhomXNPatientCares_IdNhomXetNghiemP",
                table: "DanhmucDichvuXNPatientCares",
                column: "IdNhomXetNghiemP",
                principalTable: "DanhmucNhomXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucGoiXNTheobenhPatientCares_DanhmucDichvuPatientCares_IdDichVuP",
                table: "DanhmucGoiXNTheobenhPatientCares",
                column: "IdDichVuP",
                principalTable: "DanhmucDichvuPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucLoaiXNPatientCares_DanhmucMenuXNPatientCares_IdMenu",
                table: "DanhmucLoaiXNPatientCares",
                column: "IdMenu",
                principalTable: "DanhmucMenuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucNhomXNPatientCares_DanhmucLoaiXNPatientCares_IdLoaiXetNghiemP",
                table: "DanhmucNhomXNPatientCares",
                column: "IdLoaiXetNghiemP",
                principalTable: "DanhmucLoaiXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucThongtinKhachhangs_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucThongtinKhachhangId",
                principalTable: "DanhmucThongtinKhachhangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares",
                column: "IdDichVuXetNghiemP",
                principalTable: "DanhmucDichvuXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCares_DanhmucDonvidoPatientCares_IdDonViDoP",
                table: "DanhmucThongsoXNDichvuPatientCares",
                column: "IdDonViDoP",
                principalTable: "DanhmucDonvidoPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCares_DanhmucThongsoXNPatientCares_IdThongSoXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares",
                column: "IdThongSoXetNghiemP",
                principalTable: "DanhmucThongsoXNPatientCares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNPatientCares_DanhmucTrungtams_DanhmucTrungtamId",
                table: "DanhmucThongsoXNPatientCares",
                column: "DanhmucTrungtamId",
                principalTable: "DanhmucTrungtams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongtinKhachhangs_DanhmucPhuongphapsinh_IdPhuongPhapSinh",
                table: "DanhmucThongtinKhachhangs",
                column: "IdPhuongPhapSinh",
                principalTable: "DanhmucPhuongphapsinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongtinKhachhangs_DanhmucPhuongxas_IdPhuongXa",
                table: "DanhmucThongtinKhachhangs",
                column: "IdPhuongXa",
                principalTable: "DanhmucPhuongxas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThongTinNguoiThans_DanhmucThongtinKhachhangs_IdKhachHang",
                table: "DanhMucThongTinNguoiThans",
                column: "IdKhachHang",
                principalTable: "DanhmucThongtinKhachhangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThongTinNguoiThans_DanhmucLoainguoithans_IdLoaiNguoiThan",
                table: "DanhMucThongTinNguoiThans",
                column: "IdLoaiNguoiThan",
                principalTable: "DanhmucLoainguoithans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThongTinNguoiThans_DanhmucPhuongxas_IdPhuongXa",
                table: "DanhMucThongTinNguoiThans",
                column: "IdPhuongXa",
                principalTable: "DanhmucPhuongxas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCares_DanhmucDichvuPatientCares_DanhmucDichvuPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiemNP",
                table: "DanhmucChitietGoiDVXNPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCares_DanhmucGoiXNTheobenhPatientCares_IdGoiXetNghiemP",
                table: "DanhmucChitietGoiDVXNPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucDichvuXNPatientCares_DanhmucNhomXNPatientCares_IdNhomXetNghiemP",
                table: "DanhmucDichvuXNPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucGoiXNTheobenhPatientCares_DanhmucDichvuPatientCares_IdDichVuP",
                table: "DanhmucGoiXNTheobenhPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucLoaiXNPatientCares_DanhmucMenuXNPatientCares_IdMenu",
                table: "DanhmucLoaiXNPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucNhomXNPatientCares_DanhmucLoaiXNPatientCares_IdLoaiXetNghiemP",
                table: "DanhmucNhomXNPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucThongtinKhachhangs_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCares_DanhmucDichvuXNPatientCares_IdDichVuXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCares_DanhmucDonvidoPatientCares_IdDonViDoP",
                table: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCares_DanhmucThongsoXNPatientCares_IdThongSoXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongsoXNPatientCares_DanhmucTrungtams_DanhmucTrungtamId",
                table: "DanhmucThongsoXNPatientCares");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongtinKhachhangs_DanhmucPhuongphapsinh_IdPhuongPhapSinh",
                table: "DanhmucThongtinKhachhangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhmucThongtinKhachhangs_DanhmucPhuongxas_IdPhuongXa",
                table: "DanhmucThongtinKhachhangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThongTinNguoiThans_DanhmucThongtinKhachhangs_IdKhachHang",
                table: "DanhMucThongTinNguoiThans");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThongTinNguoiThans_DanhmucLoainguoithans_IdLoaiNguoiThan",
                table: "DanhMucThongTinNguoiThans");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucThongTinNguoiThans_DanhmucPhuongxas_IdPhuongXa",
                table: "DanhMucThongTinNguoiThans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucThongTinNguoiThans",
                table: "DanhMucThongTinNguoiThans");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThongTinNguoiThans_IdKhachHang",
                table: "DanhMucThongTinNguoiThans");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThongTinNguoiThans_IdLoaiNguoiThan",
                table: "DanhMucThongTinNguoiThans");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucThongTinNguoiThans_IdPhuongXa",
                table: "DanhMucThongTinNguoiThans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucThongtinKhachhangs",
                table: "DanhmucThongtinKhachhangs");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongtinKhachhangs_IdPhuongPhapSinh",
                table: "DanhmucThongtinKhachhangs");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongtinKhachhangs_IdPhuongXa",
                table: "DanhmucThongtinKhachhangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucThongsoXNPatientCares",
                table: "DanhmucThongsoXNPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucThongsoXNDichvuPatientCares",
                table: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCares_IdDichVuXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCares_IdDonViDoP",
                table: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCares_IdThongSoXetNghiemP",
                table: "DanhmucThongsoXNDichvuPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucNhomXNPatientCares",
                table: "DanhmucNhomXNPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucNhomXNPatientCares_IdLoaiXetNghiemP",
                table: "DanhmucNhomXNPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucMenuXNPatientCares",
                table: "DanhmucMenuXNPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucLoaiXNPatientCares",
                table: "DanhmucLoaiXNPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucLoaiXNPatientCares_IdMenu",
                table: "DanhmucLoaiXNPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucLoainguoithans",
                table: "DanhmucLoainguoithans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucGoiXNTheobenhPatientCares",
                table: "DanhmucGoiXNTheobenhPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucGoiXNTheobenhPatientCares_IdDichVuP",
                table: "DanhmucGoiXNTheobenhPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucDonvidoPatientCares",
                table: "DanhmucDonvidoPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucDichvuXNPatientCares",
                table: "DanhmucDichvuXNPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucDichvuXNPatientCares_IdNhomXetNghiemP",
                table: "DanhmucDichvuXNPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucDichvuPatientCares",
                table: "DanhmucDichvuPatientCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhmucChitietGoiDVXNPatientCares",
                table: "DanhmucChitietGoiDVXNPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCares_IdDichVuXetNghiemNP",
                table: "DanhmucChitietGoiDVXNPatientCares");

            migrationBuilder.DropIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCares_IdGoiXetNghiemP",
                table: "DanhmucChitietGoiDVXNPatientCares");

            migrationBuilder.RenameTable(
                name: "DanhMucThongTinNguoiThans",
                newName: "DanhMucThongTinNguoiThan");

            migrationBuilder.RenameTable(
                name: "DanhmucThongtinKhachhangs",
                newName: "DanhmucThongtinKhachhang");

            migrationBuilder.RenameTable(
                name: "DanhmucThongsoXNPatientCares",
                newName: "DanhmucThongsoXNPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucThongsoXNDichvuPatientCares",
                newName: "DanhmucThongsoXNDichvuPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucNhomXNPatientCares",
                newName: "DanhmucNhomXNPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucMenuXNPatientCares",
                newName: "DanhmucMenuXNPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucLoaiXNPatientCares",
                newName: "DanhmucLoaiXNPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucLoainguoithans",
                newName: "DanhmucLoainguoithan");

            migrationBuilder.RenameTable(
                name: "DanhmucGoiXNTheobenhPatientCares",
                newName: "DanhmucGoiXNTheobenhPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucDonvidoPatientCares",
                newName: "DanhmucDonvidoPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucDichvuXNPatientCares",
                newName: "DanhmucDichvuXNPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucDichvuPatientCares",
                newName: "DanhmucDichvuPatientCare");

            migrationBuilder.RenameTable(
                name: "DanhmucChitietGoiDVXNPatientCares",
                newName: "DanhmucChitietGoiDVXNPatientCare");

            migrationBuilder.RenameIndex(
                name: "IX_DanhmucThongsoXNPatientCares_DanhmucTrungtamId",
                table: "DanhmucThongsoXNPatientCare",
                newName: "IX_DanhmucThongsoXNPatientCare_DanhmucTrungtamId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCares_DanhmucDichvuPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                newName: "IX_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuPatientCareId");

            migrationBuilder.AlterColumn<string>(
                name: "TenNguoiThan",
                table: "DanhMucThongTinNguoiThan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NgaySinhNguoiThan",
                table: "DanhMucThongTinNguoiThan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucLoainguoithanId",
                table: "DanhMucThongTinNguoiThan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucPhuongxaId",
                table: "DanhMucThongTinNguoiThan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucThongtinKhachhangId",
                table: "DanhMucThongTinNguoiThan",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenKhachHang",
                table: "DanhmucThongtinKhachhang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Para",
                table: "DanhmucThongtinKhachhang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "MaKhachHang",
                table: "DanhmucThongtinKhachhang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucPhuongphapsinhId",
                table: "DanhmucThongtinKhachhang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucPhuongxaId",
                table: "DanhmucThongtinKhachhang",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenThongSoXetNghiemP",
                table: "DanhmucThongsoXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TenHienThiThongSoXetNghiemP",
                table: "DanhmucThongsoXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MaThongSoXetNghiemP",
                table: "DanhmucThongsoXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucDichvuXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucDonvidoPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucThongsoXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNhomXetNghiemP",
                table: "DanhmucNhomXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhomXetNghiemP",
                table: "DanhmucNhomXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucLoaiXNPatientCareId",
                table: "DanhmucNhomXNPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "DanhmucMenuXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MenuCode",
                table: "DanhmucMenuXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiXetNghiemP",
                table: "DanhmucLoaiXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MaLoaiXetNghiemP",
                table: "DanhmucLoaiXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucMenuXNPatientCareId",
                table: "DanhmucLoaiXNPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoaiNguoiThan",
                table: "DanhmucLoainguoithan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TenGoiXetNghiemP",
                table: "DanhmucGoiXNTheobenhPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MaGoiXetNghiemP",
                table: "DanhmucGoiXNTheobenhPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucDichvuPatientCareId",
                table: "DanhmucGoiXNTheobenhPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDonViDoP",
                table: "DanhmucDonvidoPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "MaDonViDoP",
                table: "DanhmucDonvidoPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "TenDichVuXetNghiemP",
                table: "DanhmucDichvuXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "MaDichVuXetNghiemP",
                table: "DanhmucDichvuXNPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucNhomXNPatientCareId",
                table: "DanhmucDichvuXNPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenHienThiDichVuP",
                table: "DanhmucDichvuPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TenDichVuP",
                table: "DanhmucDichvuPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MaDichVuP",
                table: "DanhmucDichvuPatientCare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucDichvuXNPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanhmucGoiXNTheobenhPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucThongTinNguoiThan",
                table: "DanhMucThongTinNguoiThan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucThongtinKhachhang",
                table: "DanhmucThongtinKhachhang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucThongsoXNPatientCare",
                table: "DanhmucThongsoXNPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucThongsoXNDichvuPatientCare",
                table: "DanhmucThongsoXNDichvuPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucNhomXNPatientCare",
                table: "DanhmucNhomXNPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucMenuXNPatientCare",
                table: "DanhmucMenuXNPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucLoaiXNPatientCare",
                table: "DanhmucLoaiXNPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucLoainguoithan",
                table: "DanhmucLoainguoithan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucGoiXNTheobenhPatientCare",
                table: "DanhmucGoiXNTheobenhPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucDonvidoPatientCare",
                table: "DanhmucDonvidoPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucDichvuXNPatientCare",
                table: "DanhmucDichvuXNPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucDichvuPatientCare",
                table: "DanhmucDichvuPatientCare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhmucChitietGoiDVXNPatientCare",
                table: "DanhmucChitietGoiDVXNPatientCare",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThongTinNguoiThan_DanhmucLoainguoithanId",
                table: "DanhMucThongTinNguoiThan",
                column: "DanhmucLoainguoithanId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThongTinNguoiThan_DanhmucPhuongxaId",
                table: "DanhMucThongTinNguoiThan",
                column: "DanhmucPhuongxaId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucThongTinNguoiThan_DanhmucThongtinKhachhangId",
                table: "DanhMucThongTinNguoiThan",
                column: "DanhmucThongtinKhachhangId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongtinKhachhang_DanhmucPhuongphapsinhId",
                table: "DanhmucThongtinKhachhang",
                column: "DanhmucPhuongphapsinhId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongtinKhachhang_DanhmucPhuongxaId",
                table: "DanhmucThongtinKhachhang",
                column: "DanhmucPhuongxaId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                column: "DanhmucDichvuXNPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCare_DanhmucDonvidoPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                column: "DanhmucDonvidoPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucThongsoXNDichvuPatientCare_DanhmucThongsoXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                column: "DanhmucThongsoXNPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucNhomXNPatientCare_DanhmucLoaiXNPatientCareId",
                table: "DanhmucNhomXNPatientCare",
                column: "DanhmucLoaiXNPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucLoaiXNPatientCare_DanhmucMenuXNPatientCareId",
                table: "DanhmucLoaiXNPatientCare",
                column: "DanhmucMenuXNPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucGoiXNTheobenhPatientCare_DanhmucDichvuPatientCareId",
                table: "DanhmucGoiXNTheobenhPatientCare",
                column: "DanhmucDichvuPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucDichvuXNPatientCare_DanhmucNhomXNPatientCareId",
                table: "DanhmucDichvuXNPatientCare",
                column: "DanhmucNhomXNPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                column: "DanhmucDichvuXNPatientCareId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhmucChitietGoiDVXNPatientCare_DanhmucGoiXNTheobenhPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                column: "DanhmucGoiXNTheobenhPatientCareId");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuPatientCare_DanhmucDichvuPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                column: "DanhmucDichvuPatientCareId",
                principalTable: "DanhmucDichvuPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCare_DanhmucDichvuXNPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                column: "DanhmucDichvuXNPatientCareId",
                principalTable: "DanhmucDichvuXNPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucChitietGoiDVXNPatientCare_DanhmucGoiXNTheobenhPatientCare_DanhmucGoiXNTheobenhPatientCareId",
                table: "DanhmucChitietGoiDVXNPatientCare",
                column: "DanhmucGoiXNTheobenhPatientCareId",
                principalTable: "DanhmucGoiXNTheobenhPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucDichvuXNPatientCare_DanhmucNhomXNPatientCare_DanhmucNhomXNPatientCareId",
                table: "DanhmucDichvuXNPatientCare",
                column: "DanhmucNhomXNPatientCareId",
                principalTable: "DanhmucNhomXNPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucGoiXNTheobenhPatientCare_DanhmucDichvuPatientCare_DanhmucDichvuPatientCareId",
                table: "DanhmucGoiXNTheobenhPatientCare",
                column: "DanhmucDichvuPatientCareId",
                principalTable: "DanhmucDichvuPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucLoaiXNPatientCare_DanhmucMenuXNPatientCare_DanhmucMenuXNPatientCareId",
                table: "DanhmucLoaiXNPatientCare",
                column: "DanhmucMenuXNPatientCareId",
                principalTable: "DanhmucMenuXNPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucNhomXNPatientCare_DanhmucLoaiXNPatientCare_DanhmucLoaiXNPatientCareId",
                table: "DanhmucNhomXNPatientCare",
                column: "DanhmucLoaiXNPatientCareId",
                principalTable: "DanhmucLoaiXNPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhieuSangLoc_DanhmucThongtinKhachhang_DanhmucThongtinKhachhangId",
                table: "DanhMucPhieuSangLoc",
                column: "DanhmucThongtinKhachhangId",
                principalTable: "DanhmucThongtinKhachhang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCare_DanhmucDichvuXNPatientCare_DanhmucDichvuXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                column: "DanhmucDichvuXNPatientCareId",
                principalTable: "DanhmucDichvuXNPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCare_DanhmucDonvidoPatientCare_DanhmucDonvidoPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                column: "DanhmucDonvidoPatientCareId",
                principalTable: "DanhmucDonvidoPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNDichvuPatientCare_DanhmucThongsoXNPatientCare_DanhmucThongsoXNPatientCareId",
                table: "DanhmucThongsoXNDichvuPatientCare",
                column: "DanhmucThongsoXNPatientCareId",
                principalTable: "DanhmucThongsoXNPatientCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongsoXNPatientCare_DanhmucTrungtams_DanhmucTrungtamId",
                table: "DanhmucThongsoXNPatientCare",
                column: "DanhmucTrungtamId",
                principalTable: "DanhmucTrungtams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongtinKhachhang_DanhmucPhuongphapsinh_DanhmucPhuongphapsinhId",
                table: "DanhmucThongtinKhachhang",
                column: "DanhmucPhuongphapsinhId",
                principalTable: "DanhmucPhuongphapsinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhmucThongtinKhachhang_DanhmucPhuongxas_DanhmucPhuongxaId",
                table: "DanhmucThongtinKhachhang",
                column: "DanhmucPhuongxaId",
                principalTable: "DanhmucPhuongxas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThongTinNguoiThan_DanhmucLoainguoithan_DanhmucLoainguoithanId",
                table: "DanhMucThongTinNguoiThan",
                column: "DanhmucLoainguoithanId",
                principalTable: "DanhmucLoainguoithan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThongTinNguoiThan_DanhmucPhuongxas_DanhmucPhuongxaId",
                table: "DanhMucThongTinNguoiThan",
                column: "DanhmucPhuongxaId",
                principalTable: "DanhmucPhuongxas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucThongTinNguoiThan_DanhmucThongtinKhachhang_DanhmucThongtinKhachhangId",
                table: "DanhMucThongTinNguoiThan",
                column: "DanhmucThongtinKhachhangId",
                principalTable: "DanhmucThongtinKhachhang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
