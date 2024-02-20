using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model
{
    [Table("Review", Schema = "dbo")]
    public class Review : Common
    {
        [Column("CustomerId")]
        public Guid CustomerId { get; set; }
        public Account? Customer { get; set; }

        [Column("RoomInformationId")]
        public Guid RoomInformationId { get; set; }
        public RoomInformation? RoomInformation { get; set; }

        [Column("ReviewStar")]
        [Range(0, 5)]
        public decimal ReviewStar { get; set; }

        [Column("Comment")]
        public string Comment { get; set; } = null!;
    }
}
