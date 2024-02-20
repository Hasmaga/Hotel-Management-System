using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class UpdateCustomerInfoReqDto
    {
        [Required]
        public Guid Id { get; set; }

        public string? CustomerName { get; set; }

        [Phone]
        public string? Mobile { get; set; } 

        public DateOnly Birthday { get; set; }

        public string? IdentityCard { get; set; }

        public string? LicenceNumber { get; set; }

        public DateOnly LicenceDate { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
