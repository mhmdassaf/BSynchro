using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.DAL.Entities
{
    public class Account
    {
        public string Number { get; set; }
        public double OpeningBalance { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public string[] FromAccountTransactions { get; set; }
        public string[] ToAccountTransactions { get; set; }
    }
}
