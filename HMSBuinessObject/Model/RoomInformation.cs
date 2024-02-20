using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model
{
    [Table("RoomInformation", Schema = "dbo")]
    public class RoomInformation : Common
    {
        [Column("RoomName")]
        public string RoomName { get; set; } = null!;

        [Column("RoomCapacity")]
        public int RoomCapacity { get; set; }

        [Column("RoomDescription")]
        public string RoomDescription { get; set; } = null!;

        [Column("CreatedDate")]
        public DateOnly CreatedDate { get; set; }

        [Column("RoomTypeID")]
        public Guid RoomTypeID { get; set; }
        public RoomType RoomType { get; set; } = null!;

        [Column("BookingPrice")]
        public decimal BookingPrice { get; set; }

        [Column("Status")]
        public string Status { get; set; } = null!;

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<BookingReservation>? BookingReservations { get; set; }
    }
}
