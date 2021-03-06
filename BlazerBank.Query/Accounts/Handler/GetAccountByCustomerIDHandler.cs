using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Query.Accounts.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazerBank.Query.Accounts.Handler
{
    internal class GetAccountByCustomerIDHandler: IRequestHandler<GetAccountByCustomerIDQuery, List<Account>>
    {
        private readonly AccountRepository repoistory;

        public GetAccountByCustomerIDHandler(AccountRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<List<Account>> Handle(GetAccountByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.ListAsync(c => c.CustomerId == request.Account.CustomerId);
            return response ?? null;
        }
    }
}
