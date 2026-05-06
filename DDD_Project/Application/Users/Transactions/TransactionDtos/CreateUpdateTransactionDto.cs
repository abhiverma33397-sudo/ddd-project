namespace Application.Users.Transactions.TransactionDtos
{
    public class CreateUpdateTransactionDto
    {
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        public int TransactionCategoryId { get; set; }
    }
}
