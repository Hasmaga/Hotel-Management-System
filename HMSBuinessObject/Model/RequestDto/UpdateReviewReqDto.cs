using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class UpdateReviewReqDto
    {
        [Required]
        public Guid Id { get; set; }
        [Range(0,5)]
        public decimal? ReviewStar { get; set; }
        public string? Comment { get; set; }
    }
}
