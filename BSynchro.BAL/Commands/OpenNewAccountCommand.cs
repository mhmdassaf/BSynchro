using BSynchro.Common.Models.Account;
using BSynchro.DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.BAL.Commands
{
    public class OpenNewAccountCommand : IRequest<OpenNewAccountOutput>
    {
        public OpenNewAccountInput Input { get;}
        public OpenNewAccountCommand(OpenNewAccountInput input)
        {
            Input = input;
        }
    }
}
