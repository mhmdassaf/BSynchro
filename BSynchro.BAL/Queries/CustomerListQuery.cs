using BSynchro.Common.Models.Account;
using MediatR;

namespace BSynchro.BAL.Queries
{
    public class CustomerListQuery : IRequest<List<CustomerListOutput>>
    {

    }
}
