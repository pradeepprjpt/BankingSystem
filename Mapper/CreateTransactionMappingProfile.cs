using AutoMapper;
using BankingSystem.Dtos;
using System.Transactions;

namespace BankingSystem.Mapper
{
    public class CreateTransactionMappingProfile:Profile
    {
        public CreateTransactionMappingProfile() {
            CreateMap<CreateTransactionDto, Transaction>();
        }
    }
}
