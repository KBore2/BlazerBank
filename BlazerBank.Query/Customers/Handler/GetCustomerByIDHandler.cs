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
    internal class GetCustomerByIDHandler: IRequestHandler<GetCustomerByIDQuery,Customer>
    {
        private readonly CustomerRepository repoistory;

        public GetCustomerByIDHandler(CustomerRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<Customer> Handle(GetCustomerByIDQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.GetAsync(c => c.CustomerId == request.customer.CustomerId);
            return response ?? null;
        }
    }
}
