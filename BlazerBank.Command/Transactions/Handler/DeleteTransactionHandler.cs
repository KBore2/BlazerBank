using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Command.Accounts.Command;
using BlazerBank.Command.Transactions.Command;

namespace BlazerBank.Command.Transactions.Handler
{
    public class DeleteTransactionHandler:IRequestHandler<DeleteTransactionCommand, List<Transaction>>
    {
        private readonly TransactionRepository repository;

        public DeleteTransactionHandler(TransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Transaction>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var response =  await repository.DeleteAsync(c => c.TransactionNumber == request.transaction.TransactionNumber);
            return response == null ? throw new Exception("Transaction not found") : response;
        }
    }
}
