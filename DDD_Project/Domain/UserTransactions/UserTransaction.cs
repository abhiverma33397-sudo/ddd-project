using Domain.UserCategories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Transactions
{
    public class UserTransaction
    {
            
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Category")]
        public int TransactionCategoryId { get; set; }
        public TransactionCategory Category { get; set; }



    }
}
