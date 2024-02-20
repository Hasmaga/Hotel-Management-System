using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class CreateRoleReqDto
    {
        [Required]
        public string Authority { get; set; } = null!;
    }
}
