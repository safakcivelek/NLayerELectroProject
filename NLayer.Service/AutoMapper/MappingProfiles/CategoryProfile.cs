using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;

namespace NLayer.Service.AutoMapper.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // ForMember metodu ile güncelleme tarihi dinamik olarak yönetiyorum.

            CreateMap<CategoryAddDto, Category>().ForMember(c => c.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>().ForMember(c => c.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Category, CategoryUpdateDto>();           
        }
    }
}
