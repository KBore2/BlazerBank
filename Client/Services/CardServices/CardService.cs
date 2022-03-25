using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazerBank.Client.Services.CardServices
{
    public class CardService : ICardService
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Card Card { get; set; } = new Card();

        private readonly HttpClient http;

        public CardService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
        }
        
        public async Task Create(int? customrid,Card Card)
        {
            var result = await http.PostAsJsonAsync($"api/Cards{customrid}Create", Card);
        }

        public async Task DeleteConfirmed(int? customrid,int? id)
        {
            var result = await http.DeleteAsync($"api/Cards/{customrid}/Delete/{id}");
        }

        public async Task<Card> GetCard(int? customrid,int? id)
        {
            var result = await http.GetFromJsonAsync<Card>($"api/Cards/{customrid}/Details/{id}");
            Card = result;
            return Card;
        }

        public async Task Edit(int? customrid,int? id, Card Card)
        {
            var result = await http.PutAsJsonAsync($"api/Cards/{customrid}/Edit/{id}",Card);
            Card = await result.Content.ReadFromJsonAsync<Card>();

        }

        public async Task<List<Card>> Index()
        {
            var result = await http.GetFromJsonAsync<List<Card>>($"api/Cards");
            Cards = result;
            return Cards;
        }

        public async Task<List<Card>> CardsByCustomer(int? customrid)
        {
            var result = await http.GetFromJsonAsync<List<Card>>($"api/Cards/{customrid}");
            Cards = result;
            return Cards;
        }
    }
}
