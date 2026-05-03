using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtpVerifies_Users_UserId1",
                table: "OtpVerifies");

            migrationBuilder.DropIndex(
                name: "IX_OtpVerifies_UserId1",
                table: "OtpVerifies");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "OtpVerifies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OtpVerifies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerifies_UserId",
                table: "OtpVerifies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtpVerifies_Users_UserId",
                table: "OtpVerifies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtpVerifies_Users_UserId",
                table: "OtpVerifies");

            migrationBuilder.DropIndex(
                name: "IX_OtpVerifies_UserId",
                table: "OtpVerifies");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OtpVerifies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
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
    }
}
