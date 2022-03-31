using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazerBank.Client.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        public List<Account> Accounts { get; set; } = new List<Account>();

        public Account Account { get; set; } = new Account();

        private readonly HttpClient http;

        public AccountService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
        }
        
        public async Task Create(int? customrid,Account Account)
        {
            var result = await http.PostAsJsonAsync($"api/Accounts/{customrid}/Create", Account);
        }

        public async Task DeleteConfirmed(int? customrid,int? id)
        {
            var result = await http.DeleteAsync($"api/Accounts/{customrid}/Delete/{id}");
        }

        public async Task<Account> GetAccount(int? customrid,int? id)
        {
            var result = await http.GetFromJsonAsync<Account>($"api/Accounts/{customrid}/Details/{id}");
            Account = result;
            return Account;
        }

        public async Task Edit(int? customrid,int? id, Account Account)
        {
            var result = await http.PutAsJsonAsync($"api/Accounts/{customrid}/Edit/{id}",Account);
            Account = await result.Content.ReadFromJsonAsync<Account>();

        }

        public async Task<List<Account>> Index()
        {
            var result = await http.GetFromJsonAsync<List<Account>>($"api/Accounts");
            Accounts = result;
            return Accounts;
        }

        public async Task<List<Account>> AccountsByCustomer(int? customrid)
        {
            var result = await http.GetFromJsonAsync<List<Account>>($"api/Accounts/{customrid}");
            Accounts = result;
            return Accounts;
        }
    }
}
