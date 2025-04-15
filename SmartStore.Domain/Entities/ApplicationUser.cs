using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Name { get; set; }
    }

}
