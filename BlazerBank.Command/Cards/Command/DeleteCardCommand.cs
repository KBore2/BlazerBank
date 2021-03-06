using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Cards.Command
{
    public class DeleteCardCommand : IRequest<List<Card>>
    {
        public Card card { get; set; } = null!;

        public DeleteCardCommand(int id)
        {
            this.card = new Card();
            card.CardNumber = id;
        }
    }
}
