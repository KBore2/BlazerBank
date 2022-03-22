using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Transactions.Command
{
    public class CreateTransactionCommand: IRequest<List<Transaction>>
    {
        public Transaction transaction { get; set; } = null!;
    }
}
