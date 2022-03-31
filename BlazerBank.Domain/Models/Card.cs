using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazerBank.Domain.Models
{
    public partial class Card
    {
        public int CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Ccv { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
