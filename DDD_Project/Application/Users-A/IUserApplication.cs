using Application.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public interface IUserApplication
    {
        Task <string> Create(CreateUpdateDto dto);
        Task<List<GetUserDto>> GetAll();
        Task<GetUserDto> GetById(int id);
        Task Update(int id, CreateUpdateDto dto);
        Task Delete(int id);
    }
}
