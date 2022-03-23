using Microsoft.EntityFrameworkCore;
using BlazerBank.Domain.IRepositories;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Infrastructure.Repositories
{
    public class CardRepository : BaseRepository<Card>
    {
        public CardRepository(BlazerBankDBContext context) : base(context)
        {
        }

        public async Task<List<Card>> GetAll()
        {
            return await dbset.Include(c => c.Customer).ToListAsync();
        }

        public async Task<List<Card>> GetByCustomerID(Expression<Func<Card, bool>> expression)
        {
            return await dbset.Include(c => c.Customer).Where(expression).ToListAsync();
        }


    }
}
