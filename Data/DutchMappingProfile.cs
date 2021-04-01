using AutoMapper;
using OnlineShoePortal_ECommerce.Data.Entities;
using OnlineShoePortal_ECommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_ECommerce.Data
{
    public class ShoeMappingProfile : Profile
    {
        public ShoeMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id));
        }
    }
}
