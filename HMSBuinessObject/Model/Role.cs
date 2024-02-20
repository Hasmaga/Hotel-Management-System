using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSBuinessObject.Model
{
    [Table("Role", Schema = "dbo")]
    public class Role : Common
    {
        [Column("Authority")]
        public string Authority { get; set; } = null!;

        public ICollection<Account>? Accounts { get; set; }
    }
}
