using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.Models.ViewModels
{
    public class CustomerWithToken
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
