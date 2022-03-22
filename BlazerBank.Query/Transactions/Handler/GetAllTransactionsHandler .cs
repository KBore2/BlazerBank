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
    internal class GetAllTransactionsHandler: IRequestHandler<GetAllTransactionsQuery, List<Transaction>>
    {
        private readonly TransactionRepository repoistory;

        public GetAllTransactionsHandler(TransactionRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<List<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.ListAsync();
            return response == null ? throw new Exception("Transaction not found") : response;
        }
    }
}
