using BlazerBank.Client.Pages;
using BlazerBank.Domain.Models;

namespace BlazerBank.Client.Services.CardServices
{
    public interface ICardService
    {
        public List<Card> Cards { get; set; }

        public Card Card { get; set; }
        public Task<List<Card>> Index();

        public Task<List<Card>> CardsByCustomer(int? customerid);

        public Task<Card> GetCard(int? customrid,int? id);
      
        public Task Create(int? customrid,Card Card);

        public Task Edit(int? customrid,int? id, Card Card);

        public Task DeleteConfirmed(int? customrid,int? id);
    }
}
