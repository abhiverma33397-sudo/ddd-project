using Application.Users.Transactions.TransactionDtos;
using AutoMapper;
using Data.Repositries.TransactionRepostries;
using Domain.Transactions;
using Domain.Users;

namespace Application.Users.TransactionDtos.Transaction_A
{
    public class TransactionApplication : ITransactionApplication
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IMapper _mapper;
        public TransactionApplication(ITransactionRepo transactionRepo, IMapper mapper)
        {
            _transactionRepo = transactionRepo;
            _mapper = mapper;
        }

        public async Task<string> Create(CreateUpdateTransactionDto dto)
        {
            UserTransaction transaction = _mapper.Map<UserTransaction>(dto);

            await _transactionRepo.Create(transaction);
            return "Transaction created successfully.";
        }

      

        public async Task<List<GetTransactionDto>> GetAll()
        {
            var transactions = await _transactionRepo.GetAll();
            var result = _mapper.Map<List<GetTransactionDto>>(transactions);
            return result;
        }

        public async Task<GetTransactionDto> GetById(int id)
        {
            var transaction= _transactionRepo.GetById(id);
            if (transaction == null)
                return null;
            var result=_mapper.Map<GetTransactionDto>(transaction);

            return result;
        }

        public async Task Update(int id,CreateUpdateTransactionDto dto)
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
