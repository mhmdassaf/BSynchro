using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.DAL.Entities
{
    [BsonIgnoreExtraElements]
    public class Transaction
    {

        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifedBy { get; set; }

        public virtual CustomerModel FromCustomer { get; set; }
        public virtual CustomerModel ToCustomer { get; set; }
    }
}
