using MediatR;
using BlazerBank.Command.Transactions.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;

namespace BlazerBank.Command.Transactions.Handler
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, List<Transaction>>
    {
        private readonly TransactionRepository repository;

        public CreateTransactionHandler(TransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Transaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.transaction);
        }
    }
}
