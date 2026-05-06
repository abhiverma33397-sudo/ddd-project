using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class transaction1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserTransactionCategory_TransactionCategoryId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionCategoryId",
                table: "Transactions",
                newName: "TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionCategoryId",
                table: "Transactions",
                newName: "IX_Transactions_TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserTransactionCategory_TransactionId",
                table: "Transactions",
                column: "TransactionId",
                principalTable: "UserTransactionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserTransactionCategory_TransactionId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "TransactionCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionId",
                table: "Transactions",
                newName: "IX_Transactions_TransactionCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserTransactionCategory_TransactionCategoryId",
                table: "Transactions",
                column: "TransactionCategoryId",
                principalTable: "UserTransactionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
