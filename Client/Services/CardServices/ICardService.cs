using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;

namespace BlazerBank.Client.Services.CardServices
{
    public interface ICardService
    {
        public List<Card> Cards { get; set; }

        public Card Card { get; set; }
        public Task<List<Card>> Index();

        public Task<Card> GetCard(int? id);
      
        public Task Create(Card Card);

        public Task Edit(int? id, Card Card);

        public Task DeleteConfirmed(int? id);
    }
}
