using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Query.Cards.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Cards.Handler
{
    internal class GetAllCardsHandler: IRequestHandler<GetAllCardsQuery, List<Card>>
    {
        private readonly CardRepository repoistory;

        public GetAllCardsHandler(CardRepository repoistory)
        {
            this.repoistory = repoistory;
        }

        public async Task<List<Card>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            var response = await repoistory.GetAll();
            return response == null ? throw new Exception("Card not found") : response;
        }
    }
}
