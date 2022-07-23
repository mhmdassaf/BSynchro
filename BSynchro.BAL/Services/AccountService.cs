using BSynchro.BAL.Interfaces;
using BSynchro.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Services
{
    public class AccountService : IAccountService
    {
        private readonly BSynchroDBContext _dBContext;
        public AccountService(BSynchroDBContext dBContext)
        {
            _dBContext = dBContext;
        }
    }
}
