using AutoMapper;
using BSynchro.BAL.Interfaces;
using BSynchro.Common.Models;
using BSynchro.Common.Models.Account;
using BSynchro.DAL.DataContext;
using BSynchro.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Services
{
    public class AccountService : IAccountService
    {
        private readonly BSynchroDBContext _dBContext;
        private readonly IMapper _mapper;
        public AccountService(BSynchroDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<List<CustomerListOutput>> CustomerList()
        {
            return await _dBContext.Customers.Include(i => i.Accounts).ThenInclude(t => t.FromAccountTransactions)
                                             .Include(i => i.Accounts).ThenInclude(t => t.ToAccountTransactions)
                                             .Select(s => _mapper.Map<CustomerListOutput>(s))
                                             .ToListAsync();
        }
        public async Task<OpenNewAccountOutput> OpenNewAccount(OpenNewAccountInput input)
        {
            var customer = await _dBContext.Customers.FindAsync(input.CustomerId);
            if(customer != null)
            {
                var newAccount = new Account
                {
                    OpeningBalance = input.InitialCredit,
                    Balance = input.InitialCredit,
                    CreatedBy = customer.FirstName + " " + customer.LastName,
                    CreatedDate = DateTime.Now,
                    CustomerId = input.CustomerId,
                    Description = "Current account",
                    Name = input.AccountName,
                    Number = await GenerateAccountNb()
                };

                if (input.InitialCredit > 0)
                    newAccount.ToAccountTransactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Amount = input.InitialCredit,
                            CreatedBy = customer.FirstName + " " + customer.LastName,
                            CreatedDate = DateTime.Now,
                            FromAccountId = null,
                            FromCustomerId = customer.Id,
                            ToCustomerId = customer.Id
                        }
                    };
                
                customer.Accounts.Add(newAccount);
                _dBContext.Customers.Update(customer);
                int res = await _dBContext.SaveChangesAsync();
                if (res > 0)
                    return new OpenNewAccountOutput { ResponseMessage = "New account is created!" };
                else
                    return new OpenNewAccountOutput { ResponseMessage = "Error on creating! try again" };
            }
            else
            {
                return new OpenNewAccountOutput
                {
                    ResponseMessage = "Wrong customer Id! customer not exist"
                };
            }
        }

        #region Extensions
        private async Task<string> GenerateAccountNb()
        {
            while (true)
            {
                string accountNb = new Random().NextInt64(100000000000, 999999999999).ToString();
                if (!await _dBContext.Accounts.AnyAsync(w => w.Number == accountNb))
                    return accountNb;
            }
        }
        #endregion
    }
}
