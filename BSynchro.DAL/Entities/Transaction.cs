using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.DAL.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public Guid FromCustomerId { get; set; }
        public Guid ToCustomerId { get; set; }
        public Guid? FromAccountId { get; set; }
        public Guid? ToAccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifedBy { get; set; }

        public virtual Account FromAccount { get; set; }
        public virtual Account ToAccount { get; set; }
        public virtual Customer FromCustomer { get; set; }
        public virtual Customer ToCustomer { get; set; }
    }
}
