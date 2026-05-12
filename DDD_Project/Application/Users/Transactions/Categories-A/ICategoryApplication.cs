using Application.Users.Transactions.CategoriesDtos;

namespace Application.Users.Transactions.Categories_A
{
    public interface ICategoryApplication
    {
        Task Create(CreateUpdateCategoryDto dto, string userId);
        Task<List<GetCategoryDto>> GetAll();
        Task<GetCategoryDto> GetById(int id);
        Task Update(int id, CreateUpdateCategoryDto dto);
        Task Delete(int id);
    }
}
