using BSynchro.BAL.Commands;
using BSynchro.BAL.Events;
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
        private readonly IPublisher _publisher;
        public OpenNewAccountHandler(IPublisher publisher,IMongoClient mongoClient, IDatabaseSettings databaseSettings)
        {
            _database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _publisher = publisher;
        }

        public async Task<OpenNewAccountOutput> Handle(OpenNewAccountCommand request, CancellationToken cancellationToken)
        {
            var customerColleciton = _database.GetCollection<Customer>(DatabaseCollections.Customers);
            var cursor = await customerColleciton.FindAsync(f => f.Id == request.Input.CustomerId);
            var customer = cursor.FirstOrDefault();
            if (customer != null)
            {
                await _publisher.Publish(new AddNewAccountEvent
                {
                    Customer = customer,
                    InitialCredit = request.Input.InitialCredit,
                    AccountName = request.Input.AccountName,
                });

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
    }
}
