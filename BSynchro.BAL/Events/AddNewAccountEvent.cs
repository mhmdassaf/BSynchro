using BSynchro.DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Events
{
    public class AddNewAccountEvent : INotification
    {
        public Customer Customer { get; set; }
        public double InitialCredit { get; set; }
        public string AccountName { get; set; }
    }
}
