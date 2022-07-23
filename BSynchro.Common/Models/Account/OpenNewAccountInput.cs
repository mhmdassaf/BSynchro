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
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string AccountName { get; set; } = string.Empty;

        [Required]
        public double InitialCredit { get; set; }
    }
}
