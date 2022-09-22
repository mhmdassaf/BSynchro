using BSynchro.BAL.Handlers.Base;
using BSynchro.BAL.Queries;
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
    public class CustomerListHandler : BaseHandler, IRequestHandler<CustomerListQuery, List<CustomerListOutput>>
    {
        private readonly IMongoDatabase _database;
        public CustomerListHandler(IMongoClient mongoClient, IDatabaseSettings databaseSettings)
        {
            _database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        }

        public async Task<List<CustomerListOutput>> Handle(CustomerListQuery request, CancellationToken cancellationToken)
        {
            var customerCollection = _database.GetCollection<Customer>(DatabaseCollections.Customers);
            var transactionCollection = _database.GetCollection<Transaction>(DatabaseCollections.Transactions);
            var cursor = await transactionCollection.FindAsync(f => true);
            var trans = cursor.ToList();

            var projection = Builders<Customer>.Projection.Expression(u =>
                                     new CustomerListOutput
                                     {
                                         Id = u.Id,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         Balance = u.Accounts.Sum(s => s.Balance),
                                         Transactions = trans.Where(t => t.FromCustomer != null && t.FromCustomer.Id == u.Id ||
                                                                         t.ToCustomer != null && t.ToCustomer.Id == u.Id)
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
    }
}
