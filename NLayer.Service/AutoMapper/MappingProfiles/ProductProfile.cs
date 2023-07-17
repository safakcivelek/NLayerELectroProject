using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;

namespace NLayer.Service.AutoMapper.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            /* ForMember metodu ile güncelleme tarihi dinamik olarak yönetiyorum. */
            CreateMap<ProductAddDto, Product>().ForMember(c => c.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductUpdateDto, Product>().ForMember(c => c.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Product, ProductUpdateDto>();
        }
    }
}
