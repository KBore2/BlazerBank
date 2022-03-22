using MediatR;
using BlazerBank.Command.Cards.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;

namespace BlazerBank.Command.Cards.Handler
{
    public class CreateCardHandler : IRequestHandler<CreateCardCommand, List<Card>>
    {
        private readonly CardRepository repository;

        public CreateCardHandler(CardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Card>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddAsync(request.card);
        }
    }
}
