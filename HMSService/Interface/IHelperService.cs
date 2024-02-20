using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService.Interface
{
    public interface IHelperService
    {        
        Guid GetAccIdFromLogged();
        bool IsTokenValid();
    }
}
