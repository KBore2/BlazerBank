using MediatR;
using BlazerBank.Command.Customers.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;

namespace BlazerBank.Command.Customers.Handler
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly CustomerRepository repository;

        public UpdateCustomerHandler(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await repository.Update(request.customer);
            return response ?? null;
        }
    }
}
