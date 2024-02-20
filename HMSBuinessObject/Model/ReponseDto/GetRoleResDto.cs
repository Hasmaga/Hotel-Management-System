using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.ReponseDto
{
    public class GetRoleResDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
