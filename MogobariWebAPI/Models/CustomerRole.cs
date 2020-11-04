using System;
using System.Collections.Generic;

namespace MogobariWebAPI.Models
{
    public partial class CustomerRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public bool FreeShipping { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
    }
}
