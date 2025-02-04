using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cental.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class SocialMediaMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagerUrl",
                table: "AspNetUsers",
                newName: "ImageUrl");

            migrationBuilder.CreateTable(
                name: "MSocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MSocialMedias_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MSocialMedias_UserId",
                table: "MSocialMedias",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSocialMedias");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "AspNetUsers",
                newName: "ImagerUrl");
        }
    }
}
