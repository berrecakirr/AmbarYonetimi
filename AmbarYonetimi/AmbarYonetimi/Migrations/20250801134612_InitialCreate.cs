using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmbarYonetimi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaslikDepolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RafKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HareketTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: true),
                    IslemYapan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaslikDepolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IskeletDepolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RafKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HareketTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: true),
                    IslemYapan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IskeletDepolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KilifDepolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RafKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HareketTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: true),
                    IslemYapan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KilifDepolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KolcakDepolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RafKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HareketTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    IslemYapan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolcakDepolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malzemeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StokMiktari = table.Column<int>(type: "int", nullable: false),
                    KritikSeviye = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzemeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SungerDepolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RafKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HareketTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: true),
                    IslemYapan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SungerDepolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transferler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaynakDepo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HedefDepo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    TransferNedeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oncelik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SorumluKisi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MalzemeHareketleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeId = table.Column<int>(type: "int", nullable: false),
                    HareketTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalzemeHareketleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MalzemeHareketleri_Malzemeler_MalzemeId",
                        column: x => x.MalzemeId,
                        principalTable: "Malzemeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeHareketleri_MalzemeId",
                table: "MalzemeHareketleri",
                column: "MalzemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Password",
                table: "Users",
                column: "Password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaslikDepolar");

            migrationBuilder.DropTable(
                name: "IskeletDepolar");

            migrationBuilder.DropTable(
                name: "KilifDepolar");

            migrationBuilder.DropTable(
                name: "KolcakDepolar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "MalzemeHareketleri");

            migrationBuilder.DropTable(
                name: "SungerDepolar");

            migrationBuilder.DropTable(
                name: "Transferler");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Malzemeler");
        }
    }
}
