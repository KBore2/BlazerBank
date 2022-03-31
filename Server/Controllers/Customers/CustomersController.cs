using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazerBank.Command.Customers.Command;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Data;
using BlazerBank.Query.Customers.Query;

namespace BlazerBank.Controllers.AddCustomerControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Customers
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await mediator.Send(new GetAllCustomersQuery()));
        }

        // GET: Customers/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var customer = await mediator.Send(new GetCustomerByIDQuery(id));
            return Ok(customer);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                return Ok(await mediator.Send(new CreateCustomerCommand(customer)));
            }
            return NotFound();
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = id;
                await mediator.Send(new UpdateCustomerCommand(customer));
                return Ok(customer);
            }
            return NotFound();
        }

        // POST: Customers/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetToken(Customer customer)
        {
            return Ok(await mediator.Send(new GetCustomerLoginQuery(customer)));
        }
    }
}
