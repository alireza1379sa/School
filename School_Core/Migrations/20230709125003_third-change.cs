using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Core.Migrations
{
    /// <inheritdoc />
    public partial class thirdchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_User_User_id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_User_User_id",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Major",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTitle_id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTitle", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTitle_id",
                table: "Users",
                column: "UserTitle_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_User_id",
                table: "Students",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_User_id",
                table: "Teachers",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTitle_UserTitle_id",
                table: "Users",
                column: "UserTitle_id",
                principalTable: "UserTitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_User_id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_User_id",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTitle_UserTitle_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTitle_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTitle_id",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Major",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

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
    }
}
