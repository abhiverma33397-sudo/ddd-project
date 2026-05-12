

using Data.DataContexts;
using Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositries.TransactionRepostries
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(UserTransaction transaction)
        {
             await _context.Transactions.AddAsync(transaction);
            
             await _context.SaveChangesAsync();
        }

        public async Task<List<UserTransaction>> GetAll(int userId)
        {
            return await _context.Transactions
                .Where(x => x.CreatedBy == userId) 
                .Include(x => x.Category)
                .ToListAsync(); 
        }

        public async Task<UserTransaction> GetById(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(UserTransaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

      
    }
}
