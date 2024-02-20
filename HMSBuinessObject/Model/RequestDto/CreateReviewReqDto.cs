using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class CreateReviewReqDto
    {
        [Required]
        public Guid RoomId { get; set; }

        [Required]
        [Range(0,5)]
        public decimal ReviewStar { get; set; }

        [Required]
        public string Comment { get; set; } = null!;
    }
}
