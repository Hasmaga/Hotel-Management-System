using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.RequestDto
{
    public class CreateRoomTypeReqDto
    {
        [Required]
        public string RoomTypeName { get; set; } = null!;

        [Required]
        public string RoomTypeDescription { get; set; } = null!;
    }
}
