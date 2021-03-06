using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Query.Transactions.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Transactions.Handler
{
    internal class GetTransactionByAccountIDHandler: IRequestHandler<GetTransactionByIDQuery,Transaction>
    {
        private readonly TransactionRepository repoistory;

        public GetTransactionByAccountIDHandler(TransactionRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<Transaction> Handle(GetTransactionByIDQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.GetAsync(c => c.AccountNumber == request.transaction.AccountNumber);
            return response == null ? throw new Exception("Transaction not found") : response;
        }
    }
}
