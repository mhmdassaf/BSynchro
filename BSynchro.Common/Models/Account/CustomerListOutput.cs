using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Common.Models.Account
{
    [BsonIgnoreExtraElements]
    public class CustomerListOutput
    {
        public CustomerListOutput()
        {
            Transactions = new List<TransactionModel>();
        }

        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double Balance { get; set; }
        public IEnumerable<TransactionModel> Transactions { get; set; }
    }
}
