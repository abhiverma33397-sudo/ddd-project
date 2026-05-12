using Domain.Transactions.Enums;
using Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.UserCategories
{
    public class TransactionCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public User User { get; set; }

        public TransactionEnum Type { get; set; }
    }
}