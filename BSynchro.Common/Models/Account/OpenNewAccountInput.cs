using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Common.Models.Account
{
    public class OpenNewAccountInput
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? CustomerId { get; set; }

        [Required]
        public string AccountName { get; set; } = string.Empty;

        [Required]
        public double InitialCredit { get; set; }
    }
}
