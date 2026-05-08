using Application.Users.Transactions.CategoriesDtos;

namespace Application.Users.Transactions.TransactionDtos
{
    public class GetTransactionDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        public GetCategoryDto Category { get; set; }


    }
}
