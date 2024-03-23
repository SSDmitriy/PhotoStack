using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoStack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class move_image_to_photocard_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PhotoCards");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PhotoCards",
                type: "numeric",
                nullable: false,
                defaultValue: 0.01m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldDefaultValue: 0.1m);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "PhotoCards",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "PhotoCards");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PhotoCards",
                type: "numeric",
                nullable: false,
                defaultValue: 0.1m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldDefaultValue: 0.01m);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "PhotoCards",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    PhotoCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.PhotoCardId);
                    table.ForeignKey(
                        name: "FK_Images_PhotoCards_PhotoCardId",
                        column: x => x.PhotoCardId,
                        principalTable: "PhotoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
