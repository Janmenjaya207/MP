using MP_MB_MD.SharedKernel;
using MP_MB_MD.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.ProjectAggregate.Entity
{
   public class Department_Table : BaseEntity, IAggregateRoot
    {
        public string Department { get; set; }
    }
}
