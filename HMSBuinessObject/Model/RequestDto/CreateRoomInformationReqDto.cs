using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class CreateRoomInformationReqDto
    {
        [Required]
        public string RoomName { get; set; } = null!;

        [Required]
        public int RoomCapacity { get; set; }

        [Required]
        public string RoomDescription { get; set; } = null!;        

        [Required]
        public string RoomType { get; set; } = null!;

        [Required]
        public decimal BookingPrice { get; set; }
    }
}
