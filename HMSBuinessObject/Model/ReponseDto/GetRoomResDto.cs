using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.ReponseDto
{
    public class GetRoomResDto
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; } = null!;
        public int RoomCapacity { get; set; } 
        public string RoomDescription { get; set; } = null!;
        public DateOnly CreatedDate { get; set; }
        public string RoomType { get; set; } = null!;
        public decimal BookingPrice { get; set; }
        public string Status { get; set; } = null!;
    }
}
