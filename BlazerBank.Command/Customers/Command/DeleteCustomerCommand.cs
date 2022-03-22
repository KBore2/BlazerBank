using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Customers.Command
{
    public class DeleteCustomerCommand : IRequest<List<Customer>>
    {
        public Customer customer { get; set; } = null!;

        public DeleteCustomerCommand(int id)
        {
            this.customer = new Customer();
            customer.CustomerId = id;
        }
    }
}
