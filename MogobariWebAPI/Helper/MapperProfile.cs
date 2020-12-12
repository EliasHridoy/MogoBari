using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MogobariWebAPI.Models;
using MogobariWebAPI.Models.ViewModels;

namespace MogobariWebAPI.Helper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductWithImageFile,Product>();
            CreateMap<CustomerRegisterViewModel, Customer>();
            CreateMap<Customer, CustomerWithToken>();
            
        }
    }
}
