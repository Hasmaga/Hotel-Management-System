using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class UpdateRoomReqDto
    {
        public Guid Id { get; set; }
        public string? RoomName { get; set; }
        public int? RoomCapacity { get; set; }
        public string? RoomDescription { get; set; }
        public DateOnly? CreateDate { get; set; }
        public string? RoomType { get; set; }
        public decimal? BookingPrice { get; set; }
        public string? Status { get; set; }
    }
}
