using AuthService.Application.DTOs;
using AuthService.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Mappers
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest=>dest.Roles, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles.Select(r => r.Name).ToArray()));

            CreateMap<SignUpDTO, User>();
        }
    }
}
