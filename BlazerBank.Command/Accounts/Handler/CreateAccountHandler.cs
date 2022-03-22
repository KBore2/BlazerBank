using MediatR;
using BlazerBank.Command.Accounts.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;

namespace BlazerBank.Command.Accounts.Handler
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, List<Account>>
    {
        private readonly AccountRepository repository;

        public CreateAccountHandler(AccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Account>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.account);
        }
    }
}
