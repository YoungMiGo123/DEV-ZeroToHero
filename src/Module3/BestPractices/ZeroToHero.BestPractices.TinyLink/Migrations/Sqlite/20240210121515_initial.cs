using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeroToHero.BestPractices.TinyLink.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TinyLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OriginalUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ShortenedUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Hash = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deactivated = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinyLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    IPAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Device = table.Column<string>(type: "TEXT", nullable: true),
                    LinkId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deactivated = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_TinyLinks_LinkId",
                        column: x => x.LinkId,
                        principalTable: "TinyLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_LinkId",
                table: "Visits",
                column: "LinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "TinyLinks");
        }
    }
}
