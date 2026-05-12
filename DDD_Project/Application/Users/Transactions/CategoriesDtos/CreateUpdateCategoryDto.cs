using Domain.Transactions.Enums;

namespace Application.Users.Transactions.CategoriesDtos
{
    public class CreateUpdateCategoryDto
    {
        public string Name { get; set; }
       
        public TransactionEnum Type { get; set; }
    }
}
