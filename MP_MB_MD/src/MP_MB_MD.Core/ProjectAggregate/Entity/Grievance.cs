using MP_MB_MD.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.ProjectAggregate.Entity
{
    public class Grievance : IAggregateRoot
    {
        [Key]
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Name_Of_Applicant { get; set; }
        public string FatherOrHusbandName { get; set; }
        public string MobileNo { get; set; }
        public string Email_Id { get; set; }
        public string VillageName { get; set; }
        public string Post_Office_Name { get; set; }
        public string Pincode { get; set; }
        public string Attachment { get; set; }
        public string Details_Of_Consern { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
