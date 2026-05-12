using Application.Users.Transactions.CategoriesDtos;
using AutoMapper;
using Data.Repositries.TransactionRepostries.CategoryRepostries;
using Domain.UserCategories;

namespace Application.Users.Transactions.Categories_A
{
    public class CategoryApplication: ICategoryApplication
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryApplication(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task Create(CreateUpdateCategoryDto dto, string userId)
        {
            var category = _mapper.Map<TransactionCategory>(dto);
            category.CreatedBy = Convert.ToInt32(userId);
            await _categoryRepo.Create(category);
        }

        public async Task<List<GetCategoryDto>> GetAll()
        {
            var categories = await _categoryRepo.GetAll();
            return _mapper.Map<List<GetCategoryDto>>(categories);
        }

        public async Task<GetCategoryDto> GetById(int id)
        {
            var category = await _categoryRepo.GetById(id);
            if (category == null)
                return null;
            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task Update(int id, CreateUpdateCategoryDto dto)
        {
            var category = await _categoryRepo.GetById(id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            _mapper.Map(dto, category);
            await _categoryRepo.Update(category);
        }
        public async Task Delete(int id)
        {
            var category = await _categoryRepo.GetById(id);
            if (category != null)
            {
                await _categoryRepo.Delete(id);
            }


        }
    }
}
