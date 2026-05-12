using Domain.Transactions;

namespace Data.Repositries.TransactionRepostries
{
    public interface ITransactionRepo
    {
        Task Create(UserTransaction transaction);
        Task<List<UserTransaction>> GetAll(int userId);
        Task<UserTransaction> GetById(int id);
        Task Update(UserTransaction transaction);

        Task DeleteById(int id);
      


    }
}
