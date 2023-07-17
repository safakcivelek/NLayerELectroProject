using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Web.Areas.Admin.Models;

namespace NLayer.Web.AutoMapper.MappingProfiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ProductAddViewModel, ProductAddDto>();
            CreateMap<ProductUpdateDto, ProductUpdateViewModel>().ReverseMap();
        }
    }
}
