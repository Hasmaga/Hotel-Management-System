using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class UpdateProfileReqDto
    {
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? IdentityCard { get; set; }
        public string? LicenceNumber { get; set; }
        public DateOnly? LicenceDate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
