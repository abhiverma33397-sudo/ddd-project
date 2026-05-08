using Data.DataContexts;
using Domain.UserCategories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositries.TransactionRepostries.CategoryRepostries
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;


        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(TransactionCategory category)
        {

            await _context.TransactionCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TransactionCategory>> GetAll()
        {
            return await _context.TransactionCategories.ToListAsync();
        }

        public async Task<TransactionCategory> GetById(int id)
        {
            return await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(TransactionCategory category)
        {
            _context.TransactionCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                _context.TransactionCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
