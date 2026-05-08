using Domain.Transactions.Enums;

namespace Application.Users.Transactions.CategoriesDtos
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TransactionEnum Type { get; set; }
    }
}
