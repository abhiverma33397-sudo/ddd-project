using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Transactions.TransactionDtos
{
    public class CreateDashboardDto
    {
        public decimal TotalExpense { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal Balance { get; set; }
    }
}
