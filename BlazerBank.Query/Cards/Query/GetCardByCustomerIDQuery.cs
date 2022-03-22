using MediatR;
using BlazerBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Cards.Query
{
    public class GetCardByCustomerIDQuery : IRequest<List<Card>>
    {
        public Card card { get; set; } = null!;

        public GetCardByCustomerIDQuery(int id)
        {
            card = new Card();
            card.CustomerId = id;
        }
    }
}
