using MP_MB_MD.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.ProjectAggregate.Entity
{
    public class Mst_UserType : IAggregateRoot
    {
        [Key]
        public int User_Type_Id { get; set; }
        public string User_Type { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdon { get; set; }
    }
}
