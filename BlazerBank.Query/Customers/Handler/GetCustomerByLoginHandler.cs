using MediatR;
using BlazerBank.Domain.Models;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Query.Customers.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerBank.Infrastructure;

namespace BlazerBank.Query.Customers.Handler
{
    internal class GetCustomerLoginHandler: IRequestHandler<GetCustomerLoginQuery,UserToken>
    {
        private readonly CustomerRepository repoistory;
        private readonly JWTSettings jwtSettings;

        public GetCustomerLoginHandler(CustomerRepository repoistory, JWTSettings jwtSettings)
        {
            this.repoistory = repoistory;
            this.jwtSettings = jwtSettings;
        }

        public async Task<UserToken> Handle(GetCustomerLoginQuery request, CancellationToken cancellationToken)
        {
            
                var Token = new UserToken();
                var user = await repoistory.GetAsync(c => c.FirstName == request.customer.FirstName && c.LastName == request.customer.LastName);
                if(user == null)
                    return null;
                
                Token = JWTHelpers.GenTokenkey(new UserToken(){
                    GuidId = Guid.NewGuid(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.CustomerId,
                    }, jwtSettings);

                return Token;
                
        
        }
    }
}
