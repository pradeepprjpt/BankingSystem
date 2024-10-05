using AutoMapper;
using BankingSystem.Dtos;
using BankingSystem.Entities;

namespace BankingSystem.Mapper
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountDto>().
                ForMember(dest => dest.AccountType,
                opt => opt.MapFrom(src => src.AccountType.ToString()));
        }
    }
}
