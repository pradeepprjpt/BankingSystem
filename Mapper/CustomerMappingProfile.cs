using AutoMapper;
using BankingSystem.Dtos;
using BankingSystem.Entities;

namespace BankingSystem.Mapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
