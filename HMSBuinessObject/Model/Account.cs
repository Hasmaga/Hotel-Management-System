using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model
{
    [Table("Customer", Schema = "dbo")]
    public class Account : Common
    {
        [Column("Name")]
        public string Name { get; set; } = null!;

        [Column("Mobile")]
        public string Mobile { get; set; } = null!;

        [Column("Birthday")]
        public DateOnly Birthday { get; set; }

        [Column("IdentityCard")]
        public string IdentityCard { get; set; } = null!;

        [Column("LicenceNumber")]
        public string LicenceNumber { get; set; } = null!;

        [Column("LicenceDate")]
        public DateOnly LicenceDate { get; set; }

        [Column("Email")]
        public string Email { get; set; } = null!;

        [Column("Password")]
        public string Password { get; set; } = null!;

        [Column("RoleId")]
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        public ICollection<BookingReservation>? BookingReservations { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
