using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class CustomerPassword
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
