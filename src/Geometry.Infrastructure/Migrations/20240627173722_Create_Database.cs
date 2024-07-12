using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geometry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "triangles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    side_a = table.Column<double>(type: "double precision", nullable: false),
                    side_b = table.Column<double>(type: "double precision", nullable: false),
                    side_c = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_triangles", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "triangles");
        }
    }
}
