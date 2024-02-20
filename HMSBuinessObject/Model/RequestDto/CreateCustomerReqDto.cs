using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class CreateCustomerReqDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        public string Mobile { get; set; } = null!;

        [Required]
        public DateOnly Birthday { get; set; }

        [Required]
        public string IdentityCard { get; set; } = null!;

        [Required]
        public string LicenceNumber { get; set; } = null!;

        [Required]
        public DateOnly LicenceDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;
    }
}
