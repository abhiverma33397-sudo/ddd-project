using Application.Users.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public interface IUserApplication
    {
        Task <string> Create(UserCreateDto dto);
        Task<List<GetUserDto>> GetAll();
        Task<GetUserDto> GetById(int id);
        Task Update(int id, UserUpdateDto dto);
        Task Delete(int id);
    }
}
