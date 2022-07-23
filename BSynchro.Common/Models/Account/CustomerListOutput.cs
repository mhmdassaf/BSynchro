using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Common.Models.Account
{
    public class CustomerListOutput
    {
        public CustomerListOutput()
        {
            Transactions = new List<TransactionModel>();
        }

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double Balance { get; set; }
        public IEnumerable<TransactionModel> Transactions { get; set; }
    }
}
