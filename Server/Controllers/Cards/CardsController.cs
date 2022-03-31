#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazerBank.Command.Cards.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Data;
using BlazerBank.Query.Cards.Query;

namespace BlazerBank.Controllers.AddCardControllerr
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : Controller
    {
        private readonly IMediator mediator;

        public CardsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return Ok(await mediator.Send(new GetAllCardsQuery()));
        }

        // GET: Cards/2
        [HttpGet("{id}")]
        public async Task<IActionResult> CardsByCustomer(int id)
        {
            //return View(await mediator.Send(new GetCardByCustomerIDQuery(id)));
            TempData["customerId"] = id;
            var card = await mediator.Send(new GetCardByCustomerIDQuery(id));
            return Ok(card);
        }

        // GET: Cards/2/Details/2
        [HttpGet("{customerId}/Details/{cardNumber}")]
        public async Task<IActionResult> Details(int customerId,int cardNumber)
        {

            var Card = await mediator.Send(new GetCardByIDQuery(customerId, cardNumber));
            return Card == null? NotFound(): Ok(Card);
        }

        // GET: Cards/Create
        /*[HttpPost("{customerId}/Create")]
        public IActionResult Create()
        {
            return View();
        }*/

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{customerId}/Create")]
        public async Task<IActionResult> Create(int customerId,Card Card)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                Card.CustomerId = customerId;
                return Ok(await mediator.Send(new CreateCardCommand(Card)));
            }
            return NotFound();
        }


        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{customerId}/Edit/{cardNumber}")]
        public async Task<IActionResult> Edit(int customerId, int cardNumber, Card Card)
        {
            /*ModelState.Remove("Card.Customer");
            if (ModelState.IsValid)
            {*/

                Card.CardNumber = cardNumber;
                Card.CustomerId = customerId;
                return Ok(await mediator.Send(new UpdateCardCommand(Card)));

            /*}

            return NotFound();*/
        }
        

        // POST: Cards/Delete/5
        [HttpDelete("{customerId}/Delete/{cardNumber}")]
        public async Task<IActionResult> DeleteConfirmed(int customerId, int cardNumber)
        {
            await mediator.Send(new DeleteCardCommand(cardNumber));
            return NoContent();
        }
    }
}
