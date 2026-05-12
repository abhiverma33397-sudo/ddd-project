using Application.Users.Transactions.TransactionDtos;
using AutoMapper;
using Data.DataContexts;
using Data.Repositries.TransactionRepostries;
using Domain.Transactions;
using Domain.Transactions.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.TransactionDtos.Transaction_A
{
    public class TransactionApplication : ITransactionApplication
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly ApplicationDbContext _context;
        public TransactionApplication(ITransactionRepo transactionRepo, IMapper mapper, IHttpContextAccessor httpAccessor, ApplicationDbContext context)
        {
            _transactionRepo = transactionRepo;
            _mapper = mapper;
            _httpAccessor = httpAccessor;
            _context = context;
        }

        public async Task<string> Create(CreateUpdateTransactionDto dto, string userId)
        {
            UserTransaction transaction = _mapper.Map<UserTransaction>(dto);
            transaction.CreatedBy = Convert.ToInt32(userId);

            await _transactionRepo.Create(transaction);
            return "Transaction created successfully.";
        }



        public async Task<List<GetTransactionDto>> GetAll(int userId)
        {
            var user = _httpAccessor.HttpContext.User
                .FindFirst("UserId");

            var transactions = await _transactionRepo.GetAll(userId);

            var result = _mapper.Map<List<GetTransactionDto>>(transactions);

            return result;
        }

        public async Task<GetTransactionDto> GetById(int id)
        {
            var transaction = await _transactionRepo.GetById(id);

            if (transaction == null)
                return null;

            var result = _mapper.Map<GetTransactionDto>(transaction);

            return result;
        }
        public async Task<CreateDashboardDto> GetUserDashboard(
       string userId,
       CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(userId);

            var transactions = await _context.Transactions
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CreatedBy == id)
                .ToListAsync(cancellationToken);

            var totalExpense = transactions
                .Where(x => x.Category.Type == TransactionEnum.Expense)
                .Sum(x => x.Amount);

            var totalIncome = transactions
                .Where(x => x.Category.Type == TransactionEnum.Income)
                .Sum(x => x.Amount);

            var balance = totalIncome - totalExpense;

            return new CreateDashboardDto
            {
                TotalExpense = totalExpense,
                TotalIncome = totalIncome,
                Balance = balance,
                TotalBalance = balance
            };
        }

        public async Task Update(int id, CreateUpdateTransactionDto dto)
        {
            var transaction = await _transactionRepo.GetById(id);
            if (transaction == null)
            {
                throw new Exception("User not found");
            }
            _mapper.Map(dto, transaction);
            await _transactionRepo.Update(transaction);
        }


        public async Task Delete(int id)
        {
            var user = await _transactionRepo.GetById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            await _transactionRepo.DeleteById(id);
        }
    }
}
