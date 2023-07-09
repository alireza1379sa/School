using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Core.Migrations
{
    /// <inheritdoc />
    public partial class secondchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldOfStudy",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "Students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_User_id",
                table: "Teachers",
                column: "User_id",
                unique: true,
                filter: "[User_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_User_id",
                table: "Students",
                column: "User_id",
                unique: true,
                filter: "[User_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User_User_id",
                table: "Students",
                column: "User_id",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_User_User_id",
                table: "Teachers",
                column: "User_id",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_User_User_id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_User_User_id",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_User_id",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_User_id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "FieldOfStudy",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
