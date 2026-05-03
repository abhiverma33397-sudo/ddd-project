using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtpVerifies_Users_UserId",
                table: "OtpVerifies");

            migrationBuilder.DropTable(
                name: "ChangePasswords");

            migrationBuilder.DropTable(
                name: "ForgetPasswords");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_OtpVerifies_UserId",
                table: "OtpVerifies");

            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Otp",
                table: "OtpVerifies",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "OtpVerifies",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OtpVerifies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OtpCode",
                table: "OtpVerifies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerifies_UserId1",
                table: "OtpVerifies",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OtpVerifies_Users_UserId1",
                table: "OtpVerifies",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtpVerifies_Users_UserId1",
                table: "OtpVerifies");

            migrationBuilder.DropIndex(
                name: "IX_OtpVerifies_UserId1",
                table: "OtpVerifies");

            migrationBuilder.DropColumn(
                name: "OtpCode",
                table: "OtpVerifies");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "EmailId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "OtpVerifies",
                newName: "EmailId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "OtpVerifies",
                newName: "Otp");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OtpVerifies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ChangePasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangePasswords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForgetPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgetPasswords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerifies_UserId",
                table: "OtpVerifies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtpVerifies_Users_UserId",
                table: "OtpVerifies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
