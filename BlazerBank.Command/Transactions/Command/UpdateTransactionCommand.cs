using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Transactions.Command
{
    public class UpdateTransactionCommand : IRequest<Transaction>
    {
        public Transaction transaction { get; set; } = null!;

        public UpdateTransactionCommand(Transaction Transaction)
        {
            this.transaction = Transaction;
        }
    }
}
