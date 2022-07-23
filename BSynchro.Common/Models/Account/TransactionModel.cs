using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Common.Models.Account
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Guid FromCustomerId { get; set; }
        public Guid ToCustomerId { get; set; }
        public Guid? FromAccountId { get; set; }
        public Guid? ToAccountId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
