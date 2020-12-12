using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class RefreshTokenForCustomer
    {
        public int TokenId { get; set; }
        public int CustomerId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
