using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model
{
    [Table("RoomType", Schema = "dbo")]
    public class RoomType : Common
    {
        [Column("RoomTypeName")]
        public string RoomTypeName { get; set; } = null!;

        [Column("RoomDescription")]
        public string RoomDescription { get; set; } = null!;

        public ICollection<RoomInformation>? RoomInformations { get; set; }
    }
}
