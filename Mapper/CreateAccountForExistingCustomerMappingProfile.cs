using AutoMapper;
using BankingSystem.Dtos;
using BankingSystem.Entities;

namespace BankingSystem.Mapper
{
    public class CreateAccountForExistingCustomerMappingProfile : Profile
    {
        public CreateAccountForExistingCustomerMappingProfile()
        {
            CreateMap<CreateAccountForExistingCustomer, Account>();
        }
    }
}
