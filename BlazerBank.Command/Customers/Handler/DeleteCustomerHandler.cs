using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Command.Customers.Command;

namespace BlazerBank.Command.Customers.Handler
{
    public class DeleteCustomerHandler:IRequestHandler<DeleteCustomerCommand, List<Customer>>
    {
        private readonly CustomerRepository repository;

        public DeleteCustomerHandler(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Customer>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response =  await repository.DeleteAsync(c => c.CustomerId == request.customer.CustomerId);
            return response ?? null;
        }
    }
}
