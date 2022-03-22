﻿using MediatR;
using BlazerBank.Domain.Models;

namespace BlazerBank.Command.Accounts.Command
{
    public class CreateAccountCommand: IRequest<List<Account>>
    {
        public Account account { get; set; } = null!;

        public CreateAccountCommand(Account account)
        {
            this.account = account;
        }
    }
}
