using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;

namespace NLayer.Service.AutoMapper.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            /* ForMember metodu ile güncelleme tarihi dinamik olarak yönetiyorum. */

            CreateMap<Order, OrderUpdateDto>();
            CreateMap<OrderUpdateDto, Order>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
