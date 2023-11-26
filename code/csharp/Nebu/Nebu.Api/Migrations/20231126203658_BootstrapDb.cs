using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebu.Api.Migrations
{
    /// <inheritdoc />
    public partial class BootstrapDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ApiKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buckets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Uri = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buckets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buckets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BucketId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<Guid>(type: "uuid", nullable: false),
                    Filename = table.Column<string>(type: "text", nullable: false),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blobs_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalTable: "Buckets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blobs_BucketId_Key",
                table: "Blobs",
                columns: new[] { "BucketId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buckets_UserId",
                table: "Buckets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApiKey",
                table: "Users",
                column: "ApiKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blobs");

            migrationBuilder.DropTable(
                name: "Buckets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
