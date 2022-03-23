using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;

namespace BlazerBank.Client.Services.CustomerServices
{
    public interface ICustomerService
    {
        public List<Customer> Customers { get; set; }
        public Task<List<Customer>> Index();

        public Task<Customer> Details(int id);

        
        /*public IActionResult Create()
        {
            return View();
        }*/

      
        public Task<bool> Create(Customer customer);

        public Task<Customer> Edit(int id);

        public Task<bool> Edit(int id, Customer customer);

        public Task<Customer> Delete(int id);
        public Task<bool> DeleteConfirmed(int id);
    }
}
