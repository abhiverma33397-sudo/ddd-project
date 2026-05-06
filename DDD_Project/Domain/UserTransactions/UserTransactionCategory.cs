using Domain.Transactions.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Transactions
{
    public class UserTransactionCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TransactionEnum Type { get; set; }
    }
}