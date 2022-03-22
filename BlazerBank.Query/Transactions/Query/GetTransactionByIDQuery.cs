using MediatR;
using BlazerBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Transactions.Query
{
    public class GetTransactionByIDQuery : IRequest<Transaction>
    {
        public Transaction transaction { get; set; } = null!;

        public GetTransactionByIDQuery(int accountNumber,int id)
        {
            transaction = new Transaction();
            transaction.AccountNumber = accountNumber;
            transaction.TransactionNumber = id;
        }
    }
}
