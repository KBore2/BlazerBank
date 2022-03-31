using MediatR;
using BlazerBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Customers.Query
{
    public class GetCustomerLoginQuery : IRequest<UserToken>
    {
        public Customer customer { get; set; } = null!;

        public GetCustomerLoginQuery(Customer customer)
        {
            this.customer = customer;
        }
    }
}
