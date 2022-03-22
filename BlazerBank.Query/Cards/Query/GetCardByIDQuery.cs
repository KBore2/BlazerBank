﻿using MediatR;
using BlazerBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Cards.Query
{
    public class GetCardByIDQuery : IRequest<Card>
    {
        public Card card { get; set; } = null!;

        public GetCardByIDQuery(int customerID, int cardNumber)
        {
            card = new Card();
            card.CustomerId = customerID;
            card.CardNumber = cardNumber;
        }
    }
}
