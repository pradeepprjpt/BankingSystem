using AutoMapper;
using BankingSystem.Dtos;
using BankingSystem.Entities;

namespace BankingSystem.Mapper
{
    public class TransactionMappingProfile:Profile
    {
        public TransactionMappingProfile() {
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.TransactionType,
                opt => opt.MapFrom(src => src.TransactionType.ToString()));
        }
    }
}
