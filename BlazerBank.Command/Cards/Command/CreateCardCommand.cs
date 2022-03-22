using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Cards.Command
{
    public class CreateCardCommand: IRequest<List<Card>>
    {
        public Card card { get; set; } = null!;

        public CreateCardCommand(Card card)
        {
            this.card = card;
        }
    }
}
