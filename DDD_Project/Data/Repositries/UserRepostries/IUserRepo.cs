using Domain.Users;

namespace Data.Repositries.UserRepo
{
    public interface IUserRepo
    {
        Task Create(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task Update(User user);
        Task Delete(User user);
    }
}
