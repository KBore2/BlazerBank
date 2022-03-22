using MediatR;
using BlazerBank.Command.Customers.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Data;
using BlazerBank.Infrastructure.Repositories;

namespace BlazerBank.Command.Customers.Handler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, List<Customer>>
    {
        private readonly CustomerRepository repository;

        public CreateCustomerHandler(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.customer);
        }
    }
}
