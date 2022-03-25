using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazerBank.Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
            Cards = new HashSet<Card>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Card> Cards { get; set; }
    }
}
