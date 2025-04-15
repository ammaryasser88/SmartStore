using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.DTOs.Request.Security
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        public int? EmployeeId { get; set; }
    }
}
