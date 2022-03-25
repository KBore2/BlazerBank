using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;

namespace BlazerBank.Client.Services.CustomerServices
{
    public interface ICustomerService
    {
        public List<Customer> Customers { get; set; }

        public Customer Customer { get; set; }
        public Task<List<Customer>> Index();

        public Task<Customer> GetCustomer(int? id);

        public Task Create(Customer customer);

        public Task<Customer> Edit(int id);

        public Task Edit(int? id, Customer customer);

        public Task<Customer> Delete(int id);
        public Task DeleteConfirmed(int? id);

    }
}
