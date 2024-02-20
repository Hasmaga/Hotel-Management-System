using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model.ReponseDto
{
    public class GetRoomTypeResDto
    {
        public Guid Id { get; set; }
        public string RoomTypeName { get; set; } = null!;
        public string RoomTypeDescription { get; set; } = null!;
    }
}
