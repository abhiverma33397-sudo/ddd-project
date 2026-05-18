//using Application.Users.UserDtos;
//using Domain.Users;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Application.Users
//{
//    public interface IUserApplication
//    {
//        Task <string> Create(UserCreateDto dto);
//        Task<List<GetUserDto>> GetAll();
//        Task<GetUserDto> GetById(int id);
//        Task<string> Update(int id, UserUpdateDto dto, IFormFile? file);
//        Task Delete(int id);
//        Task <string> UploadFile(FileUpload fileUpload);
//    }
//}
using Application.Users.UserDtos;
using Domain.Users;
using Microsoft.AspNetCore.Http;

namespace Application.Users
{
    public interface IUserApplication
    {
        Task<string> Create(UserCreateDto dto);

        Task<List<GetUserDto>> GetAll();

        Task<GetUserDto> GetById(int id);

        Task<string> Update(int id, UserUpdateDto dto);

        Task Delete(int id);

        Task<string> UploadFile(FileUpload fileUpload);
    }
}