using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Core.Migrations
{
    /// <inheritdoc />
    public partial class firstchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_Teacher_id",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "Teacher_id",
                table: "Classes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_Teacher_id",
                table: "Classes",
                column: "Teacher_id",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_Teacher_id",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "Teacher_id",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_Teacher_id",
                table: "Classes",
                column: "Teacher_id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
