using BSynchro.BAL.Commands;
using BSynchro.BAL.Handlers.Base;
using BSynchro.Common.Constants;
using BSynchro.Common.Models.Account;
using BSynchro.Common.Models.Settings;
using BSynchro.DAL.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Handlers
{
    public class OpenNewAccountHandler : BaseHandler, IRequestHandler<OpenNewAccountCommand, OpenNewAccountOutput>
    {
        private readonly IMongoDatabase _database;
        public OpenNewAccountHandler(IMongoClient mongoClient, IDatabaseSettings databaseSettings)
        {
            _database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        }

        public async Task<OpenNewAccountOutput> Handle(OpenNewAccountCommand request, CancellationToken cancellationToken)
        {
            var customerColleciton = _database.GetCollection<Customer>(DatabaseCollections.Customers);
            var cursor = await customerColleciton.FindAsync(f => f.Id == request.Input.CustomerId);
            var customer = cursor.FirstOrDefault();
            if (customer != null)
            {
                var newAccount = new Account
                {
                    OpeningBalance = request.Input.InitialCredit,
                    Balance = request.Input.InitialCredit,
                    CreatedBy = customer.FirstName + " " + customer.LastName,
                    CreatedDate = DateTime.Now,
                    Description = "Current account",
                    Name = request.Input.AccountName,
                    Number = await GenerateAccountNb()
                };

                if (request.Input.InitialCredit > 0)
                {
                    var newTrans = new Transaction
                    {
                        Amount = request.Input.InitialCredit,
                        CreatedBy = customer.FirstName + " " + customer.LastName,
                        CreatedDate = DateTime.Now,
                        ToCustomer = new CustomerModel { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName },
                    };
                    _database.GetCollection<Transaction>(DatabaseCollections.Transactions).InsertOne(newTrans);
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
            while (true)
            {
                string accountNb = new Random().NextInt64(100000000000, 999999999999).ToString();
                var cursor = await _database.GetCollection<Customer>(DatabaseCollections.Customers)
                                         .FindAsync(w => w.Accounts.Any(a => a.Number == accountNb));
                var customer = await cursor.FirstOrDefaultAsync();
                if (customer == null)
                    return accountNb;
            }
            return null;
        }
        #endregion
    }
}
