using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;

namespace NLayer.Service.AutoMapper.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
