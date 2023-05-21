using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.Modal
{
   public  class StatusModel
    {
        public enum Status
        {
           Pending=1,
           Pending_At_BDO=2,
           Pending_At_Nodal_Officer=3,
           Pending_At_Collector=4,
           Resolve=5,
           Discard=6

        }
    }
}
