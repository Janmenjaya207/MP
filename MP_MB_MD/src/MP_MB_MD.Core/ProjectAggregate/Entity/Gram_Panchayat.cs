using MP_MB_MD.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.ProjectAggregate.Entity
{
   public  class Gram_Panchayat: IAggregateRoot
    {
        [Key]
        public int GarmPanchayat_Id { get; set; }
        public int Block_Ulb_Id { get; set; }
        public string GRAM_PANCHAYAT_Name { get; set; }

        public int DistrictId { get; set; }
        public bool? Is_Active { get; set; }
        public bool? Is_Deleted { get; set; }
        public DateTime? Created_On { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public DateTime? Modified_On { get; set; }

    }
}
