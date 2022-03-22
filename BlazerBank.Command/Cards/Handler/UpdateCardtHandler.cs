using MediatR;
using BlazerBank.Command.Cards.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;

namespace BlazerBank.Command.Cards.Handler
{
    public class UpdateCardHandler : IRequestHandler<UpdateCardCommand, Card>
    {
        private readonly CardRepository repository;

        public UpdateCardHandler(CardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Card> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var response = await repository.Update(request.card);
            return response == null ? throw new Exception("Card not found") : response;
        }
    }
}
