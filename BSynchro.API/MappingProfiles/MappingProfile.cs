using AutoMapper;
using BSynchro.Common.Models.Account;
using BSynchro.DAL.Entities;

namespace BSynchro.API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionModel>();
            CreateMap<Customer, CustomerListOutput>()
                .ForMember(des => des.Balance, opt => opt.MapFrom(scr => scr.Accounts.Sum(s => s.Balance)))
                .ForMember(des => des.Transactions, opt => opt.MapFrom(scr => scr.Accounts.SelectMany(s => s.FromAccountTransactions)
                                                                              .Union(scr.Accounts.SelectMany(s => s.ToAccountTransactions))));
        }
    }
}
