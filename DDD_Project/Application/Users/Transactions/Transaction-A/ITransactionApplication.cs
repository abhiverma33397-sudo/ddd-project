using Application.Users.Transactions.TransactionDtos;

namespace Application.Users.TransactionDtos.Transaction_A
{
    public interface ITransactionApplication
    {
        Task<string> Create(CreateUpdateTransactionDto dto, string userId);
        Task<List<GetTransactionDto>> GetAll(int userId);
        Task<GetTransactionDto> GetById(int id);
        Task<CreateDashboardDto> GetUserDashboard(string userId, CancellationToken cancellationToken);
        Task Update(int id, CreateUpdateTransactionDto transaction);
        Task Delete(int id);

    }
}
