using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Cards.Command
{
    public class UpdateCardCommand : IRequest<Card>
    {
        public Card card { get; set; } = null!;

        public UpdateCardCommand(Card card)
        {
            this.card = card;
        }
    }
}
