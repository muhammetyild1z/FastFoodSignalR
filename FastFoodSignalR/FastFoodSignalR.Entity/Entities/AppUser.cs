using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.Entity.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string userPhoneNumber { get; set; }
    }
}
