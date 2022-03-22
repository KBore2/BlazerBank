using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Accounts.Command
{
    public class UpdateAccountCommand : IRequest<Account>
    {
        public Account account { get; set; } = null!;

        public UpdateAccountCommand(Account Account)
        {
            this.account = Account;
        }
    }
}
