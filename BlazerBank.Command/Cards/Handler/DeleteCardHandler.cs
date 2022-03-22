using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Command.Accounts.Command;
using BlazerBank.Command.Cards.Command;

namespace BlazerBank.Command.Cards.Handler
{
    public class DeleteCardHandler:IRequestHandler<DeleteCardCommand, List<Card>>
    {
        private readonly CardRepository repository;

        public DeleteCardHandler(CardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Card>> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var response =  await repository.DeleteAsync(c => c.CardNumber == request.card.CardNumber);
            return response == null ? throw new Exception("Card not found") : response;
        }
    }
}
