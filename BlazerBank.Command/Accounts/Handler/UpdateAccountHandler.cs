using MediatR;
using BlazerBank.Command.Accounts.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;

namespace BlazerBank.Command.Accounts.Handler
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, Account>
    {
        private readonly AccountRepository repository;

        public UpdateAccountHandler(AccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Account> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var response = await repository.Update(request.account);
            return response == null ? throw new Exception("Account not found") : response;
        }
    }
}
