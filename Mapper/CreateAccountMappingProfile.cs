using AutoMapper;
using BankingSystem.Dtos;
using BankingSystem.Entities;

namespace BankingSystem.Mapper
{
    public class CreateAccountMappingProfile : Profile
    {
        public CreateAccountMappingProfile() {
            CreateMap<CreateAccountDto, Customer>();
            CreateMap<CreateAccountDto, Account>();
        }
    }
}
