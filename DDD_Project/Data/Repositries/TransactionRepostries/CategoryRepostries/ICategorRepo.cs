using Domain.UserCategories;

namespace Data.Repositries.TransactionRepostries.CategoryRepostries
{
    public interface ICategoryRepo
    {
        Task Create(TransactionCategory category);
        Task<List<TransactionCategory>> GetAll();
        Task<TransactionCategory> GetById(int id);
        Task Update(TransactionCategory category);
        Task Delete(int id);
    }
}
