using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazerBank.Client.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public Customer Customer { get; set; } = new Customer();

        private readonly HttpClient http;
        //private readonly NavigationManager navigationManager;

        public CustomerService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
        }
        
        public async Task Create(Customer customer)
        {
            var result = await http.PostAsJsonAsync("api/Customers/Create",customer);
        }

        public Task<Customer> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteConfirmed(int? id)
        {
            var result = await http.DeleteAsync($"api/Customers/Delete/{id}");
        }

        public async Task<Customer> GetCustomer(int? id)
        {
            var result = await http.GetFromJsonAsync<Customer>($"api/Customers/Details/{id}");
            Customer = result;
            return Customer;
        }

        public Task<Customer> Edit(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(int? id, Customer customer)
        {
            var result = await http.PutAsJsonAsync($"api/Customers/Edit/{id}",customer);
            Customer = await result.Content.ReadFromJsonAsync<Customer>();

        }

        public async Task<List<Customer>> Index()
        {
            var result = await http.GetFromJsonAsync<List<Customer>>("api/Customers");
            Customers = result;
            return Customers;
        }
    }
}
