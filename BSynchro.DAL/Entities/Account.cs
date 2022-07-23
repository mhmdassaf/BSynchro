using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.DAL.Entities
{
    public class Account
    {
        public Account()
        {
            FromAccountTransactions = new HashSet<Transaction>();
            ToAccountTransactions = new HashSet<Transaction>();
        }
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Number { get; set; }
        public double OpeningBalance { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifedBy { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Transaction> FromAccountTransactions { get; set; }
        public virtual ICollection<Transaction> ToAccountTransactions { get; set; }
    }
}
