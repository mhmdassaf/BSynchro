﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.DAL.Entities
{
    public class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
            FromCustomerTransactions = new HashSet<Transaction>();
            ToCustomerTransactions = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Range(1,2)]
        public int Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public DateTime BirthDate { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifedBy { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Transaction> FromCustomerTransactions { get; set; }
        public virtual ICollection<Transaction> ToCustomerTransactions { get; set; }
    }
}
