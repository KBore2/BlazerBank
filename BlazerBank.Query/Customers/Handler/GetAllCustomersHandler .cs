using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Query.Customers.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Customers.Handler
{
    internal class GetAllCustomersHandler: IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private readonly CustomerRepository repoistory;

        public GetAllCustomersHandler(CustomerRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await repoistory.ListAsync();
        }
    }
}
