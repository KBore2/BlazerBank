using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;
using System.Net.Http.Json;

namespace BlazerBank.Client.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        private readonly HttpClient http;

        public CustomerService(HttpClient http)
        {
            this.http = http;
        }
        
        public Task<bool> Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Details(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Edit(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> Index()
        {
            var result = await http.GetFromJsonAsync<List<Customer>>("api/Customers");
            Customers = result;
            return Customers;
        }
    }
}
