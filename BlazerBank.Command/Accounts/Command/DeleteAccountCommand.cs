using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Accounts.Command
{
    public class DeleteAccountCommand : IRequest<List<Account>>
    {
        public Account account { get; set; } = null!;

        public DeleteAccountCommand(int id)
        {
            this.account = new Account();
            account.AccountNumber = id;
        }
    }
}
