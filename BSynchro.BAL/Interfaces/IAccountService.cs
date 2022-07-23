using BSynchro.Common.Models;
using BSynchro.Common.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Interfaces
{
    public interface IAccountService
    {
        Task<OpenNewAccountOutput> OpenNewAccount(OpenNewAccountInput input);
        Task<List<CustomerListOutput>> CustomerList();
    }
}
