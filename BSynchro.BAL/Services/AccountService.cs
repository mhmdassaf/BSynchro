using AutoMapper;
using BSynchro.BAL.Interfaces;
using BSynchro.Common.Constants;
using BSynchro.Common.Models;
using BSynchro.Common.Models.Account;
using BSynchro.Common.Models.Settings;
using BSynchro.DAL.DataContext;
using BSynchro.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMongoDatabase _dBContext;
        private readonly IMapper _mapper;
        public AccountService(IMongoClient mongoClient,IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _dBContext = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
        }

        public async Task<List<CustomerListOutput>> CustomerList()
        {
            var customerCollection = _dBContext.GetCollection<Customer>(DatabaseCollections.Customers);
            var transactionCollection = _dBContext.GetCollection<Transaction>(DatabaseCollections.Transactions);
            var cursor = await transactionCollection.FindAsync(f => true);
            var trans = cursor.ToList();

            var projection = Builders<Customer>.Projection.Expression(u =>
                                     new CustomerListOutput
                                     {
                                         Id = u.Id,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         Balance = u.Accounts.Sum(s => s.Balance),
                                         Transactions = trans.Where(t => (t.FromCustomer != null && t.FromCustomer.Id == u.Id) || 
                                                                         ( t.ToCustomer != null && t.ToCustomer.Id == u.Id))
                                                             .Select(t => new TransactionModel
                                                             {
                                                                 FromCustomerId = t.FromCustomer != null ? t.FromCustomer.Id : null,
                                                                 ToCustomerId = t.ToCustomer != null ? t.ToCustomer.Id : null,
                                                                 Amount = t.Amount,
                                                                 CreatedDate = t.CreatedDate,
                                                                 Id = t.Id,
                                                             })
                                     });

            var customerListOutputs = customerCollection.Aggregate().Project(projection).ToList();

            return customerListOutputs;

        }
        public async Task<OpenNewAccountOutput> OpenNewAccount(OpenNewAccountInput input)
        {
            var customerColleciton = _dBContext.GetCollection<Customer>(DatabaseCollections.Customers);
            var cursor  = await customerColleciton.FindAsync(f => f.Id == input.CustomerId);
            var customer = cursor.FirstOrDefault();
            if (customer != null)
            {
                var newAccount = new Account
                {
                    OpeningBalance = input.InitialCredit,
                    Balance = input.InitialCredit,
                    CreatedBy = customer.FirstName + " " + customer.LastName,
                    CreatedDate = DateTime.Now,
                    Description = "Current account",
                    Name = input.AccountName,
                    Number = await GenerateAccountNb()
                };

                if (input.InitialCredit > 0)
                {
                    var newTrans = new Transaction
                    {
                        Amount = input.InitialCredit,
                        CreatedBy = customer.FirstName + " " + customer.LastName,
                        CreatedDate = DateTime.Now,
                        ToCustomer = new CustomerModel {Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName },
                    };
                    _dBContext.GetCollection<Transaction>(DatabaseCollections.Transactions).InsertOne(newTrans);
                    newAccount.ToAccountTransactions = new string[] { newTrans.Id };
                }
                   
                customer.Accounts.Add(newAccount);

                var result = customerColleciton.ReplaceOne(f => f.Id == customer.Id, customer);
             
                if (result.IsAcknowledged)
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
            //while (true)
            //{
            //    string accountNb = new Random().NextInt64(100000000000, 999999999999).ToString();
            //    if (!await _dBContext.Accounts.AnyAsync(w => w.Number == accountNb))
            //        return accountNb;
            //}
            return null;
        }
        #endregion
    }
}
