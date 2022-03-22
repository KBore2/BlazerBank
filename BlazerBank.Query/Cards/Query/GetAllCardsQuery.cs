using MediatR;
using BlazerBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Cards.Query
{
    public class GetAllCardsQuery : IRequest<List<Card>>
    {
        public Card card { get; set; } = null!;
    }
}
