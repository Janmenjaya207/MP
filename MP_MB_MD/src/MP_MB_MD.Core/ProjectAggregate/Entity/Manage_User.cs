using MP_MB_MD.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.ProjectAggregate.Entity
{
    public class Manage_User : IAggregateRoot
    {
        [Key]
        public int User_Id { get; set; }
        public int User_Type { get; set; }
        public string Name { get; set; }
        public string Mobile_no { get; set; }
        public string Email_Id { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public int? Block { get; set; }
        public int? Grampanchayat { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? Department_Id { get; set; }
        public string Department_NameDescription { get; set; }

        public bool? IsActive { get; set; }
        public bool? Isdelete { get; set; }

    }
}
