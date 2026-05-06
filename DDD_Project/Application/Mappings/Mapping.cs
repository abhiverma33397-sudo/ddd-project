
using Application.Users.Transactions.TransactionDtos;
using Application.Users.UserDtos;
using AutoMapper;
using Domain.Transactions;
using Domain.Users;

namespace Application.Mappings
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, GetUserDto>();

            CreateMap<CreateUpdateTransactionDto, UserTransaction>();
            CreateMap<UserTransaction, GetTransactionDto>();

        }
    }
}
