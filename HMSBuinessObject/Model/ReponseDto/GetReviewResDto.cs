using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.ReponseDto
{
    public class GetReviewResDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
        public decimal ReviewStar { get; set; }
        public string Comment { get; set; } = null!;
    }
}
