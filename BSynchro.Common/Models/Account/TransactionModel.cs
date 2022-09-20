using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Common.Models.Account
{
    public class TransactionModel
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public string FromCustomerId { get; set; }
        public string ToCustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
