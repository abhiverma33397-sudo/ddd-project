using Domain.Transactions.Enums;
using Domain.UserCategories;
using Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Transactions
{
    public class UserTransaction
    {
        public TransactionEnum TransactionEnum;

        public int Id { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public User User { get; set; }

        [ForeignKey("Category")]
        public int TransactionCategoryId { get; set; }
        public TransactionCategory Category { get; set; }



    }
}
