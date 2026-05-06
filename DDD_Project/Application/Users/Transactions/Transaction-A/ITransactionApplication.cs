using Application.Users.Transactions.TransactionDtos;

namespace Application.Users.TransactionDtos.Transaction_A
{
    public interface ITransactionApplication
    {
        Task<string> Create(CreateUpdateTransactionDto dto);
        Task<List<GetTransactionDto>> GetAll();
        Task<GetTransactionDto> GetById(int id);
        Task Update(int id,CreateUpdateTransactionDto transaction);
       Task Delete(int id);

    }
}
