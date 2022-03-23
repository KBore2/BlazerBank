using BlazerBank.Domain.IRepositories;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(BlazerBankDBContext context) : base(context)
        {
        }
    }
}
