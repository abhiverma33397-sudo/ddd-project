using Application.UserDtos;
using AutoMapper;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class Mapping:Profile
    {
        public Mapping() {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User,GetUserDto>();

            
        }
    }
}
