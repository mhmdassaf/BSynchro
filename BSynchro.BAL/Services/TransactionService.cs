using BSynchro.BAL.Interfaces;
using BSynchro.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BSynchroDBContext _dBContext;
        public TransactionService(BSynchroDBContext dBContext)
        {
            _dBContext = dBContext;
        }
    }
}
