using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.ReponseDto
{
    public class GetListCustomerResDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public string IdentityCard { get; set; } = null!;
        public string LicenceNumber { get; set; } = null!;
        public DateOnly LicenceDate { get; set; }
        public string Email { get; set; } = null!;
    }
}
