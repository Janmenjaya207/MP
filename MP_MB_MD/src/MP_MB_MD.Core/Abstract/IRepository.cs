using MP_MB_MD.Core.Modal;
using MP_MB_MD.Core.ProjectAggregate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.Abstract
{
  public   interface IRepository
    {
        int Grievance(Grievance ee);

        int SaveMangeUser(Manage_UserModel adminModel);
    }
}
