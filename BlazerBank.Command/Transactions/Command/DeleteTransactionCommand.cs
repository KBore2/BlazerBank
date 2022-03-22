using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Transactions.Command
{
    public class DeleteTransactionCommand : IRequest<List<Transaction>>
    {
        public Transaction transaction { get; set; } = null!;

        public DeleteTransactionCommand(int id)
        {
            this.transaction = new Transaction();
            transaction.TransactionNumber = id;
        }
    }
}
