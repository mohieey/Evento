using AutoMapper;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configuration
{
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                c =>
                {
                    c.CreateMap<ApplicationIdentityUser, LoginViewModel>().ReverseMap();
                    c.CreateMap<ApplicationIdentityUser, RegisterViewModel>().ReverseMap();
                    
                    
                    //map all view models with their respectful models
                    c.CreateMap<Order, OrderViewModel>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}
