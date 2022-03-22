using MediatR;
using BlazerBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Query.Transactions.Query
{
    public class GetAllTransactionsQuery : IRequest<List<Transaction>>
    {
        public Transaction transaction { get; set; } = null!;
    }
}
