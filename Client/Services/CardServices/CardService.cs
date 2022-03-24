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
        
        public async Task Create(Card Card)
        {
            var result = await http.PostAsJsonAsync("api/Cards/Create",Card);
        }

        public async Task DeleteConfirmed(int? id)
        {
            var result = await http.DeleteAsync($"api/Cards/Delete/{id}");
        }

        public async Task<Card> GetCard(int? id)
        {
            var result = await http.GetFromJsonAsync<Card>($"api/Cards/Details/{id}");
            Card = result;
            return Card;
        }

        public async Task Edit(int? id, Card Card)
        {
            var result = await http.PutAsJsonAsync($"api/Cards/Edit/{id}",Card);
            Card = await result.Content.ReadFromJsonAsync<Card>();

        }

        public async Task<List<Card>> Index()
        {
            var result = await http.GetFromJsonAsync<List<Card>>("api/Cards");
            Cards = result;
            return Cards;
        }
    }
}
