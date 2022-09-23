using BSynchro.BAL.Events;
using BSynchro.Common.Constants;
using BSynchro.Common.Models.Settings;
using BSynchro.DAL.Entities;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Handlers
{
    public class AddNewAccountEventHandler : INotificationHandler<AddNewAccountEvent>
    {
        private readonly IMongoDatabase _database;
        public AddNewAccountEventHandler(IMongoClient mongoClient, IDatabaseSettings databaseSettings)
        {
            _database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        }

        public async Task Handle(AddNewAccountEvent notification, CancellationToken cancellationToken)
        {
            var newAccount = new Account
            {
                OpeningBalance = notification.InitialCredit,
                Balance = notification.InitialCredit,
                CreatedBy = notification.Customer.FirstName + " " + notification.Customer.LastName,
                CreatedDate = DateTime.Now,
                Description = "Current account",
                Name = notification.AccountName,
                Number = await GenerateAccountNb()
            };

            if (notification.InitialCredit > 0)
            {
                var newTrans = new Transaction
                {
                    Amount = notification.InitialCredit,
                    CreatedBy = notification.Customer.FirstName + " " + notification.Customer.LastName,
                    CreatedDate = DateTime.Now,
                    ToCustomer = new CustomerModel { Id = notification.Customer.Id, FirstName = notification.Customer.FirstName, LastName = notification.Customer.LastName },
                };
                _database.GetCollection<Transaction>(DatabaseCollections.Transactions).InsertOne(newTrans);
                newAccount.ToAccountTransactions = new string[] { newTrans.Id };
            }

            notification.Customer.Accounts.Add(newAccount);
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
