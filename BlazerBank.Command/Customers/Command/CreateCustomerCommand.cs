using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Customers.Command
{
    public class CreateCustomerCommand: IRequest<List<Customer>>
    {
        public Customer customer { get; set; } = null!;

        public CreateCustomerCommand(Customer customer)
        {
            this.customer = customer;
        }
    }
}
