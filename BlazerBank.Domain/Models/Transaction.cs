using System;
using System.Collections.Generic;

namespace BlazerBank.Domain.Models
{
    public partial class Transaction
    {
        public int TransactionNumber { get; set; }
        public int AccountNumber { get; set; }
        public byte[] Timestamp { get; set; } = null!;
        public int TransactionAmount { get; set; }
        public int PreviousBalance { get; set; }
        public int CurrentBalance { get; set; }

        public virtual Account AccountNumberNavigation { get; set; } = null!;
    }
}
