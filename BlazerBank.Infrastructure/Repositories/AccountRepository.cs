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
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(OnlineBankDBContext context) : base(context)
        {
        }
    }
}
