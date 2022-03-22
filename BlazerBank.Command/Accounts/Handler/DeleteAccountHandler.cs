using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Command.Accounts.Command;

namespace BlazerBank.Command.Accounts.Handler
{
    public class DeleteAccountHandler:IRequestHandler<DeleteAccountCommand, List<Account>>
    {
        private readonly AccountRepository repository;

        public DeleteAccountHandler(AccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Account>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var response =  await repository.DeleteAsync(c => c.AccountNumber == request.account.AccountNumber);
            return response == null ? throw new Exception("Account not found") : response;
        }
    }
}
