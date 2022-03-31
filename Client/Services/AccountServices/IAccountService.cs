using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;

namespace BlazerBank.Client.Services.AccountServices
{
    public interface IAccountService
    {
        public List<Account> Accounts { get; set; }

        public Account Account { get; set; }
        public Task<List<Account>> Index();

        public Task<List<Account>> AccountsByCustomer(int? customerid);

        public Task<Account> GetAccount(int? customrid,int? id);
      
        public Task Create(int? customrid,Account Account);

        public Task Edit(int? customrid,int? id, Account Account);

        public Task DeleteConfirmed(int? customrid,int? id);
    }
}
