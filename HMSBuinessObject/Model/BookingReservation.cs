using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model
{
    [Table("BookingReservation", Schema = "dbo")]
    public class BookingReservation : Common
    {
        [Column("CustomerId")]
        public Guid CustomerId { get; set; }
        public Account? Customer { get; set; }

        [Column("RoomInformationId")]
        public Guid RoomInformationId { get; set; }
        public RoomInformation? RoomInformation { get; set; }

        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Column("EndDate")]
        public DateTime EndDate { get; set; }

        [Column("ActualPrice")]
        public decimal ActualPrice { get; set; }

        [Column("Status")]
        public string Status { get; set; } = null!;
    }
}
